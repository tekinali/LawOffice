using LawOffice.Business.Abstract;
using LawOffice.Business.Concrete.Managers;
using LawOffice.DataAccess.Abstract;
using LawOffice.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            // Data Access
            Bind<IAnswerDal>().To<EfAnswerDal>().InSingletonScope();
            Bind<IBlogCategoryDal>().To<EfBlogCategoryDal>().InSingletonScope();
            Bind<IBlogDal>().To<EfBlogDal>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<IFieldsOfLawDal>().To<EfFieldsOfLawDal>().InSingletonScope();
            Bind<ILogDal>().To<EfLogDal>().InSingletonScope();
            Bind<IQuestionDal>().To<EfQuestionDal>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();

            Bind<IUserAreaDal>().To<EfUserAreaDal>().InSingletonScope();            
            Bind<IUserRoleDal>().To<EfUserRoleDal>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();



            // Business
            Bind<IAnswerService>().To<AnswerManager>().InSingletonScope();
            Bind<IBlogCategoryService>().To<BlogCategoryManager>().InSingletonScope();
            Bind<IBlogService>().To<BlogManager>().InSingletonScope();   
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();

            Bind<IFieldsOfLawService>().To<FieldsOfLawManager>().InSingletonScope();
            Bind<ILogService>().To<LogManager>().InSingletonScope();
            Bind<IQuestionService>().To<QuestionManager>().InSingletonScope();
            Bind<IRoleService>().To<RoleManager>().InSingletonScope();

            Bind<IUserAreaService>().To<UserAreaManager>().InSingletonScope();
            Bind<IUserRoleService>().To<UserRoleManager>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();






            Bind<DbContext>().To<DatabaseContext>();
        }
    }
}
