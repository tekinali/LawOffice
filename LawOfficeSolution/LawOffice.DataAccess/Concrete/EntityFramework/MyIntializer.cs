using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.DataAccess.Concrete.EntityFramework
{
    public class MyIntializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {

            
            int UserCount = 50;
            int BlogCount = 700;
            int QuestionCount = 2000;

            DateTime now = DateTime.Now.AddDays(-5);

            string[] FieldsOfLawList = {"Anti-damping & Gümrük Hukuku","Bilişim Hukuku","Bankacılık & Finansal Hizmetler Hukuku","Ceza Hukuku",
                "Çevre Hukuku","Deniz, Lojistik & Taşımacılık Hukuku","Enerji Hukuku","E-ticaret Hukuku","Fikri ve Sınai Mülkiyet Hukuku","Gayrimenkul & Kira Hukuku","Havacılık Hukuku","İdare Hukuku","İflas & Aciz Hukuku",
                "İnşaat Hukuku","İnternet Hukuku","İş & Çalışma Hukuku","Madencilik Hukuku","Medya & Eğlence Hukuku","Miras Hukuku","Reklam ve Pazarlama Hukuku","Rekabet Hukuku","Sağlık & Malpraktis Hukuku",
                "Sermaye Piyasaları & Menkul Kıymetler Hukuku","Sigorta Hukuku","Şirketler Hukuku","Spor Hukuku","Sözleşmeler Hukuku","Uluslararası Hukuk","Uyumlaştırma & AB Hukuku","Telekomünikasyon & Bilgi Teknolojileri Hukuku","Ticaret Hukuku","Tüketici Hukuku"
            };

            string[] Categories = {"Arge","Bilimsel","Bilişim","Çevre","Çocuk Gelişimi","Diğer","Eğitim","Elektronik","Endüstri","Enerji","Girişimcilik","Haberleşme",
                "İletişim","İnovasyon","Kamu","Sağlık","Sanat","Sanayi","Tarih","Tasarım","Teknoloji","Turizm","Ulaşım","Uygulama","Yazılım"
            };

            string[] LastNameList = {"ABACIOĞLU","ABAT","ABSEYİ","ACAR","ACARBULUT","AÇAR","AÇIKGÖZ","ADALI","ADANIR","ADIGÜZEL","AKTAŞ",
                "AKTEMUR","AKTUĞ","AKTÜRK","AKYILMAZ","AKYOL","AKYÜREK","AKYÜZ","AL","ALABALIK","ALADAĞ","ALAN","ALAY","ALAYBEYOĞLU",
                "ALBAŞ","ALBAY","ALBAYRAK","ALBEN","ALBOĞA","ALDİNÇ","ALĞAN","ALICI","ALIM","ALIMLI","BAKLACI","BAKLALI","BAL","BALABAN","BALAL","BALCI","BALLI","BALOĞLU","BALSAK","BALTA",
                "BALTACI","BARAN","BARATALI","BARBAROS","BARÇA","BARÇAK","BARDAKÇI","BARIŞAN","BARUT","BAŞ","BAŞAK","BAŞAR","BAŞARAN","BAŞARGAN","BAŞCI","BAŞDAŞ","BAŞER","BİÇER","BİLAL","BİLGE","BİLGİ","BİLGİÇ","BİLGİN","BİLİCİ","BİNBOĞA","BİNNETOĞLU","BİRİ","BOBUŞOĞLU","BODUROĞLU","BOĞAN","BOLAÇ","BOLAT","BOLATKALE","BOLATTÜRK","BOLKAN","BOLSOY","BOSTANKOLU",
                "BOZAN","BOZARSLAN","BOZKURT","BOZKURTER","BOZKUŞ","BOZOĞLAN","BOZOĞLU","BOZPOLAT","BÖCÜ","BÖLÜK","BÖLÜKBAŞ","BÖRTA","BÖYÜK","BUDUNOĞLU","BUĞRUL","BULAKÇI","BULUÇ","BULUR","BULUT","BURAK","BURULDAY","BÜBER","BÜDÜN","BÜKÜLMEZ","ÇATUK","ÇAVDAR","ÇAVLI","ÇAY","ÇAYLI","ÇEÇEN","ÇEKİÇ","ÇELEBİ","ÇELEN","ÇELİK","ERGE","ERGİNEL","ERGİNTÜRK ACAR","ERGÖZ",
                "ERGÜLÜ EŞMEN","ERGÜN","ERKAN","ERKEN","ERKURAN","EROĞLU","EROL","ERSOY","ERSÖZ","ERŞEN","ERTAN","ERTAŞ","ERTEKİN","ERTEM","ERTÜRK","ERTÜRKLER","ERYAVUZ","ERYILMAZ","ERZURUM","GÖKGÜL","GÖKKOCA","GÖKMEYDAN","GÖKSEL","GÖKSOY","GÖKTAŞ","GÖKTEN","GÖKTEPE","GÖKTÜRK","GÖLEMEZ","GÖNCÜ","GÖRDÜK","GÖRENEKLİ","GÖRKEM","GÖRMELİ","GÖRMÜŞ","HATİPOĞLU",
                "HAVAS","HEPKAYA","HEYBET","HIDIROĞLU","HİÇDURMAZ","HİÇYILMAZ","HODJAOGLU","HOŞER","HÖKE","HÜSEYİNOĞLU","HÜSEYNİ","KARAAĞAÇ","KARAALP","KARAARSLAN","KARAASLAN","KARABAĞ","KARABULUT","KARACA","KARACAN","KARACAN ERŞEKERCİ","KARADAĞ","KARADAĞ GEÇGEL","KARADAŞ","KARADAVUT","KARADEMİR","KARADENİZ","KARADUMAN","KARADURAK","KARAGÖZ","KARAHAN",
                "KARAİSMAİLOĞLU","KARAKAN","KESİM","KESKİN","KEŞKEK","KEVKİR","KHALİL","KILAÇ","KILAVUZ","KILBACAK","KILIÇCIOĞLU","KILIÇOĞLU","KILINÇ","KINALIOĞLU","KINDIR","KINIK","KIR","KIRAÇ","KIRAN","KIRASLAN","KIRBAŞ","KIRCALI","KIRHAN","KÖSEOĞLU","KÖŞKER","KÖYCÜ","KÖYLÜ","KÖYLÜOĞLU","KUBAT","KUDAY","KUMBUL","KUMRAL","KUNAK","KURTULUŞ","KURU","KURUL",
                "NURLU","OCAK","OFLAZ","OFLAZOĞLU","OĞUZ","OĞUZSOY","OKÇU","OKTAY","OKUDAN","OKULU","OKUR","OLCAR","OLGAÇ","OLGEN","OLMAZ","OLPAK","OMAY","ONRAT","ONUK","ORAK","ORAL","ORDULU ŞAHİN","ORHAN","ORHON","ORMAN","ORTA","OSMANCA","OYNAK","OZAN","ÖCAL","ÖCALAN","ÖLKER","ÖNAL","ÖNAL MUSALAR",
                "ÖRDEK","ÖREN","ÖRENÇ","ÖRNEK","ÖTER","ÖZ","ÖZALP","ÖZANLAĞAN","ÖZASLAN","ÖZATA","ÖZAYDIN","ÖZBEK","ÖZBEY","ÖZBEYLER","ÖZCAN","ÖZCANLI","ÖZDEMİRKIRAN","ÖZDEN","ÖZDENOĞLU","ÖZER","ÖZER ÇELİK","ÖZGÜNER","ÖZGÜR","ÖZGÜROL","ÖZHAN","ÖZİŞ","ÖZKAN","ÖZKANLI","ÖZKAYA","ÖZKAYNAR","ÖZSAYIM","ÖZSOY","ÖZTAŞ","ÖZTOPRAK","ÖZTÜRK",
                "ÖZTÜRKERİ","ÖZÜAK","ÖZÜDOĞRU","ÖZYÖRÜK","PAKÖZ","PAKSOY","PARA","PARASIZ","PARLAK","PAZIR","PEHLİVAN","PEKDOĞAN","PEKEL","PEKER","PEKGÖZ","PEKTAŞ","PEYNİRCİ","PINARBAŞILI","PIRTI","PİRDOĞAN","PİRİ","PİRİM","PİŞİRGEN","POLAT","POSTALLI","POTA","PULAT","RENÇBER","SAATÇIOĞLU","SABAZ","SAÇLI","SADIÇ","SADUNOĞLU","SAF","SAĞ","SAĞCAN",
                "SAĞDIK","SAĞIR","SAĞLAM","SAK","SAKA","SAKALLI","SAKALLIOĞLU","SAKARYA","SALDIRAY","SALTÜRK","SANCAR","SANDAL","SANHAL","SANSARCI","SARAÇ","SARAL","SARAYLI","SARGIN","SARICANBAZ","SARIÇİÇEK","SARIEKİZ","SARIGÜL","SARIKAYA","SARİ","SARP","SAVAŞ","SAVĞA","SAVRAN","SAYGIN","SAYIN","SAYİNER",
                "SAYYİĞİT","SEÇİR","SEÇKİN","SEĞMEN","SEKİN","SELÇUK","SELİM","SELVAN","SELVİ","SELVİOĞLU","SEMERCİ","SENEMTAŞI","SERBEST","SERİN","SERT","SERTEL","SERTKAYA","SERTKAYAOĞLU","SERTOĞLU","SERVET","SEVEN","SEVER","SEVİMLİ","SEVİNÇ","SEVİNGİL","SEVÜK",
                "SEYHAN","SEYREK","SEYREKOĞLU","SEZEN","SEZER","SEZGİN","SINICI","SİĞA","SİL","SİPAHİ","SİVRİ","SOBAY","SOYDAN","ŞANLIER","ŞANLIKAN","ŞARLAK","ŞAŞMAZ","ŞİRİN","ŞİRZAİ","TACİR","TAHTACI","TALAN","TALAS","TAN","TANİN","TANİŞ","TARAKCI","TARKAN","TARLAN","TAŞ","TAŞAR","TAŞCI","TAŞDELEN","TAŞKIN","TAŞKIRAN","TAŞLI","TAŞMALI",
                "TAŞTEKİN","TATAR","TATLI","TAVŞAN","TAY","TAYFUN","TAYFUR","TAYYAR","TAZEOĞLU","TEĞİN","TEHLİ","TEKER","TEKİN","TEKİNSOY","TEMEL","TEMİZ","TEMLİ","TEMURTAŞ","TEN","TENEKECİ","TEOMAN","TEPE","TEVDİK","TEZEL","TEZER","TOHUMOĞLU","TOKAR","TOKAT","TOKATLIOĞLU","TOKER",
                "TOKMAK","TOKTAŞ","TOLA","TOLU","TOMBUL","TOPAK","TOPAL","TOPALKARA","TOPALOĞLU","TOPCUOĞLU","TOPÇU","TOPER","TOPKARA","TOPRAK","TOPTAŞ","TOPUZ","TOŞUR","TOY","TOYRAN","TOZLU","TÖNGE","TUĞCUGİL","TUNCAY","TUNCEL","TUNCER","TUNÇ","TUNÇAY","TURAÇ","TURAN","TURANOĞLU","TÜRKSOY","TÜRKYILMAZ","TÜTEN","UÇAR","UFACIK","UĞURLU","UĞUZ","ULAŞ","ULU","ULUBA","ULUBAŞOĞLU","ULUÖZ","ULUSOY",
                "ULUTAŞ","URAL","URFALI","URUÇ","USLU","USLUBAŞ","USLUSOY","USTA GÜÇ","USUL","UTLU","UYANIK","UYAR","UYGUR","UYĞUN","UYKUR","UYSAL","UZ","UZUN","UZUNCA","UZUNCAN","ÜÇER","ÜÇGÜL","ÜLGEN","ÜLGER","ÜLKEVAN","ÜNAL","ÜNALAN","ÜNGÜR","ÜNLÜ","ÜNSAL","ÜNÜŞ","ÜNÜVAR","ÜNVER","ÜREYEN","ÜRKMEZ","ÜRÜN","ÜSTÜN","YAKIŞAN",
                "YAKKAN","YAKUT","YALÇIN","YALÇINKAYA","YALINKILIÇ","YALNIZ","YAMAK","YAMAN","YANARDAĞ","YANCAR","YANIK","YANMAZ","YANNİ","YAPAR","YAPRAK","YARADILMIŞ","YARAR","YARBİL","YARDIMCI","YASA","YAYIKÇI","YAZAK","YEGİN","YEL","YENİAY","YENİÇERİ","YENİDOĞAN",
                "YENİDÜNYA","YENİGÜN","YENİLMEZ","YENİN","YERAL","YERLİKAYA","YEŞİL","YEŞİLDAĞER","YEŞİLFİDAN","YEŞİLKAYA","YÖNET","YÖRÜK","YUMAK","YUMURTAŞ","YURDAKÖK","YURDAM","YURDSEVEN","YURT","YURTDAŞ","YURTLU","YÜCE","YÜCEL",
                "YÜKSEL","YÜKSELMİŞ","YÜREK","YÜZBAŞIOĞLU","YÜZER","ZAİM","ZENGİN","ZEYBEK","ZEYLİ","ZİLELİGİL","ZUBAROĞLU"
            };

            string[] FirstNameList = {"Abdullah Arif","Abdullatif","Abdulmelik","Abdulsamet","Abdulselam","Abdulsemet",
                "Abdurrahman","Abdurrahman Fuat","Abdülkadir","Abdülsamet","Abide Merve","Abidin","Adem",
                "Adil","Adnan","Ahmad Taher","Ahmet","Ahmet Ali","Ahmet Bilgehan","Ahmet Burak","Ahmet Can","Ahmet Cevdet","Ahmet Çağrı","Ahmet Emre","Ahmet Furkan","Ahmet Gökhan","Ahmet Kürşad","Ahmet Melih","Ahmet Mert",
                "Ahmet Sercan","Ahmet Serkan","Ahmet Tunç","Ahmetcan","Akın","Aksel","Alaaddin","Alev","Alevtina",
                "Ali","Ali Burç","Ali Haluk","Ali Hasan","Ali Kemal","Ali Muharrem","Ali Ozan","Ali Rıza","Ali Said","Ali Saip",
                "Ali Seçkin","Alişan","Almala Pınar","Alp","Alper","Alperen","Andaç","Anıl","Arda","Arda Nermin","Arif","Arife Esra","Arman",
                "Arzu","Asena","Asım","Asiye Burcu","Aslan","Aslı","Aslıhan","Aslıhan Esra","Asudan Tuğçe","Asuman","Atacan","Atakan","Atılgan","Atilla","Atilla Süleyman","Atiye Meltem","Aybegüm","Aybüke","Aycan","Aycan Özden","Aydemir","Aydın","Aydoğan","Ayhan","Aykan",
                "Aykut","Ayla","Aylia","Aylin","Aylin Sevil","Aysel","Aysu","Aysun","Ayşe","Ayşe Ahsen","Ayşe Ceren","Ayşe Fulya","Ayşe Gizem","Ayşe Gül","Ayşe Gülçin",
                "Ayşe Nur","Ayşe Pınar","Ayşegül","Ayşen","Ayşenur","Aytaç","Aziz","Bahadır","Bahattin","Bahri","Baki","Bala Başak",
                "Baran","Barış","Başak","Baturay Kansu","Baver","Bayram","Bayram Furkan","Bedreddin","Bedri","Bedriye Müge","Begüm",
                "Bekir","Belgin","Belgin Emine","Belma","Bengü","Bengühan","Benhur Şirvan","Beraat","Beray","Berçem","Berfin","Berfin Can","Berfu","Beril Gülüş","Berk","Berkan","Berker","Berna","Berrin","Beste","Betül","Betül Emine","Beyza","Bilal","Bilal Barış","Bilge","Bilge Merve","Bilgi","Bilgin","Binnur","Bireylül","Birgül","Birol","Birsen","Bişar","Bora","Buğra","Bulut","Burak","Burcu","Burçhan","Burçin",
                "Burçin Meryem","Burhan","Burhanettin","Buşra","Bülent","Bünyamin","Büşra","Büşra Sultan","Cafer","Cahit","Can",
                "Canan","Caner","Cansen","Cansu","Cansu Selcan","Cebbar","Cebrail","Cem","Cem Atakan","Cem İnan","Cem Özgür","Cem Yaşar","Cemal",
                "Cemil","Cemile Ayşe","Cemile Çiğdem","Cemre","Cengiz","Cenk","Ceren","Ceren Buğlem","Cevahir","Ceyda","Ceyhan","Ceyhun","Ceylan","Cihan","Coşkun","Cömert","Cuma","Cumhur","Cundullah","Cüneyt","Çağdaş","Çağla","Çağlar","Çağrı","Çağrı Serdar","Çavlan","Çetin","Çiğdem","Çile","Damla","Davut","Demet","Demir","Deniz","Deniz Armağan","Deram","Derman","Derviş","Derya",
                "Derya Pınar","Derya Sema","Dicle","Didem","Didem Ayşe","Dilan","Dilara","Dilber","Dilek","Dilşah",
                "Dinçer Aydın","Doğan","Duçem","Duran","Duygu","Ebru","Ebubekir Onur","Ece","Eda","Edip Güvenç","Efruz","Eftal Murat","Egemen","Ekin",
                "Ekrem","Ela","Elçin","Elif","Elif Ayşe","Elif Ceren","Elif Çiler","Elif Nihal","Elif Nur","Elif Tuğçe","Elifcan","Elzem","Emced","Emel","Emel Cennet",
                "Emin","Emin Tonyukuk","Emine","Emine Ayça","Emine Dilek","Emir Kaan","Emir Murat","Emiş","Emrah","Emrah Kemal","Emre","Emre Kağan","Emre Merter","Emrullah","Ender",
                "Enes","Enes Tahir","Engin","Ennur","Enver","Eray","Ercan","Erdal","Erdem","Erdem Can","Erdinç","Erem","Eren",
                "Ergül","Ergün","Erhan","Erhan Hüseyin","Erkan","Erkan Sabri","Erkin","Erol","Ersagun","Ersen","Ersin","Ertan","Ertunç Onur","Esen","Esen İbrahim","Eser","Esin","Esin Seren","Esma","Esma Özlem","Esmeralda","Esra","Esra Can","Esra Nur","Ethem","Evre","Evren","Evrim","Eylem","Eyüp","Eyüp Gökhan","Eyyup Sabri","Eyyüp",
                "Ezel","Ezgi","Ezgi Gizem","Fadıl","Fadime Sevgi","Fahri","Faik","Faris","Faruk","Fatıma İlay","Fatih","Fatih Avni","Fatih Mehmet","Fatih Nazmi","Fatih Rıfat","Fatma","Fatma Begüm",
                "Fatma Betül","Fatma Duygu","Fatma Ece","Fatma Efsun","Fatma Esin","Fatma Esra","Fatma Selcen","Ferat","Feray",
                "Ferda","Ferdi","Ferhan","Ferhat","Feride","Ferit","Fethi","Fethiye","Fevzi Fırat","Fevziye","Feyza","Feyzahan","Feza","Fırat","Fikri","Filiz","Fuat","Fuat Ernis","Fulya","Funda","Funda Özlem","Füsun","Gamze","Gamze Pınar","Ganim","Gizem","Gonca",
                "Gökay","Gökçe","Gökçen","Gökhan","Gökmen","Gökmen Alpaslan","Göknur","Göksel","Göktekin","Gökten","Görkem","Gözde",
                "Gözde Gizem","Gözde Kübra","Gözdem","Güher","Gül","Gülay","Gülbahar","Gülberat","Gülcan","Gülçin","Güldehen",
                "Gülden","Gülden Sinem","Gülen Ece","Gülhanım","Güliz","Güllü Selcen","Gülname","Gülperi","Gülsen","Gülseren",
                "Gülsüm","Gülşah","Gülşen","Gültekin Günhan","Günay","Gündem","Güneş","Gürkan","Habibe","Habil","Habip","Hacer","Hacı",
                "Hacı Hasan","Hacı Kemal","Hacı Mehmet","Hacı Murat","Hacı Ömer","Haci Halil","Hakan","Hale","Halenur","Halil","Halil Can","Halil Cansun","Halil İbrahim","Halilibrahim","Halim","Halime","Halis","Haluk","Hamdi","Hamdiye","Hamit","Hamza",
                "Handan","Hande","Hanım","Hanife Tuğçe","Harun","Hasan","Hasan Bilen","Hasan Cıvan","Hasan Hüseyin","Hasan Kadir","Hasan Sami","Hasan Serkan","Hasan Ulaş","Hasan Yavuzhan","Hasibe","Hasret","Haşim Onur","Hatice","Hatice Eylül","Hatice Nilden","Hatice Özge","Hatike","Hatun","Havva","Hayati","Hayati Can","Hayri","Hayri Üstün","Hayriye","Hayrunnisa",
                "Hazan","Hazel","Hicran","Hidayet","Hidir","Hikmet","Hikmet Ekin","Hilal","Hilayda","Hisar Can","Huriye","Hülya Gözde","Hümeyra",
                "Hüseyin","Hüseyin Cahit","Hüseyin Kalkan","Hüseyin Kunter","Hüseyin Onur","Hüseyin Said","Hüseyin Yavuz","Irazca","Işık","Işık Melike","Işıl",
                "Işın","İbrahim","İbrahim Barış","İbrahim Fuat","İbrahim Halil","İbrahim Tayfun","İdris","İdris Bugra","İhsan","İhsan Burak","İklil","İkram","İlhan","İlkay","İlker","İlknur","İlyas","İnanç","İnci","İpek","İrem","İrfan","İrfan Yıldırım","İsa","İshak","İsmail","İsmail Evren","İsmail Mikdat",
                "İsmail Şenol","İsmail Yavuz","İtibar","İzzet","İzzettin","Jale","Jülide Zehra","Kaan Suat","Kader","Kadir","Kalender","Kamercan",
                "Kamil","Kamuran","Kasım","Kemal","Kemal Kürşat","Kenan","Kenan Ahmet","Kenan Selçuk","Kerim","Kerime Rumeysa","Kezban","Keziban",
                "Kıvanç","Kıymet","Konuralp","Koray","Korhan","Kubilay","Kurtuluş","Kübra","Kürşat","Lale","Latife","Leman","Levent","Leyla","Leziz","Lütfi","Mahir","Mahmut","Mahmut Arda","Mahmut Bakır","Mahmut Burak","Mahmut Emre","Mahmut Esat","Mahmut Nuri","Mahmut Sami","Mahperi","Mahsum","Makbule Seda","Mansur Kürşad","Maria","Maruf","Mazlum","Mediha","Mehmed Uğur","Mehmet","Mehmet Akif","Mehmet Ali","Mehmet Burhan",
                "Mehmet Cihat","Mehmet Deniz","Mehmet Dirim","Mehmet Emrah","Mehmet Evren","Mehmet Fatih","Mehmet Furkan","Mehmet Gökçe","Mehmet Hazbin","Mehmet Hilmi","Mehmet Hüseyin","Mehmet İkbal","Mehmet Koray",
                "Mehmet Murat","Mehmet Nedim","Mehmet Nuri","Mehmet Özer","Mehmet Özgür","Mehmet Raşit","Mehmet Reşit","Mehmet Selahattin",
                "Mehmet Selami","Mehmet Suphi","Mehmet Şirin","Mehmet Vehbi","Mehmet Veysel","Mehmet Yavuz","Mehmet Yıldırım","Mehmet Ziya","Mehri","Mehtap","Melahat","Melda","Melek","Melia","Meliha Esra","Melike","Melike Elif",
                "Meltem","Meltem Hale","Meral","Meral Leman","Meriç","Merih","Mert","Mert Metin","Merve","Merve Nur","Merve Setenay","Meryem","Mesude","Mesut","Metanet Mehrali","Mete","Mete Can","Metin","Mevlüt","Mevsim","Mihrimah Selcen","Mine","Mine Cansu",
                "Miraç","Miray","Muammer","Muammer Hayri","Muammer Müslim","Muhammed","Muhammed Ali","Muhammed Fatih","Muhammed Furkan","Muhammed Hasan","Muhammed Mucahid","Muhammed Nuri","Muhammed Rıza","Muhammed Sami","Muhammed Taha",
                "Muhammed Yusuf","Muhammet Bağbur","Muhammet Devran","Muhammet Fatih","Muhammet Murat","Muhammet Mustafa","Muhammet Tayyip","Muhlis","Muhsin","Mukadder","Mukaddes",
                "Mumun","Murat","Murat Volkan","Musa","Musacide Zehra","Mustafa","Mustafa Abdullah","Mustafa Ali","Mustafa Alican",
                "Mustafa Arif","Mustafa Asım","Mustafa Baran","Mustafa Buğra","Mustafa Cihad","Mustafa Ersagun","Mustafa Ferhat",
                "Mustafa Gürhan","Mustafa Güvenç","Mustafa Kemal","Mustafa Kürşat","Mustafa Nafiz","Mustafa Raşid","Mustafa Turan","Mustafa Ulaş","Mutlu",
                "Muzaffer","Muzaffer Oğuz","Mübeccel","Müberra","Mücadiye","Mücahit","Mücella","Müjdat","Mümtaz","Mümün Fatih","Mümüne",
                "Münever","Mürsel","Mürselin","Mürşit","Müslim","Müşerref","Nafiye","Nafiz","Nagihan","Nail","Naime Sıla","Nalan","Nazan","Nazım","Nazlı","Nazlı Hilal","Nebi","Nebil","Necip","Necmiye Gül","Nefise","Nejdet","Neslihan","Nesrin","Neşe","Neval","Nevin","Nevriye","Nevroz","Nevzat","Nezaket","Nezih","Nezir","Nihal","Nihan","Nihat","Nihat Berkay","Nilay","Nilgün","Nilüfer","Nimet","Nimet Didem","Nizamettin","Nuh","Numan","Nur","Nur Aleyna","Nuran","Nuray","Nurcan","Nurdan","Nurettin","Nurettin İrem","Nurgül","Nurhan","Nuri",
                "Nuri Anıl","Nurmuhammet","Nursel","Nurullah","Oğuz","Oğuz Kaan","Oğuz Kağan","Oğuzhan","Okan","Oktay","Olcay Başak","Onat","Onur","Onur Kadir","Onur Salih","Orçun","Orgül Derya","Orhan","Orhan Uygar","Orkun","Osman","Osman Bilge",
                "Osman Ersegun","Osman Salih","Osman Turgut","Ozan","Ökkeş","Ökkeş Celil","Ökkeş Yılmaz","Ömer","Ömer Aykut",
                "Ömer Faruk","Ömer Gökhan","Ömer Özkan","Ömür","Önder","Önder Turgut","Övgü Anıl","Övünç","Öykü","Özcan","Özden","Özen",
                "Özen Özlem","Özge","Özgül","Özgür","Özgür Sinan","Özhan","Özkan","Özlem","Öznur","Öztan","Papatya","Pelin",
                "Perver","Pervin","Petek","Pınar","Rabia","Rabia Şebnem","Rahime","Rahime Merve","Rahmi Tuna","Ramazan","Ramazan Ferhad","Rasim","Raşan","Raziye",
                "Recep","Recep Gani","Refaettin","Refik","Remziye","Rengin Aslıhan","Resa","Resul","Reşat","Reşit Volkan","Reyhan","Rezan","Rezzan",
                "Rıdvan","Rıfat","Rifat Can","Rukiye","Rukiye Özden","Rumeysa","Rüştü","Saadet",
                "Saadet Nilay","Sabahattin","Sabri Sefa","Said","Salih","Saliha","Saliha Dilek","Saliha Sanem","Salim","Salman","Samet","Samet Sancar","Sami","Sancar","Sanem Gökçen Merve","Sare","Savaş",
                "Seda Elçim","Sedat","Sedef","Sefa","Seher","Seher Özlem","Selahattin","Selami","Selcen",
                "Selkan Murad","Selma","Sema","Sema Nilay","Semih","Semine","Semra","Sena","Senan","Senem","Serap","Seray","Serçin","Serdal","Serdar","Serdar Bora","Serhan","Serhat","Serhat Burkay","Serkan","Serkan Fazlı","Serpil","Sertaç","Servet","Seval",
                "Sevcan","Sevda","Sevde Nur","Sevgi","Sevgül","Sevil","Sevinç","Seyfi","Seyfi Cem","Seyfullah","Seyhan","Sezai",
                "Sezen","Sezer","Sezgi","Sezgin","Sezin","Sıddıka","Sıdıka","Sibel","Sidar","Simender","Simge","Sinan","Sinan Dinçer","Sinem","Sonay","Soner","Songül","Suat","Sultan","Suna","Süheyla","Süheyla Ayça","Süleyman","Süleyman Serdar","Sümeyra","Sümeyye","Süreyya","Süreyya Burcu","Şadi","Şadiye Selin",
                "Şafak","Şahabettin","Şahika","Şahin","Şahinde","Şebnem","Şehmus","Şenay","Şenol","Şerafettin","Şeref Can","Şerif","Şerife","Şükrü","Tahir","Tahsin Batuhan","Talha","Tamer","Taner","Tansu","Tarkan","Tayfun","Tayfur","Taylan","Taylan Uğur","Tayyar Alp","Tekin","Teslime Nazlı","Tevfik","Tevfik Özgün","Tevhid","Teyfik",
                "Timuçin","Timur","Tolga","Tolga Can","Tolgahan","Tolunay","Tuba","Tuba Hanım","Tufan Akın","Tuğba",
                "Tuğberk","Tuğçe","Tuğra","Tuğrul","Tuğsem","Tuna","Tuncay","Turan","Turgay","Turgay Yılmaz","Turğut","Tülay","Tümay",
                "Türker","Ufuk","Uğur","Uğuray","Ulaş","Umut","Umut Can","Umut Seda","Umut Sinan","Ural","Utku","Uygar","Uysan",
                "Übeydullah","Ülkü","Ülkühan","Ümit","Ümmü Gülsüm","Ümmügülsüm","Ümran","Ünal","Ünsal","Üzeyir","Vahdettin Talha",
                "Vasfiye","Vazir Akber","Vedat","Vehbi","Velat","Veli Çağlar","Veli Enes","Velit","Veysel","Veysi","Volkan","Volkan Onur",
                "Yahya","Yakup","Yakup İlker","Yakup Onur","Yalçın","Yasemin","Yaser","Yasin","Yaşar","Yaşar Barbaros","Yaşar Gökhan","Yaşar Gözde","Yavuz","Yavuz Selim","Yelda","Yeliz","Yener","Yetkin","Yıldıray","Yıldırım","Yıldız","Yılmaz","Yiğit","Yiğit Can","Yunus","Yunus Emre",
                "Yurdagül","Yurdun","Yusuf","Yusuf Alper","Yusuf Emre","Yusuf Kenan","Yusuf Ziya","Yüce","Yücel","Yüksel","Yüksel Uğur","Zafer","Zahide","Zarife","Zehra","Zehra Betül","Zekeriya","Zekeriya Ersin","Zeki","Zekiye Seval","Zeliha","Zerin","Zerrin",
                "Zeynalabidin","Zeynep","Zeynep Ezgi","Zeynep Gökçe","Ziya","Zuhal","Zübeyde","Zühal","Zühal Gülsüm","Zühre","Zühtü Bener","Zülfiye","Zümrüt Ela",

 };

            string[] RolesList = { "Admin","StandartUser" };

            // add Categories
            for(int i=0;i<Categories.Length;i++)
            {
                Category data = new Category()
                {
                    Name= Categories[i]                    
                };
                context.Categories.Add(data);
            }
            context.SaveChanges();
            List<Category> db_CategoryList = context.Categories.ToList();


            // add Fields Of Law
            for (int i = 0; i < FieldsOfLawList.Length; i++)
            {
                FieldsOfLaw data = new FieldsOfLaw()
                {
                    Name= FieldsOfLawList[i]
                };
                context.FieldsOfLaw.Add(data);
            }
            context.SaveChanges();
            List<FieldsOfLaw> db_FieldsOfLawList = context.FieldsOfLaw.ToList();

            // add Roles
            for (int i = 0; i < RolesList.Length; i++)
            {
                AppRole data = new AppRole()
                {
                    Name= RolesList[i]
                };
                context.AppRoles.Add(data);
            }
            context.SaveChanges();
            List<AppRole> db_RoleList = context.AppRoles.ToList();

            // add Admin
            AppUser AdminUser = new AppUser()
            {
                FirstName="Admin",
                LastName="ADMİN",
                UserName="admin",
                Email="admin@admin.com",
                Password="11"               
            };
            context.AppUsers.Add(AdminUser);
            context.SaveChanges();

            var AdminId = context.AppUsers.FirstOrDefault(x => x.UserName == "admin").Id;
            var StandartUserId = context.AppRoles.FirstOrDefault(x=>x.Name== "StandartUser").Id;
            var AdminRoleId = context.AppRoles.FirstOrDefault(x => x.Name == "Admin").Id;

            UserRole ur = new UserRole()
            {
                AppRoleId = AdminRoleId,
                AppUserId = AdminId
            };

            context.UserRoles.Add(ur);
            context.SaveChanges();

            // add Users
            for (int i = 0; i < UserCount; i++)
            {
                AppUser data = new AppUser()
                {
                    FirstName=FirstNameList[FakeData.NumberData.GetNumber(1, FirstNameList.Length-1)],
                    LastName=LastNameList[FakeData.NumberData.GetNumber(1,LastNameList.Length-1)],
                    UserName=$"user_{i}",
                    Password="11",
                    Email=$"user_{i}@abc.com"                   
                };
                context.AppUsers.Add(data);
            }
            context.SaveChanges();

            List<AppUser> db_UserList = context.AppUsers.ToList();

            foreach (var item in db_UserList)
            {
                UserRole data = new UserRole()
                {
                    AppRoleId=StandartUserId,
                    AppUserId=item.Id
                };
                context.UserRoles.Add(data);
            }
            context.SaveChanges();


            // add Blogs
            for (int i = 0; i < BlogCount; i++)
            {
                Blog data = new Blog()
                {
                    Name=FakeData.TextData.GetSentence(),
                    Summary=FakeData.TextData.GetSentences(2),
                    Text=FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(10,20)),
                    CreatedOn=now.AddMinutes(FakeData.NumberData.GetNumber(10,300)),
                    AppUserId=db_UserList[FakeData.NumberData.GetNumber(0, db_UserList.Count()-1 )].Id
                };
                context.Blogs.Add(data);
            }
            context.SaveChanges();
            List<Blog> db_BlogList = context.Blogs.ToList();

            // add BlogCategories
            foreach (var item in db_BlogList)
            {
                int k = FakeData.NumberData.GetNumber(1, db_CategoryList.Count() - 6);

                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    BlogCategory data = new BlogCategory()
                    {
                        BlogId = item.Id,
                        CategoryId=db_CategoryList[k].Id
                    };
                    context.BlogCategories.Add(data);

                    k++;
                }

            }
            context.SaveChanges();

            // add UserAreas
            foreach (var item in db_UserList)
            {
                int k = FakeData.NumberData.GetNumber(1, db_FieldsOfLawList.Count() - 7);

                for (int i = 0; i < FakeData.NumberData.GetNumber(1,6); i++)
                {
                    UserArea data = new UserArea()
                    {
                        AppUserId=item.Id,
                        FieldsOfLawId= db_FieldsOfLawList[k].Id
                    };
                    context.UserAreas.Add(data);

                    k++;
                }
            }
            context.SaveChanges();

            // add Questions
            for (int i = 0; i < QuestionCount; i++)
            {
                string code = CultureInfo.CurrentCulture.TextInfo.ToUpper(FakeData.TextData.GetAlphabetical(2)) + FakeData.NumberData.GetNumber(10000, 99999);
                Question data = new Question()
                {
                    CreatedOn=now.AddMinutes(FakeData.NumberData.GetNumber(1,2500)),
                    FirstName=FirstNameList[FakeData.NumberData.GetNumber(1,FirstNameList.Length-1)],
                    LastName=LastNameList[FakeData.NumberData.GetNumber(1, LastNameList.Length - 1)],
                    Email=FakeData.NetworkData.GetEmail(),
                    Code= String.Join("", code.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).Substring(0).ToUpper(),
                    Subject =FakeData.TextData.GetSentence(),
                    Text=FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(2,5)),
                    FieldsOfLawId=db_FieldsOfLawList[FakeData.NumberData.GetNumber(1,db_FieldsOfLawList.Count()-1)].Id            

                };
                context.Questions.Add(data);
            }
            context.SaveChanges();
            List<Question> db_QuestionList = context.Questions.ToList();

            // add Answers
            foreach (var item in db_QuestionList)
            {
                int k = FakeData.NumberData.GetNumber(2, 37);
                if(k%3==0)
                {
                    Answer data = new Answer()
                    {
                        AppUserId = db_UserList[FakeData.NumberData.GetNumber(1, db_UserList.Count() - 1)].Id,
                        CreatedOn = item.CreatedOn.AddMinutes(FakeData.NumberData.GetNumber(100, 599)),
                        QuestionId = item.Id,
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(2,6))                        
                    };
                    context.Answers.Add(data);

                    if(k%2==0)
                    {
                        Answer data2 = new Answer()
                        {
                            AppUserId = db_UserList[FakeData.NumberData.GetNumber(1, db_UserList.Count() - 7)+1].Id,
                            CreatedOn = item.CreatedOn.AddMinutes(FakeData.NumberData.GetNumber(100, 599)),
                            QuestionId = item.Id,
                            Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(2, 6))
                        };
                        context.Answers.Add(data2);
                    }
                }
            }
            context.SaveChanges();

        }
    }
}
