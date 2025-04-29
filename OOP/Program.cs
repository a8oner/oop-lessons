
using System;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

namespace oop_kullanimi
{
    class OOP2
    {
        static void Main(string[] args)
        {

            #region Class Members

            /*
             Sınıf;namespace içerisinde , dışarısında ve class içerisinde tanımlanabilir.
             class içerisinde (metod ya da property değil sadece class!!)değişkenler oluşturulursa buna "field" denir.  class{int a; , int b;}
             OrnekModelClass w; //bu null'dir.
             Eğer bir değişken class içerisinde field olarak tanımlanıyorsa default değeri verilir,yok eğer class'ta değil metot vs içerisinde tanımlanıyorsa default değer verilmez
             */
            #region Property
            MyClass myClass = new MyClass();
            Console.WriteLine(myClass.Yasi); //get bloğu çalıştı(sadece read var)
            myClass.Yasi = 1;  //set bloğu çalıştı (write var set çalışmalı)
            /*
            Prop için örnek
            Console.WriteLine(myClass.Yasi); 
            myClass.Yasi = 8;  
            
             */
            #endregion
            #region Indexer //Indexer çok kullandığımız bir yapı değil
            /*
             Nesneye indexer özelliği kazandıran,fıtrat olarak property ile birebir aynı olan elemandır
             [erişim belirleyicisi][geri dönüş değeri]this[parametreler]
             {
             get{}  //Indexer'dan veri istenildiğinde tetiklenir
             set{}  //Indexer'a veri gönderildiğinde tetiklenir.Gönderilen veriyi 'value' keywordüyle yakalar.
             }
            */
            MyClass myClass2 = new MyClass();
            myClass2[5]; //buda Indexer kullanımıydı !!!!!!!!!1
            #endregion

            #region Class İçerisinde Tanımlanan Class Sınıf Elemanı mıdır?
            MyClass.MyClass2 m1 = new MyClass.MyClass2();   //class elemanı değildir şekildeki gibi erişebiliriz
            #endregion
            #region Class Elemanlarına Açıklama Satırı Nasıl Eklenir
            MyClass m2 = new MyClass();
            m2.Yasi2 = 1;

            //Tanımladığımız Yasi2'nin üzerine okuduğumuzda eklenen açıklama görülecektir. /// ile açıklama eklenir .
            #endregion

            #region this Keywordü
            #region 1.Sınıfın Nesnesini Temsil Eder
            /*
            MyClass m1= new MyClass();
            MyClass m2 = new MyClass();
             */

            #endregion
            #region 2.Aynı İsimde Field İle Metot Paremetrelerini Ayırmak İçin Kullanılır
            /*
            int a;
            public void X(int a)
            {
               // this.a; //1. a'yı çağırır
            }
            int a;
            public void X(int a)
            {
                //this keywordü ilgili class yapılanmasının o anki nesnesine karşılık gelir.
                a;//this.a ile de çağırabilirdik yani this kullanmak zorunda değiliz
            }
             */

            #endregion
            #region 3.Bir Constructer'dan Başka Bir constructer'ı çağırmak için kullanılır

            #endregion
            #endregion

            #region Nesne oluşturma
            /*
             Type x= new Type(); //sol taraf referans etme sağ taraf ise nesnenin kendisi bu heap'te yer alır, referans ise stack'de
             Type x= new(); //bu şekilde de nesne oluşturulabilr
             =(normalde assign eşitleme operatörüyken burda referans etme yani işaretlemedir)
             Referanssız nesne oluşturabilmekteyiz ama bu nesne sistemde/memory'de lüzumsuz yer kaplayacağından dolayı bir süre sonra Garbage Collector dediğimiz çöp toplayıcısi tarafından temizlenecektir
             GC; heap'te referanssiz olan nesnelerin imha etmekten/temizlemekten sorumlu bir yapılanmadır
             SORU: Referanssız nesnelere nasıl erişilir?
             CEVAP: ancak new MyClass().MyProperty=10; atanır ama daha aşağısında erişmeye çalışmak istersen erişemezsin!!!!
             
             Object Initializer:
             MyClass m = new MyClass() //bu şekilde de nesne oluştururken de atama yapabiliyoruz
            {
            a=5
            MyProperty=10,
            MyProperty2=20,
            MyProperty3=30,
            }; 
             */
            #endregion
            #region Shallow Copy
            /*
             Var olan bir nesnenin, değerin,referansının kopyalanmasıdır.Shallow copy neticesinde eldeki değer çoğaltılmaz.Sadece birden fazla referansla işaretlenmiş olur
             Nesne tek lakin işaretleyen referans sayısı birden fazla
             myClass m1=new myClass();
             (referans)     nesne

             myClass m2=m1; //bu shallow copy'dir 
            //Değer türlü değişkenlerde default davranış deep copydir
             */

            #endregion
            #region Deep Copy
            /*
             MyClass m1 = new MyClass();
             MyClass m2 = m1; //shallow copy'dir m2 değişirse m1 değişir
             MyClass m2 = m1.Clone(); //Deep Copy'dir m2 değişirse m1 değişmez
             */
            #endregion

            #region Encapsulation
            /*
            💡 Encapsulation (Kapsülleme/ Sarmalama) Bir nesne içerisindeki dataların(field’lardaki verilerin) 
            dışarıya kontrollü bir şekilde açılması ve kontrollü bir şekilde veri almasıdır.

             Encapsulation e= new Encapsulation();
            e.A = 12233; //set çalıştı
            Console.WriteLine(e.A);//get çalıştı    
             */


            #endregion
            #region Record
            /*
             * Recordlar değer yöneliklidir nesne değildir .classlarda nesne ön planda recordlarda değer
             * Recordlar değiştirilemez objeler oluşturmamızı sağlamaktadır 
            record MyRecord
             {
                 public int MyProperty{ get;init; } //init'leri Record'da daha fazla kullanırız
             }
             */
            #endregion

            #region Constructor
            /*
             Nesne oluşturmak istediğimizde tetiklenen ilk metottur
             MyClass ob = new MyClass (); // () bu constructor'dir. nesne üretim aşamasında tetiklenmek zorundadır
           *******
                class Constructor
            {
            public Constructor() //bu metod constructor metoddur.geri dönüş değeri olmamalı ve sınıf ile aynı isimde olmalı
            { }
             public Constructor(int a) //aynı isimden birkaç tane metod tanımlandı OVERLOADING oluştu. overloading olması için metodlarda biraz farklılık olmalı isim aynı örneğin parametre farklı
            { }
            }****************

            statik  void  Main ( string [] args )
 {
    new MyClass( 5 ); 
 }

            class MyClass {
  public MyClass() 
  { 
     Console.WriteLine("1.Construtor "); 
   } 
  public MyClass(int a) : this() //bu this diğer constructerlara erişimi sağlar. yani üstteki constructor'a erişir.
  { 
     Console.WriteLine($"2.Construtor : a={a}"); 
  } 
  
 ////ÇIKTI:::::::::::::   1.Construtor SONRA   2.Construtor : a=5 
}

             */
            #region Static Constructor
            /*
             Bir sınıfta nesne üretilirken ilk tetiklenen fonksiyon statik constructordır.

             Constructor ilgili sınıftan her nesne üretilirken tetiklenen fonksiyondur.

             static constructor ise ilgili sınıftan ilk nesne üretilirken tetiklenen fonksiyondur.

             static constructor geri dönüş değeri ve erişim belirleyicisi bildirilmez! ve overloading yapılmaz yani parametre almaz, sınıf ismi ile de aynıdır.
             */
            #endregion

            #endregion

            #region Destructor
            /*
              Destructor / Finalizer Metot : Bir class’tan üretilmiş olan nesne imha edilirken otomatik çağrılan metottur.

                            C# proglamlama dilinde Destructor sadece class yapılanmasında kullanılabilir ve bir class sadece ve sadece bir tane destructor içerebilir.
                            
                            her özel sınıf elamanları olduğu gibi destructor da sınıf ismiyle aynı isimde olan bir fonksiyondur.
                            
                            destructor tanımlayabilmek için ~(tilde) işareti kullanılır.
                            
                            ❓ Peki bir nesne hangi şartlarda kim tarafından imha edilir ?
                            
                            ilgili nesne herhangi bir referans tarafından işaretlenmemelidir.
                            yahut nesnenin oluşturduğu ve kullandığı scope sona ermiştir.
                            yani ilgili nesne bir daha erişilemez hale gelinmelidir.
                            class MyClass
            {
                              ~MyClass()---> Destructor metodu  ~~(alt gr +ü+boşluk)
                             {
                                //...işlemler....
                              }
             }
            
             */

            /*
             class Program{
            static void Main(string[] args)
            {
                X();
                GC.Collect(); //Garbage Collector devreye sokulmuş oldu.
                Console.ReadLine(); 
            }
            static void X()
            {
                MyClass m=new MyClass();
            }

            }

        class MyClass
        {
            public MyClass()
            {
                Console.WriteLine("Nesne üretilmiştir");    
            }

            ~MyClass()
            {
                Console.WriteLine("Nesne imha ediliyor...");
            }
        }

        //Yukardaki işlemlerin sonucunda ÇIKTI::::::
        //Nesne üretilmiştir
        //Nesne imha ediliyor...
             */

            #endregion

            #endregion

            #region Inheritance-Kalıtım
            /*
                  class myClass
             {
                 public myClass(int a)
                 {

                 }
             }
             class myClass2:myClass
             {
                 public myClass2():base(5)//myClass'ta bulunan constructer parametre istiyor.bunu burdan vermemiz gerek!vermediğimizde yukardaki kalıtım işlemi başarısız olur.
                 ama kalıtım veren base class'ta boş constructer varsa 
                 {

                 }
             }
             */
            /* TANIM
            C# dilinde kalıtım sınıflara özeldir.
            yani bir sınıf sadece ve sadece bir sınıftan kalıtım alabilir.
            record’lar kalıtım alabilmekte lakin sadece kendi aralarında kalıtım alabilmektedir. tek istisna sınıf ise Object sınıfı
            Ayrıca; abstract class, interface ve struct gibi yapılarında kendilerine göre kalıtımsal operasyonları mevcuttu.
            ❓ C# ta kalıtım nasıl alınır ?
            
            İki sınıf arasındaki kalıtımsal ilişki kurabilmek için : operatörü kullanılmaktadır.
            Hatta bilsekte bilmesekte kalıtımsal tüm ilişkiler : operatörü tarafından yapılmaktadır.
         
             class Araba
    {
        public string Marka { get; set; }
        public string Model { get; set; }   
        private int KM { get; set; }
    }
             class Opel : Araba : operatoru ile kalıtım yapıldı
    {
    }
        iki nokta ( : )operatörü araba sınıfındaki tüm erişilebilir 
        memberları,Opel sınıfına  kalıtımsal olarak aktarmaktadır. 

             kalıtım, operasyonel olarak gerçekleştirildikten sonra compiler seviyesinde member aktarımı sağlanır!

            ⛔ Yani artık Opel sınıfından bir nesne ürettiğimizde içerisinde Marka ve Model propertyleri kalıtımsal olarak aktarıldığı için erişilebilir olacaktır.
            
            Kalıtım alan sınıfa Derived / Child Class denir (Opel)
            kalıtım veren sınıfa Base / Parent Class denir. (Araba)
            ⛔ Unutma! Bir sınıfın sadece ve sadece tek bir Base class’ ı olabilir. Yani bir sınıfın Base class’ ı direk türediği sınıftır. Lakin atalarındaki tüm sınıflar Base Class’ ı değildir!
            
            ⛔ kalıtımda Bir sınıftan nesne üretilirken biz 1 adet nesne ürettiğimizi düşünsek bile kalıtımsal açıdan birden fazla nesne üretimi gerçekleştirilebilmektedir. Yani ben Araba sınıfından bir nesne ürettiğimde otomatik Opel sınıfı içinde nesne üretmiş oluyor.
            
            📌 Bir sınıftan Base class Constructorına ulaşım
            
            Madem ki, herhangi bir sınıftan ensen üretimi gerçekleştirirken öncelikle base class’ ından nesne üretiliyor, bu demektir ki önce base class’ ın constructor’ ı tetikleniyor.
            Haliyle bizler nesne üretimi esnasında base class’ ta üretilecek olan nesnenin istediğimiz constructor’ larını tetikleyebilmeli yahut varsa parametre bu değerleri verebilmeliyiz.
            işte bunun için base Keywordünü kullamaktayız.
            📌 Temel anahtar kelime ile bu anahtar kelime karşılaştırması
            
            this, bir sınıftaki constructorlar arasında geçiş yapmamızı sağlar.
            base. bir sınıfın base class’ ının constructor’ larından hangisinin tetikleneceğini belirlememizi ve varsa parametrelerinin değerlerinin derived class’tan verilmesini sağlar.
            Ayrıca nasıl ki this, ilgili sınıfta o anki nesnenin memberlarına erişebilmemizi sağlıyor, aynı şekilde base’ de base class’ da ki memberlara erişebilmemizi sağlamaktadır.
            base classda erişilebilir olmayan memberlar base keywordüyle erişilemez!
            
          **this,bir sınıftaki constructer'lar arasında geçiş yapmamızı sağlar
          *aynı zamanda this;ilgili sınıfın elemanlarına erişir: int a, public int property{get;set;},..bunlara erişir... bu şekilde örnekleri çoğaltabiliriz
          **base,bir sınıfın base class'ının constructor'larından hangisinin tetikleneceğini belirlememizi ve varsa parametrelerinin değerlerinin derived class'tan verilmesini sağlar
          *base. diyerek delivered sınıftan base class'a erişim sağlayacağız . public öğelere bu şekilde erişilir
          *
          *Tüm sınıflar OBJECT sınıfından türerler. eğer o sınıf farklı bir sınıftan kalıtım almışsa doğal olarak kalıtım aldığı sınıftan türemiş olur
          *
                  class A
        {
            public int X { get; set; }
        }
        class B
        {
            public int X { get; set; }    B b = new B(); b. //burda name hiding durumu oluştu. oluşan nesne A'dan mı B'den mi çağıracak ?? B'den çağırır A'dakini de gizler.bu durum uyarı verir ama hata vermez!!.new operatörünü kullanmamızı önerir ama zorunlu değildir. B 'de public new int X{get;set;}

        }

             */

            #endregion
            #region Sanal Yapılar
            /*
             Sanal Yapılar Nedir?

             Sanal yapılar, bir sınıf içerisinde bildirilmiş olan ve o sınıftan türeyen alt sınıflarda da tekrar bildirilebilen yapılardır.
             Bu yapılar metot ya da property olabilir.
             Bir sınıfta bildirilen sanal yapı(metot ya da property ) bu sınıftan türeyen torunlarında ezilebilmekte yani devre dışı bırakılıp yeniden oluşturulabilmektedir.
             Yani sanal yapılanmalarda üstten gelen bir yapının işlevini iptal edip yeniden yapılandırmak vardır.
             İşte burada bir sınıfta tasarlanmış sanal yapının işlevinin iptal edilip edilmeme durumuna göre tanımlandığı sınıftan mı yoksa bu sınıfın torunlarından mı çağrılacağının belirlenmesi run time’ da gerçekleşecektir.
             ❓ Sanal Yapılar Ne İçin Kullanılır ?

             Bir sınıfta tanımlanmış olan herhangi bir member’ ın kendisinde türeyen alt sınıflarda Name Hiding durumuna düşmeksizin ezilip / yeniden yazılıp yapılandırılması için kullanılır.
             Bir sınıfta sanal Yapı oluşturabilmek için ilgili member’ ın ( metot ya da property) imzasının virtual keyword’ ü ile işaretlemek yeterlidir.

             public virtual ya da virtual public şeklinde yazılır.

             Normal metot ya da property derleme zamanında çağrılır. Fakat virtual metot ya da property derleme zamanında hangi sınıftan çağrılacağı belli olmadığı için yani alt sınıflarından birinde ezilmiş olma ihtimali olduğu için run time zamanında çağrılır.

                       class MyClass
               {
                   public void MyMethod() { }  // Normal metot
               }
               class MyClass
                   {               
                     public int MyProperty { get; set; }  // Normal property
                   }
               class MyClass
                   {
                       public virtual void MyMethod() { }  // virtual metot
                   }

               class MyClass
                   {
                     virtual public int MyProperty { get; set; } // virtual property
                   }
               class MyClass2 : MyClass
                   {
                       public override void MyMethod() { }  // override edilmiş metot.yukarda virtual edilmeden burda override edilemez ama virtual edildi diye override edilecek diye bir şey yok
                   }


               class Obje
        {
            public virtual void Bilgi()
            {
                Console.WriteLine("Ben bir objeyim.."); 
            }
        }
        class Terlik : Obje
        {
            public override void Bilgi()
            {
                Console.WriteLine("Ben bir objeyim"); //burda override yapıldı ve yukardaki base class'tan metod yıkılarak tekrardan kullanıldı
            }
        }

             */

            #endregion
            #region POLIMORFIZM 
            /*
             İki ya da daha fazla nesnenin tür sınıf tarafından karşılayabilmesidir. / Referans edilebilmesidir.
             Bir başka deyişle;
             Bir nesnenin birden fazla farklı türdeki referans tarafından işaretlenebilmesi polimorfizm’ dir.
             Polimorfizm, bir nesnenin kalıtımsal olarak ilişkisi olan diğer nesnelerin referanslarıyla işaretleyebilmesini sağlar.
             Bir nesnenin, birden fazla referansla işaretlenmesi; o nesnenin, birden fazla türün davranışlarını gösterebilmesini sağlar.
             Nesne tabanlı programlama’ da polimorfizm aralarında kalıtımsal ilişki olan sınıflarda uygulanabilir. Aksi mümkün değildir.

            *Tavuk bir tavuk iken aynı zamanda bir kuştur
            *
               class Program
        {
            static void Main(string[] args)
            {
                Myclass2 m=new Myclass();  //işte bu şekilde normalde farklı bir sınıfı referans gösterme ve bunun şartı olarak da aralarında kalıtım bağlantısının olması POLIMORFIZM'dir
                Myclass m=new Myclass(); //iki farklı sınıftan referans aldı .bu polimorfizmdir            
            }
        }

        class Myclass2
        {

        }
        class Myclass:Myclass2
        {

        }
            Önemli***
            A a =new C(); //A base class olsun C de A dan kalıtım alsın
            C c=(C)a; //bu şekilde a nesnesi c ile referans edildi. ama C c=a; ile referans edilemezdi
           
            object i=123;
            int i2=(int)i; //bu şekilde i int türünde referans edildi.buna unboxing deniliyordu
            
            ### as operatörü
            A a= new C();
            C c = a as C; // C c =(C) a; yerine bu şekilde işaretleme yapılabilir. 

             */

            #endregion
            #region Nesneler Arası İlişki Türleri //**************// TEKRARDA BURDA KALDIM
            /*
             is -a ilişkisi : Tamamıyla kalıtımla alakalıdır.

             Örnek A : B → A is a B gibi gösterilir. yani A sınıfı B den kalıtılmıştır.
             
             has — a ilişkisi : Bir sınıfın başka bir sınıfın nesnesine dair sahiplik ifadesinde bulunan ilişkidir. Bir yandan kompozisyon/ composition ilişkisi de demektir.
             
             Örnek OPEL has a MOTOR Yani Opel arabasının motoru vardır.

             can — do ilişkisi : İnterface yapılanmasının getirisi olan bir ilişki türüdür.
             Association > Aggregation > Composition 

             */
            #region Association Nedir
            /*
             Association Nedir?
             Sınıflar arasındaki bağlantılarının zayıf biçimine verilen addır. Yani sınıflar kendi aralarında ilişkilidir lakin birbirlerinden de bağımsızdır.
             Parça bütün ilişkisi yoktur.
             Örneğin; bir otobüsteki yolcular ile otobüs arasındaki ilişkisi Association’ dır. Nihayetinde hepsi aynı yönde gitmektedir. Lakin bir yolcu indiğinde bu durum otobüsün ve
             diğer yolcularının durumunu değiştirmez.
             */
            #endregion
            #region Aggregation ve Composition Nedir?
            /*
             Aggregation ve Composition Nedir?
             Nesnelerin birleştirilip daha büyük bir nesne yapmaya verilen isimdir.
             yani her ikisi de birleştirilmiş nesnelerden yapma durumlarını ifade eder.
             Her ikisinde de Association’da olmayan parça — bütün ilişkisi söz konusudur.
             Her ikisinde de sahiplik ilişkisi (has- a) vardır.
             Aggregation : Sahip olunan nesnenini, sahip olan nesneden bağımsız bir şekilde var olabilmesi durumudur.

             Composition : Sahip olunan nesnenin, sahip olan nesneden bağımsız bir şekilde var olmaması durumudur.

             Misal; bir araba düşünürsek eğer, bu arabanın tekeri ile vitesi arasındaki ilişki Aggregation ya da Composition açısından değerlendirirsek eğer;

             Bu araba teker olmadan olmaz lakin teker araba olmadan da kendi başına ayrı olarak var olabileceğinden dolayı araba ile teker arasındaki ilişkiye Aggregation’ dır.

             Benzer mantıkla bu araba vites olmadan da olmaz lakin vites araba olmadan bir anlam ifade etmeyeceğinden dolayı araba ile vites arasındaki ilişki Composition’ dır.
             */
            #endregion

            #endregion
            #region sealed Keyword
            /*
             Sealed Keyword’ ü Nedir ?

             Bir sınıfın(ya da recordların) miras vermesini yahut bir başka deyişle başka sınıf tarafından miras alınmasını engelleyen bir keyword’dür.

             Sadece sınıflarda ve sadece ‘ Override’ edilmiş metotlarda kullanılabilir. sınıfın ve metodun başına Sealed keywordü ekleyerek kullanabilirsin

             ❓ Peki bu keywordü nerede kullanabiliriz ?

             Sınıfların davranışlarını korumak istediğimizde
             Performans iyileştirmesi istendiğinde
             Tekli Tasarım Modeli </aside>
            sealed class A{}
            class B:A{} //burda hata verir. çünkü A class'ı sealed ile işaretlendi
             */
            #endregion
            #region ÖZET
            #region this keywordü
            /*
              new MyClass(3, "");
             class MyClass
         {
             public int MyProperty { get; set; }
             public MyClass()
             {
                 Console.WriteLine("Boş constructor");
             }
             public MyClass(int a) : this() //burdaki this() boş parametreli this çalıştırılarak da yukardaki çalışacak sonra aşağı inilecek. halbuki yukarda new MyClass(3, ""); çağrılmıştı yani 
            en alttaki fonksiyonun çalışması gerekiyordu . işte this keywordü devreye girdi ve yönlendirme yaptı..
             {
                 Console.WriteLine("a parametreli constructor");
             }
             public MyClass(int a, string b) : this(a) //burda this keywordü kullanılarak yukardaki int a parametreli fonksiyon önce çalışacak
             {
                 Console.WriteLine("a ve b parametreli constructor");
             }
         }
             */
            #endregion
            #region base
            /*
             * base keywordü , base class'daki constructer'lardan seçim yapmamızı sağlar
             * base keywordü her zman çağırmak zorunda değiliz kalıtım bağıntısı varsa normal base classtaki metod çağrıldığında problem olmaz. base.metod.. şeklinde de çağırabilriiz
             base keywordü kullanılan class bir yerden kalıtım almıyorsa bu base default object'a yönlendirilir
            class Myclass{
            public Myclass(){
            base.    :>>>>> object'ten türer.yani objektte ne varsa onları getirir
            
            }
            }
             */
            #endregion
            #endregion
            #region Partial Yapılanmalar
            /*
             Partial yapılanmaları genellikle aşağıdaki amaçlar doğrultusunda tercih etmekteyiz;
     ** Kod Bölümleme
          Büyük ve karmaşık yapıdaki sınıfları daha okunabilir ve düzenlenebilir parçalara bölmek için kullanılabilir.
          class A { }            
            partial class A { }
            partial class A { }
     ** İş Bölümü
          Ekiplerin, aynı sınıfın farklı kısımlarını ayni anda geliştirebilmeleri için kullanılabilir.
          class A { }
        partial class A { } 
        partial class A { }
     **  Code Generator
          Code Generator sistemleri tarafından yazdığınız kodun ezilmemesi için kullanılabilir.

    **  Partial yapılanmalarda aşağıdaki kısıtlama durumları söz konusu olabilir;
               Parça olması amaçlanan tüm yapılar partial keyword'ü ile işaretlenmelidir.
               İç içe partial türler kullanılabilir. 
               Tüm partial yapılar ayni namespace altinda bulunmalıdır. Farklı projeler yahut
               modüllere yayılamaz!
               partial olan bir yapının tüm parçalarının türleri ve isimleri aynı olmak zorundadır. 

             partial class MyClass
             {
            partial class MyClass2
               {
               }
             }
            partial class MyClass
           {
              partial class MyClass2
            {

            }
           }
***Neler Partial Olarak Tasarlanabilir???
*class,struct,record,interface, abstract class(ama partial keywordü class'tan hemen önce gelmeli)

            *************
            *Partial metotlarla ilgili aşağıdaki ekstra bilgileri bilmekte fayda vardır;
                 partial metotların runtime'da var olacağı kesin değildir. Eğer implementation edilmedilerse
                 partial metotlar derleme sırasında yok sayılırlar.
                 Yukarıdaki durumdan dolayı partial metotlar delegate'ler ile temsil edilemezler.
                 partial metotlar;
                 . ancak partial yapılar içerisinde tanımlanabilirler.
                 geri dönüş tipleri her daim void olmak zorundadır.
                 . static veya generic olabilirler.
                 . out parametresi alamazlar lakin ref parametresi alabilirler.
                 . extern ve virtual olamazlar.
                 Ayni class'lar da olduğu gibi partial metodun hem tanımi hem de gövdesi partial ile işaretlenmelidir.
                 Bir metot imzasina karşılık tanım ve gövde olabilir.
                 Eğer ki partial metotlar başka bir metot tarafından çağrılırlarsa compiler tarafından var oldukları bilinecektir
                 yok eğer çağrılmazlarsa compiler derleme aşamasında ilgili metodu hiç görmeyecektir.
             */
            #endregion

            #region Abstraction Kavramı
            /*
             Abstraction özünde gereksiz işleri ortadan kaldırmak ve yapılacak işlere rahat bir şekilde ulaşmaktır.Gerekli olanı göster , gereksiz olanları gösterme
             Abstraction'ın interface yahut abstract class'larla doğrudan hiçbir ilgisi yoktur.
             evet onlar üzerinden daha rahat örnekleyebiliyoruz ama doğrudan ilgisi yok.abstraction uygularken interface uygulamak zorunda değiliz ama kullanışlıdır 
             */
            #region Abstract Class
            /*
             Abstract class, özünde kalıtımsal davranış göstererek bir sınıf üzerinde İMPLEMENTASYONlar(uygulamak) yapmamızı sağlayan özel bir yapılanmadır
             Abstract class'lar kullanılması zorunlu classlar değil tercihen kullanılır
             GERİSİ SS'DE NOTLAR ŞEKLİNDE DEPOLU
             */
            /* ABSTRACT ÖRNEK1
              abstract class MyAbstract
         {
             public int MyProperty { get; set; }
             abstract public void Z();
             abstract public int X();
         }

         class Abstract2 : MyAbstract //ilk oluşturulduğunda hata verir.ampule tıklandığında tüm implementasyonları otomatik oluşturur.aşağıdakileri otomatik oluşturdu
            yukardaki işlem impletasyondur. kalıtım DEĞİL!!!! ama kalıtımın özelliklerini taşır.fark yok ismi implementasyon
         {
             public override int X()
             {
                 throw new NotImplementedException();
             }

             public override void Z()
             {
                 throw new NotImplementedException();
             }
         }
***virtual ile abstract arasındaki fark: virtual diğer sınıfta override yapılmak zorynda değil ama abstract yapılan sınıf diğer sınıfta override yapılmak zorunda
****abstractta oluşturulan ve implementasyona uğramış sınıfa zoraki ilk classın özellikleri uygulatılır             
             */
            /*ABSTRACT ÖRNEK 2
             public abstract class Hayvan {
               public abstract void SesCikar();
              }

             public class Kopek : Hayvan {
               public override void SesCikar() {
              Console.WriteLine("Hav hav!");
              }
              }

public class Kedi : Hayvan {
  public override void SesCikar() {
    Console.WriteLine("Miyav!");
  }
}

public class MainClass {
  public static void Main(string[] args) {
    Kopek kopek = new Kopek();
    kopek.SesCikar();

    Kedi kedi = new Kedi();
    kedi.SesCikar();
  }
}
             */

            #endregion
            #endregion
            #region Interface
            /*
             C#'ta interface, bir sınıfın sahip olması gereken ortak davranışları tanımlayan bir şablondur. Interfaceler, sınıfların farklı olsalar bile aynı şekilde davranmasını sağlar.

Örneğin, bir IShape interface'i tanımlayabiliriz. Bu interface, bir şeklin sahip olması gereken Draw() ve GetArea() gibi iki yöntemi tanımlar.

C#
public interface IShape
{
    void Draw();
    double GetArea();
}
Kodu kullanırken dikkatli olun. Daha fazla bilgi
Bu interface'i, Circle, Rectangle ve Triangle gibi farklı şekiller için uygulayabiliriz. Her şekil, IShape interface'indeki yöntemleri kendi özel şekilden implemente eder.

C#
public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public void Draw()
    {
        // Circle çizimi
    }

    public double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

public class Rectangle : IShape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        // Rectangle çizimi
    }

    public double GetArea()
    {
        return width * height;
    }
}

public class Triangle : IShape
{
    private double base;
    private double height;

    public Triangle(double base, double height)
    {
        this.base = base;
        this.height = height;
    }

    public void Draw()
    {
        // Triangle çizimi
    }

    public double GetArea()
    {
        return (base * height) / 2;
    }
}
Kodu kullanırken dikkatli olun. Daha fazla bilgi
Bu sınıfları kullanarak, farklı şekilleri aynı şekilde yönetebiliriz. Örneğin, aşağıdaki kod, tüm şekilleri bir döngüde çizer:

C#
public class Program
{
    public static void Main(string[] args)
    {
        // Bir Circle nesnesi oluşturuyoruz
        Circle circle = new Circle(10);

        // Bir Rectangle nesnesi oluşturuyoruz
        Rectangle rectangle = new Rectangle(10, 20);

        // Bir Triangle nesnesi oluşturuyoruz
        Triangle triangle = new Triangle(10, 20);

        // Tüm şekilleri çiziyoruz
        foreach (IShape shape in new[] { circle, rectangle, triangle })
        {
            shape.Draw();
        }
    }
}
Kodu kullanırken dikkatli olun. Daha fazla bilgi
Çıktı:

Circle çizimi
Rectangle çizimi
Triangle çizimi
Interfaceler, OOP'nin temel kavramlarından biridir. Sınıfların daha esnek ve yeniden kullanılabilir olmasını sağlarlar.

İşte interface'lerin bazı avantajları:

Sınıfların farklı olsalar bile aynı şekilde davranmasını sağlarlar.
Sınıfların daha esnek ve yeniden kullanılabilir olmasını sağlarlar.
Geliştirme sürecini daha kolay ve verimli hale getirebilirler.
             */
            /*
             * class nerde tanımlanabiliyorsa interface de orda tanımlanabilir 
             * interface kültüler olarak I harfiyle başlanıp adlandırılır
             * abstract class da temel amac illa imzalama olmayabiliyordu , kalıtımsal amaç da güzetilebiliyordu ama interfacede direk zorlama imzalama 
             
            class MyClass : IMyInterface { 
             public int Z { get => throw new NotImplementedException(); set => throw new
             NotImplementedException();
                 }
             public void X()
                 {
                     throw new NotImplementedException();
                 }
             public void Y(int a)
                 {
                     throw new NotImplementedException();
                 }
             }
             interface IMyInterface
             {
             void X();
             void Y(int a);
             int Z { get; set; }
             }
****INTERFACE'de NORMAL İMPLEMENTASYON YAPILDIĞINDA erişim aracı public olmalıdır
*explicity implementation ile implement edersek erişimi private olmalı
*
  interface ID:IA,IB,IC { } //İnterface'in birden fazla interfaceden inheritance alması
        
        interface IA { }
        interface IB { }
        interface IC { }
            
            interface sınıfında bulunanların implemente edilmesi gereklidir ondan sonra ana sınıfta interface classından farklı elemanlar da oluşturabiliriz
            **********
         explicity implement

***BURASI ÇOK ÖNEMLİ REFERANS İŞLEMİ IA,IB içindeki X fonksiyonları private olduğundan erişim :
            MyClass m= new();
            IA a=m;
            a.X(); //erişim bu şekilde sağlanabilir

            class MyClass: IA,IB
         {
            int IA.X() //dikkat türü private olmalı!!!!
            {
            Console.WriteLine("A-X");
            return 0;
            }
            int IB.X()
            {
            Console.WriteLine("B-X");
            RETURN 1;
            }
         }
            interface IA
            {
            int X();
            }
              interface IB
            {
            int X();
            }
             */

            #endregion
        }

    }

    class Encapsulation
    {
        int a;
        public int A
        {
            get { return a; }
            set { a = value; }
        }
    }
    class MyClass
    {
        int yasi;
        string b;
        #region Full Property
        /*
         Property hangi türden bir field'ı temsil ediyorsa o türden olmalıdır...
         Property temsil ettikleri field'ların isimlerinin başharfi büyük olacak şekilde isimlendirilir
         */

        public int Yasi
        {
            get
            {
                /*
                 Property üzerinden değer talep edildiğinde bu blok tetiklenir
                 Yani değer burdan gönderilir
                 */
                return yasi;
            }
            set
            {
                yasi = value;
            }
        }
        #endregion

        #region Prop Property
        /// <summary>
        /// Bu bir Prop Property'dir
        /// </summary>
        public int Yasi2 { get; set; }

        #endregion
        #region Auto Property Initializers
        /*
         Bir property'nin ilk değerini nesne ayağa kaldırır kaldırmaz aşağıdaki gibi verebiliriz
        class InsanEntity
        {
            public string Adi { get; set; } = "Gençay";
            public string Soyadi { get; set; } = "Yıldız";
            public int Yasi3 { get; set; } = 23;
        }
            Auto property initializers özelliği sayesinde read only olan prop'lara hızlıca değer atanabilmektedir          
         */

        #endregion
        #region ref Readonly property
        string adi = "azat öner";
        public ref readonly string Adi => ref adi;
        /*
         * bunun kullanım amacı classtan nesne oluşturmadan direk çağırabilmemizdir
         */

        #endregion

        #region Indexer //Indexer çok kullandığımız bir yapı değil

        public int this[int a]
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
        #endregion


        class MyClass2
        {
            static void Main(string[] args)
            {

            }
        }

        public MyClass Clone() {
            return (MyClass)this.MemberwiseClone(); //member. bir sınıf içerisinde o sınıftan üretilmiş olan o anki nesneyi clonelar
        }
    }

    class Cuzdan
    {
        int bakiye;
        public int Bakiye
        {
            get
            {
                if (bakiye > 0)
                    return bakiye * 10 / 100;
                return 5;
            }
            set
            {
                if (value < 10)
                    bakiye = value;
                else
                    bakiye = value * 95 / 100;
            }
        }
    }
    public class Person //Property örnek
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    class Main //Property örnek devamı
    {
        static void Main2(string[] args)
        {
            Person person = new Person();
            person.Name = "Azat";
            string name = person.Name;
        }


    }

}

