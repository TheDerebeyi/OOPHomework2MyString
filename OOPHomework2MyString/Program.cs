using System;
using System.ComponentModel.DataAnnotations;

namespace OOPHomework2MyString
{
    class Program
    {
        static void Main(string[] args)
        {
            string mesaj = "Levin, katibin belli ki kendisinin de pek anlamadığı bir tutanağı dura dura okumasını dinedi; fakat Levin, katibin yüzüne bakınca onun ne kadar sevimli, iyi bir insan olduğunu gördü.";
            string mesaj2 = "Bu tutanağı okurken şaşırmasından ve utanmasından anlaşılıyordu.";

            BenimString benimString = new BenimString(mesaj);
            BenimString benimString2 = new BenimString(mesaj2);

            Console.Write("BenimString sınıfı test ediliyor...\n"+
                              "Karakter dizisi: " + mesaj +
                              "\nİkinci karakter dizisi: "+ mesaj2+
                              "\nElemanSayisi(): " + benimString.ElemanSayisi() +
                              "\n\nBirlestir(): ");

            benimString.Birlestir(benimString2);

            Console.Write(benimString.KarakterDizisi +
                              "\n\nİndis 10 iken ArayaGir(): ");

            benimString.ArayaGir(10,mesaj2);

            Console.Write(benimString.KarakterDizisi +
                          "\n\nİndis 10, alınacak karakter sayısı 10 iken DegerAl(): " +
                          benimString.DegerAl(10, 10).KarakterDizisi);

            Console.Write("\n\nTersCevir(): ");



            benimString.TersCevir();
            Console.Write(benimString.KarakterDizisi+
                          "\n\nSıralaAZ(): ");
            string mesaj3 = benimString.KarakterDizisi;
            benimString.SiralaAZ();

            Console.Write(benimString.KarakterDizisi+
                          "\n\nSiralaZA(): ");

            benimString.SiralaZA();

            Console.Write(benimString.KarakterDizisi);
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

        public BenimString(string karakterDizisi)
        {
            _karakterDizisi = karakterDizisi;
        }

        public int ElemanSayisi()
        {
            int sayac = 0;

            foreach (var karakter in _karakterDizisi)
            {
                sayac++;
            }

            return sayac;
        }

        public void Birlestir(BenimString karakterDizisi)
        {
            _karakterDizisi += karakterDizisi.KarakterDizisi;
        }

        public void ArayaGir(int indis, string karakterDizisi)
        {
            _karakterDizisi = DegerAl(0, indis).KarakterDizisi + karakterDizisi + DegerAl(indis, ElemanSayisi() - indis).KarakterDizisi;
        }

        public BenimString DegerAl(int indis, int karakterSayisi)
        {
            string karakterDizisi = "";
            char[] gecici = new char[karakterSayisi];

            for (int i = indis; i < indis + karakterSayisi; i++)
            {
                gecici[i - indis] = _karakterDizisi[i];
            }

            for (int i = 0; i < karakterSayisi; i++)
            {
                karakterDizisi += gecici[i];
            }

            BenimString benimString = new BenimString(karakterDizisi);

            return benimString;
        }

        public BenimString[] DiziyeAyir(char karakter)
        {
            int boyut = 1;

            BenimString[] benimStrings = new BenimString[boyut];

            for (int i = 0; i < ElemanSayisi(); i++)
            {
                if (_karakterDizisi[i] == karakter)
                {
                    BenimString[] gecici = new BenimString[boyut];

                    for (int j = 0; j < boyut; j++)
                    {
                        gecici[j] = benimStrings[j];
                    }

                    boyut++;

                    benimStrings = new BenimString[boyut];

                    for (int j = 0; j < boyut - 1; j++)
                    {
                        benimStrings[j] = gecici[j];
                    }

                    continue;
                }

                benimStrings[boyut - 1].KarakterDizisi += _karakterDizisi[i];
            }

            return benimStrings;
        }

        public char[] CharDiziyeDonustur()
        {
            int elemanSayisi = ElemanSayisi();

            char[] karakterDizisi = new char[elemanSayisi];

            for (int i = 0; i < elemanSayisi; i++)
            {
                karakterDizisi[i] = _karakterDizisi[i];
            }

            return karakterDizisi;
        }

        public int DegerIndis(BenimString benimString)
        {
            int indis = -1;
            bool bulunduMu;

            for (int i = 0; i < ElemanSayisi() - benimString.ElemanSayisi() + 1; i++)
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

        public int DegerIndis(BenimString benimString, int baslangicIndis)
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

        public void SiralaAZ()
        {
            char[] gecici = CharDiziyeDonustur();

            for (int i = 0; i < ElemanSayisi() - 1; i++)
            {
                bool islemYapildiMi = false;

                for (int j = 1; j < ElemanSayisi(); j++)
                {
                    if (gecici[j - 1] > gecici[j])
                    {
                        char charGecici = gecici[j - 1];
                        gecici[j - 1] = gecici[j];
                        gecici[j] = charGecici;
                        islemYapildiMi = true;
                    }
                }

                if (islemYapildiMi)
                {
                    islemYapildiMi = false;
                }
                else
                {
                    break;
                }
            }

            _karakterDizisi = "";

            foreach (var karakter in gecici)
            {
                _karakterDizisi += karakter;
            }
        }

        public void SiralaZA()
        {
            char[] gecici = CharDiziyeDonustur();

            for (int i = 0; i < ElemanSayisi() - 1; i++)
            {
                bool islemYapildiMi = false;

                for (int j = 1; j < ElemanSayisi(); j++)
                {
                    if (gecici[j - 1] < gecici[j])
                    {
                        char charGecici = gecici[j - 1];
                        gecici[j - 1] = gecici[j];
                        gecici[j] = charGecici;
                        islemYapildiMi = true;
                    }
                }

                if (islemYapildiMi)
                {
                    islemYapildiMi = false;
                }
                else
                {
                    break;
                }
            }

            _karakterDizisi = "";

            foreach (var karakter in gecici)
            {
                _karakterDizisi += karakter;
            }
        }

        public void TersCevir()
        {
            char[] gecici = new char[ElemanSayisi()];

            for (int i = 0; i < ElemanSayisi(); i++)
            {
                gecici[i] = _karakterDizisi[ElemanSayisi() - i - 1];
                
            }

            _karakterDizisi = "";

            foreach (var karakter in gecici)
            {
                _karakterDizisi += karakter;
            }
        }
    }
}
