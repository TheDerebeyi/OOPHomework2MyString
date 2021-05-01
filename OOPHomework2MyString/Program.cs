using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace OOPHomework2MyString
{
    class Program
    {
        static void Main(string[] args)
        {
            BenimString benimString = new BenimString("Bu bir örnek cümledir.");

            Console.Write("BenimString sınıfı test ediliyor..." +
                          "\n\n\"Bu bir örnek cümledir.\" cümlesinin eleman sayısı: " + benimString.ElemanSayisi() +
                          "\n\n\"Bu bir örnek cümledir.\" cümlesi ile \" Bu bir ek cümledir.\" cümleleri birleştiriliyor: ");

            benimString.Birlestir(new BenimString(" Bu bir ek cümledir."));

            Console.Write(benimString.KarakterDizisi +
                              "\n\n7. indisten itibaren \"Bu bir örnek cümledir. Bu bir ek cümledir.\" cümlelerine \"ana \" kelimesi ekleniyor: ");

            benimString.ArayaGir(7, new BenimString("ana "));

            Console.WriteLine(benimString.KarakterDizisi +
                          "\n\n\"örnek cümle\" kelimelerinin kaçıncı indiste olduğu hesaplanıyor: " +
                          benimString.DegerIndis(new BenimString("örnek cümle")) +
                          "\n\n\"Bu bir ana örnek cümledir. Bu bir ek cümledir.\" cümlelerinden indis 11'den itibaren 11 karakter alınıyor: " +
                          benimString.DegerAl(11, 11).KarakterDizisi +
                          "\n\n\"Bu bir ana örnek cümledir. Bu bir ek cümledir.\" cümlesinin ters çevrilmiş hali: " +
                          benimString.TersCevir().KarakterDizisi +
                          "\n\n\"Bu bir ana örnek cümledir. Bu bir ek cümledir.\" cümlesinin A'dan Z'ye sıralı hali: " +
                          benimString.SiralaAZ().KarakterDizisi +
                          "\n\n\"Bu bir ana örnek cümledir. Bu bir ek cümledir.\" cümlesinin Z'den A'ya sıralı hali: " +
                          benimString.SiralaZA().KarakterDizisi +
                          "\n\nc boşluklara göre ayrılarak yazdırılıyor: ");

            benimString.KarakterDizisi = "Bu bir ana örnek cümledir.";

            foreach (var karakterDizisi in benimString.DiziyeAyir(' '))
            {
                Console.WriteLine(karakterDizisi.KarakterDizisi);
            }

            Console.Write("\n\n\"Bu bir ana örnek cümledir.\" cümlesi char[] tipine dönüştürülerek yazdırılıyor: ");

            foreach (var karakter in benimString.CharDiziyeDonustur())
            {
                Console.Write(karakter);
            }
        }
    }

    class BenimString
    {
        private string _karakterDizisi = "";

        public string KarakterDizisi
        {
            get { return _karakterDizisi; }
            set { _karakterDizisi = value; }
        }

        public BenimString()
        {
            _karakterDizisi = "";
        }

        public BenimString(string karakterDizisi)
        {
            _karakterDizisi = karakterDizisi;
        }

        public BenimString(char[] karakterDizisi)
        {
            foreach (var karakter in karakterDizisi)
            {
                _karakterDizisi += karakter;
            }
        }

        public int ElemanSayisi()
        {
            int sayac = 0;

            foreach (var karakter in _karakterDizisi)       //Karakter dizisinin elemanları teker teker gezilecek, her adımda sayaç bir arttırılacak. Sayaç karakter sayısını verecektir.
            {
                sayac++;
            }

            return sayac;
        }

        public void Birlestir(BenimString karakterDizisi)
        {
            _karakterDizisi += karakterDizisi.KarakterDizisi;
        }

        public void ArayaGir(int indis, BenimString karakterDizisi)
        {
            _karakterDizisi = DegerAl(0, indis).KarakterDizisi + karakterDizisi.KarakterDizisi + DegerAl(indis, ElemanSayisi() - indis).KarakterDizisi;
        }

        public BenimString DegerAl(int indis, int karakterSayisi)
        {
            string karakterDizisi = "";
            char[] gecici = new char[karakterSayisi];

            for (int i = indis; i < indis + karakterSayisi; i++)   //Girilen indisten başlayarak girilen karakter sayısı kadar karakter geçici karakter dizisine yazdırılıyor.
            {
                gecici[i - indis] = _karakterDizisi[i];
            }

            for (int i = 0; i < karakterSayisi; i++)               //Karakter dizisi string'e dönüştürülüyor.
            {
                karakterDizisi += gecici[i];
            }

            BenimString benimString = new BenimString(karakterDizisi);

            return benimString;
        }

        public BenimString[] DiziyeAyir(char karakter)
        {
            int boyut = 1;                                          //Diziye bir eleman ekleneceğinde diziyi baştan önceki boyutunun bir fazlası boyutunda tekrar oluşturacağız.

            BenimString[] benimStrings = new BenimString[boyut];

            benimStrings[0] = new BenimString();

            for (int i = 0; i < ElemanSayisi(); i++)                //Tüm karakter dizisi geziliyor.
            {
                if (_karakterDizisi[i] == karakter)                 //Girilen karakter, dizinin i. indisindeki karaktere eşit mi kontrol ediliyor.
                {
                    BenimString[] gecici = new BenimString[boyut];

                    for (int j = 0; j < boyut; j++)                 //Eğer eşit ise bundan sonraki karakterleri bir sonraki elemana yazdırmamız gerek. Oluşturulan geçici dizisine eski dizi kopyalanıyor.
                    {
                        gecici[j] = benimStrings[j];
                    }

                    boyut++;

                    benimStrings = new BenimString[boyut];          //Eski boyutun bir fazlası boyutundaki dizimiz tekrar oluşturuluyor.

                    for (int j = 0; j < boyut - 1; j++)             //Geçici diziye attığımız değerler tekrar yeni oluşturulan diziye yazdırılıyor.
                    {
                        benimStrings[j] = gecici[j];
                    }

                    benimStrings[boyut - 1] = new BenimString();

                    continue;
                }

                benimStrings[boyut - 1].KarakterDizisi += _karakterDizisi[i];   //Eğer eşit değilse mevcut elemana karakter ekleniyor.
            }

            return benimStrings;
        }

        public char[] CharDiziyeDonustur()
        {
            int elemanSayisi = ElemanSayisi();

            char[] karakterDizisi = new char[elemanSayisi];

            for (int i = 0; i < elemanSayisi; i++)                  //Stringin tüm elemanları string ile aynı boyutlu bir diziye yazdırılıyor.
            {
                karakterDizisi[i] = _karakterDizisi[i];
            }

            return karakterDizisi;
        }

        public int DegerIndis(BenimString benimString)
        {
            int indis = -1;                                         //Eğer girilen değer bulunamazsa -1 döndürecek.
            bool bulunduMu;

            for (int i = 0; i < ElemanSayisi() - benimString.ElemanSayisi() + 1; i++)           //Girilen değerin karakter sayısı kadar gruplar halinde tüm string taranıyor.
            {
                bulunduMu = true;
                for (int j = 0; j < benimString.ElemanSayisi(); j++)                            //Harf harf mevcut stringten seçilen grup ile girilen string karşılaştırılıyor.
                {
                    if (_karakterDizisi[i + j] != benimString.KarakterDizisi[j])                //Eğer bir harfte bile eşleşme sağlanmadıysa bulunduMu değişkenine false atanıyor.
                    {
                        bulunduMu = false;
                    }
                }

                if (bulunduMu)                                                                  //Eğer bulunduMu'ya false atadıysak seçilen grup girilen string ile eş değil demektir. bulunduMu kontrol ediliyor.
                {
                    indis = i;                                                                  //Eğer tamamen eşlenme sağlanmış ise i değeri seçilen grubun başladığı nokta olarak fonksiyonun geri döndüreceği int değeri olacak.
                    break;
                }
            }

            return indis;
        }

        public int DegerIndis(BenimString benimString, int baslangicIndis)                  //DegerIndis fonksiyonunun girilen bir indisten aramaya başlayan versiyonu.
        {
            int indis = -1;
            bool bulunduMu;

            for (int i = baslangicIndis; i < ElemanSayisi() - benimString.ElemanSayisi() + 1; i++)
            {
                bulunduMu = true;
                for (int j = 0; j < benimString.ElemanSayisi(); j++)
                {
                    if (_karakterDizisi[i + j] != benimString._karakterDizisi[j])
                    {
                        bulunduMu = false;
                    }
                }

                if (bulunduMu)
                {
                    indis = i;
                    break;
                }
            }

            return indis;
        }

        public BenimString SiralaAZ()
        {
            char[] gecici = CharDiziyeDonustur();

            for (int i = 0; i < ElemanSayisi() - 1; i++)     //Bubble sort kullanılacaktır. n-1 kere döngü en kötü senaryoda çalışacaktır.
            {
                bool islemYapildiMi = false;                 //İşlem yapılmadığında döngünün o adımında artık karakterler zaten sıralı demektir. Bunu ölçmek için islemYapildiMi degiskeni kullanılıyor.

                for (int j = 1; j < ElemanSayisi(); j++)    //Tüm karakterler gezilecek.
                {
                    if (gecici[j - 1] > gecici[j])          //Eğer ki dizide sonraki karakter dizide seçilen karakterden büyük ise yer değiştirme işlemi yapılacaktır. Karakterlerin ASCII karşılıkları karşılaştırılmaktadır.
                    {
                        char charGecici = gecici[j - 1];
                        gecici[j - 1] = gecici[j];
                        gecici[j] = charGecici;
                        islemYapildiMi = true;
                    }
                }

                if (islemYapildiMi)                         //Döngünün bu adımında işlem yapılıp yapılmadığı kontrol ediliyor.
                {
                    islemYapildiMi = false;
                }
                else
                {
                    break;
                }
            }

            BenimString benimString = new BenimString(gecici);

            return benimString;
        }

        public BenimString SiralaZA()
        {
            char[] gecici = CharDiziyeDonustur();

            for (int i = 0; i < ElemanSayisi() - 1; i++)     //Bubble sort kullanılacaktır. n-1 kere döngü en kötü senaryoda çalışacaktır.
            {
                bool islemYapildiMi = false;                 //İşlem yapılmadığında döngünün o adımında artık karakterler zaten sıralı demektir. Bunu ölçmek için islemYapildiMi degiskeni kullanılıyor.

                for (int j = 1; j < ElemanSayisi(); j++)     //Tüm karakterler gezilecek.
                {
                    if (gecici[j - 1] < gecici[j])           //Eğer ki dizide sonraki karakter döngüde seçilen karakterden küçük ise yer değiştirme işlemi yapılacaktır. Karakterlerin ASCII karşılıkları karşılaştırılmaktadır.
                    {
                        char charGecici = gecici[j - 1];
                        gecici[j - 1] = gecici[j];
                        gecici[j] = charGecici;
                        islemYapildiMi = true;
                    }
                }

                if (islemYapildiMi)                         //Döngünün bu adımında işlem yapılıp yapılmadığı kontrol ediliyor.
                {
                    islemYapildiMi = false;
                }
                else
                {
                    break;
                }
            }

            BenimString benimString = new BenimString(gecici);

            return benimString;
        }

        public BenimString TersCevir()
        {
            char[] gecici = new char[ElemanSayisi()];

            for (int i = 0; i < ElemanSayisi(); i++)        //Tüm string geziliyor.
            {
                gecici[i] = _karakterDizisi[ElemanSayisi() - i - 1];        //String'in son elemanından başlanarak her eleman bir gecici diziye yazdırılıyor.

            }


            BenimString benimString = new BenimString(gecici);

            return benimString;

            //_karakterDizisi = "";                                        //String sıfırlanıyor.

            //foreach (var karakter in gecici)                        //Geçici dizideki tüm karakterler stringe ekleniyor.
            //{
            //    _karakterDizisi += karakter;
            //}
        }
    }
}
