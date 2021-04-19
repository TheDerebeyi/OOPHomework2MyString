using System;
using System.ComponentModel.DataAnnotations;

namespace OOPHomework2MyString
{
    class Program
    {
        static void Main(string[] args)
        {
            BenimString benimString = new BenimString("Ami?");
            char[][] well = benimString.DiziyeAyir(' ');
            for (int i = 0; i < well.GetUpperBound(0)+1; i++)
            {
                for (int j = 0; j < well[i].Length; j++)
                {
                    Console.Write(well[i][j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            BenimString bbenimString = new BenimString("A");
            Console.WriteLine(benimString.DegerIndis(bbenimString,0));
        }
    }

    class BenimString
    {
        public char[] _karakterDizisi = new char[0];

        public BenimString(string String)
        {
            int sayac = 0;

            foreach (var karakter in String)
            {
                sayac++;
            }

            _karakterDizisi = new char[sayac];

            for (int i = 0; i < sayac; i++)
            {
                _karakterDizisi[i] = String[i];
            }
        }
        public BenimString(char[] String)
        {
            _karakterDizisi = String;
        }
        public BenimString(BenimString benimString)
        {
            _karakterDizisi = benimString._karakterDizisi;
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

        public void Birlestir(BenimString benimString)
        {
            char[] gecici = new char[ElemanSayisi() + benimString.ElemanSayisi()];

            for (int i = 0; i < ElemanSayisi(); i++)
            {
                gecici[i] = _karakterDizisi[i];
            }

            for (int i = ElemanSayisi(); i < ElemanSayisi() + benimString.ElemanSayisi(); i++)
            {
                gecici[i] = benimString._karakterDizisi[i - ElemanSayisi()];
            }

            _karakterDizisi = gecici;
        }
        public void Birlestir(string _string)
        {
            char[] gecici = new char[ElemanSayisi() + _string.Length];

            for (int i = 0; i < ElemanSayisi(); i++)
            {
                gecici[i] = _karakterDizisi[i];
            }

            for (int i = ElemanSayisi(); i < ElemanSayisi() + _string.Length; i++)
            {
                gecici[i] = _string[i - ElemanSayisi()];
            }

            _karakterDizisi = gecici;
        }
        public void Birlestir(char[] karakterDizisi)
        {
            char[] gecici = new char[ElemanSayisi() + karakterDizisi.Length];

            for (int i = 0; i < ElemanSayisi(); i++)
            {
                gecici[i] = _karakterDizisi[i];
            }

            for (int i = ElemanSayisi(); i < ElemanSayisi() + karakterDizisi.Length; i++)
            {
                gecici[i] = karakterDizisi[i - ElemanSayisi()];
            }

            _karakterDizisi = gecici;
        }

        public void ArayaGir(int indis, string _string)
        {
            char[] gecici = new char[ElemanSayisi() + _string.Length];

            for (int i = 0; i < indis; i++)
            {
                gecici[i] = _karakterDizisi[i];
            }

            for (int i = indis; i < indis + _string.Length; i++)
            {
                gecici[i] = _string[i - indis];
            }

            for (int i = indis + _string.Length; i < ElemanSayisi() + _string.Length; i++)
            {
                gecici[i] = _karakterDizisi[i - indis - _string.Length];
            }

            _karakterDizisi = gecici;
        }
        public void ArayaGir(int indis, BenimString benimString)
        {
            char[] gecici = new char[ElemanSayisi() + benimString.ElemanSayisi()];

            for (int i = 0; i < indis; i++)
            {
                gecici[i] = _karakterDizisi[i];
            }

            for (int i = indis; i < indis + benimString.ElemanSayisi(); i++)
            {
                gecici[i] = benimString._karakterDizisi[i - indis];
            }

            for (int i = indis + benimString.ElemanSayisi(); i < ElemanSayisi() + benimString.ElemanSayisi(); i++)
            {
                gecici[i] = _karakterDizisi[i - indis - benimString.ElemanSayisi()];
            }

            _karakterDizisi = gecici;
        }

        public void ArayaGir(int indis, char[] karakterDizisi)
        {
            char[] gecici = new char[ElemanSayisi() + karakterDizisi.Length];

            for (int i = 0; i < indis; i++)
            {
                gecici[i] = _karakterDizisi[i];
            }

            for (int i = indis; i < indis + karakterDizisi.Length; i++)
            {
                gecici[i] = karakterDizisi[i - indis];
            }

            for (int i = indis + karakterDizisi.Length; i < ElemanSayisi() + karakterDizisi.Length; i++)
            {
                gecici[i] = _karakterDizisi[i - indis - karakterDizisi.Length];
            }

            _karakterDizisi = gecici;
        }

        public BenimString DegerAl(int indis, int karakterSayisi)
        {
            char[] gecici = new char[karakterSayisi];

            for (int i = indis; i < indis+karakterSayisi; i++)
            {
                gecici[i - indis] = _karakterDizisi[i];
            }

            BenimString benimString = new BenimString(gecici);

            return benimString;
        }

        public char[][] DiziyeAyir(char karakter)
        {
            int indis1 = 0, indis2 = 0;

            char[][] gecici1 = new char[indis1+1][], gecici2;
            gecici1[indis1] = new char[indis2];

            foreach (var _karakter in _karakterDizisi)
            {
                if (karakter != _karakter)
                {
                    gecici2 = new char[1][]; 
                    gecici2[0] = gecici1[indis1];
                    gecici1[indis1] = new char[indis2 + 1];

                    for (int j = 0; j < gecici2[0].Length; j++)
                    {
                        gecici1[indis1][j] = gecici2[0][j];
                    }
                    
                    gecici1[indis1][indis2] = _karakter;

                    indis2++;
                }
                else
                {
                    indis1++;
                    indis2 = 0;

                    gecici2 = gecici1;
                    gecici1 = new char[indis1+1][];

                    for (int i = 0; i < indis1; i++)
                    {
                        gecici1[i] = new char[gecici2[i].Length];
                    }

                    for (int i = 0; i < gecici2.GetUpperBound(0)+1; i++)
                    {
                        for (int j = 0; j < gecici2[i].Length; j++)
                        {
                            gecici1[i][j] = gecici2[i][j];
                        }
                    }

                    gecici1[indis1] = new char[0];
                }
            }

            return gecici1;
        }

        public char[] CharDiziyeDonustur()
        {
            return _karakterDizisi;
        }

        public int DegerIndis(BenimString benimString, int indis)
        {
            int _indis = -1;
            bool bulunduMu;

            for (int i = indis; i < ElemanSayisi()-benimString.ElemanSayisi()+1; i++)
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
                    _indis = i;
                    break;
                }
            }

            return _indis;
        }

        public void SiralaAZ()
        {

        }

        public void SiralaZA()
        {

        }

        public void TersCevir()
        {
            char[] gecici = new char[ElemanSayisi()];

            for (int i = ElemanSayisi(); i > 0; i--)
            {
                for (int j = 0; j < ElemanSayisi(); j++)
                {
                    gecici[j] = _karakterDizisi[i];
                }
            }

            _karakterDizisi = gecici;
        }
    }
}
