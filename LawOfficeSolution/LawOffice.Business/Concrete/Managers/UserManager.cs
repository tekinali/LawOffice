using AutoMapper;
using LawOffice.Business.Abstract;
using LawOffice.Business.ValidationRules.FluentValidation;
using LawOffice.Core.Aspects.Postsharp.AuthorizationAspects;
using LawOffice.Core.Aspects.Postsharp.CacheAspects;
using LawOffice.Core.Aspects.Postsharp.LogAspects;
using LawOffice.Core.Aspects.Postsharp.TransactionAspects;
using LawOffice.Core.Aspects.Postsharp.ValidationAspects;
using LawOffice.Core.CrossCuttingConcerns.Caching.Microsoft;
using LawOffice.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using LawOffice.DataAccess.Abstract;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;    
        private readonly IMapper _mapper;

        IRoleService _roleService;
        IUserRoleService _userRoleService;
        IBlogService _blogService;
        IAnswerService _answerService;
        IUserAreaService _userAreaService;

        public UserManager(IUserDal userDal, IMapper mapper, 
            IRoleService roleService, IUserRoleService userRoleService, 
            IBlogService blogService, IAnswerService answerService, IUserAreaService userAreaService)
        {
            _userDal = userDal;
            _mapper = mapper;
            _roleService = roleService;
            _userRoleService = userRoleService;
            _blogService = blogService;
            _answerService = answerService;
            _userAreaService = userAreaService;
        }


     
        [SecuredOperation(Roles = "Admin")]
        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]      
        public AppUser Add(AppUser entity)
        {
            entity.Email= CultureInfo.CurrentCulture.TextInfo.ToLower(entity.Email).Trim();

            var db_user = _userDal.GetList(x => x.UserName == entity.UserName || x.Email == entity.Email);

            if (db_user.Count>0)
            {
                foreach (var item in db_user)
                {
                    if(item.UserName==entity.UserName)
                    {
                        throw new Exception("Bu Kullanıcı Adı ile daha önce kayıt olunmuştur.");
                    }

                    if(item.Email==entity.Email)
                    {
                        throw new Exception("Bu EPosta adresi ile daha önce kayıt olunmuştur.");
                    }                
                }
            }


            var user = _userDal.Add(entity);
            var userRole = new UserRole()
            {
                AppUserId = user.Id,
                AppRoleId=_roleService.GetStandartUserRoleId()                
            };

            var result = _userRoleService.Add(userRole);
            
            return user;
        }

     
        [SecuredOperation(Roles = "Admin")]
        [TransactionScopeAspect]       
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(AppUser entity)
        {
            var blogs = _blogService.List(x => x.AppUserId == entity.Id);
            if(blogs.Count>0)
            {
                foreach (var item in blogs)
                {
                    _blogService.Delete(item);
                }
            }

            var answers = _answerService.List(x => x.AppUserId == entity.Id);
            if(answers.Count>0)
            {
                foreach (var item in answers)
                {
                    _answerService.Delete(item);
                }
            }

            var areas = _userAreaService.List(x => x.AppUserId == entity.Id);
            if(areas.Count>0)
            {
                foreach (var item in areas)
                {
                    _userAreaService.Delete(item);
                }
            }

            var roles = _userRoleService.List(x => x.AppUserId == entity.Id);
            if(roles.Count>0)
            {
                foreach (var item in roles)
                {
                    _userRoleService.Delete(item);
                }
            }

            _userDal.Delete(entity);
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public AppUser Find(Expression<Func<AppUser, bool>> filter)
        {
            var user = _mapper.Map<AppUser>(_userDal.Get(filter));
            return user;
        }

        [SecuredOperation(Roles = "Admin")]
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<AppUser> GetAll()
        {
            var users = _mapper.Map<List<AppUser>>(_userDal.GetList());
            return users;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public List<AppUser> List(Expression<Func<AppUser, bool>> filter)
        {
            var users = _mapper.Map<List<AppUser>>(_userDal.GetList(filter));
            return users;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        [FluentValidationAspect(typeof(UserValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public AppUser Update(AppUser entity)
        {
            return _userDal.Update(entity);
        }


        public List<string> GetUserRolesStringName(Guid UserId)
        {
            var userRoleIds = _userRoleService.List(x => x.AppUserId == UserId).Select(x => x.AppRoleId);
            var roleNames = _roleService.List(x => userRoleIds.Contains(x.Id)).Select(n=>n.Name).ToList();
            return roleNames;        
        }

        public List<AppRole> GetUserRoles(Guid UserId)
        {
            var userRoleIds = _userRoleService.List(x => x.AppUserId == UserId).Select(x=>x.AppRoleId);
            var roles = _mapper.Map<List<AppRole>>(_roleService.List(x=>userRoleIds.Contains(x.Id)));

            return roles;          
        }
        
        public AppUser LoginUser(string userName, string password)
        {
            var roleId = _roleService.GetStandartUserRoleId();
            var user = _userDal.Get(x => x.UserName == userName && x.Password == password);
            if(user==null)
            {
                return null;
            }

            var userRole = _userRoleService.Find(x => x.AppUserId == user.Id && x.AppRoleId == roleId);
            if(userRole==null)
            {
                return null;
            }

            return user;

            
        }
    
        public AppUser LoginAdmin(string userName, string password)
        {
            var roleId = _roleService.GetAdminRolesId();
            var user = _userDal.Get(x => x.UserName == userName && x.Password == password);
            if (user == null)
            {
                return null;
            }

            var userRole = _userRoleService.Find(x => x.AppUserId == user.Id && x.AppRoleId == roleId);
            if (userRole == null)
            {
                return null;
            }

            return user;
        }

        public bool IsAdmin(AppUser entity)
        {
            var roleId = _roleService.GetAdminRolesId();
            var userRole = _userRoleService.Find(x => x.AppUserId == entity.Id && x.AppRoleId == roleId);
            if(userRole==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsStandartUser(AppUser entity)
        {
            var roleId = _roleService.GetStandartUserRoleId();
            var userRole = _userRoleService.Find(x => x.AppUserId == entity.Id && x.AppRoleId == roleId);
            if (userRole == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
