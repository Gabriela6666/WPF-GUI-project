using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Zespol_projekt
{
    public abstract class Osoba
    {
        private string imie;
        public string Imie
        {
            get
            { 
                return imie;
            }
            set 
            { 
                imie = value;
            }
        }
        public string Nazwisko { get; set; }
        private DateTime dataUrodzenia;
        public DateTime DataUrodzenia
        { 
            get => dataUrodzenia;
            set => dataUrodzenia = value; 
        }
        private string pesel;
        public string PESEL
        {
            get
            {
                return pesel;
            }
            set
            {
                pesel = value;
            }
        }
        private Plcie plec;
        public Plcie Plec
        {
            get
            {
                return plec;
            }
            set
            {
                plec = value;
            }
        }
        public Osoba()
        {
            Imie = "Imię";
            Nazwisko = "Nazwisko";
            DataUrodzenia = DateTime.Today;
            PESEL = "00000000000";
        }
        public Osoba(string imie_1, string nazwisko_1)
        {
            Imie = imie_1;
            Nazwisko = nazwisko_1;
        }
        public Osoba(string imie_1, string nazwisko_1, string data_urodzenia_1, string PESEL_1, Plcie plec_1)
        {
            Imie = imie_1;
            Nazwisko = nazwisko_1;
            PESEL = PESEL_1;
            Plec = plec_1;
            DateTime data;
            DateTime.TryParseExact(data_urodzenia_1, new[] {"yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yyyy"}, null, System.Globalization.DateTimeStyles.None, out data);
            DataUrodzenia = data;
        }
        public int Wiek()
        {
            return DateTime.Now.Year - DataUrodzenia.Year;
        }
        new virtual public void ToString()
        {
            Console.WriteLine(PESEL);
            Console.WriteLine(Imie);
            Console.WriteLine(Nazwisko + " (" + Wiek() + ")");
        }
        public class CzlonekZespolu : Osoba, ICloneable, IComparable<CzlonekZespolu>
        {
            DateTime dataZapisu;
            public DateTime DataZapisu
            {
                get
                {
                    return dataZapisu;
                }
                set
                {
                    dataZapisu = value;
                }
            }
            string funkcja;
            public string Funkcja
            {
                get
                {
                    return funkcja;
                }
                set
                {
                    funkcja = value;
                }
            }
            public CzlonekZespolu()
            {

            }
            public CzlonekZespolu(string imie_1, string nazwisko_1, string data_urodzenia_1, string PESEL_1, Plcie plec_1, string funkcja_1, string dataZapisu_1)
            {
                Imie = imie_1;
                Nazwisko = nazwisko_1;
                PESEL = PESEL_1;
                Plec = plec_1;
                DateTime data;
                DateTime.TryParseExact(data_urodzenia_1, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out data);
                DataUrodzenia = data;
                Funkcja = funkcja_1;
                DateTime.TryParseExact(dataZapisu_1, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out data);
                DataZapisu = data;
            }
            override public void ToString()
            {
                StringBuilder linia = new StringBuilder();
                linia.Append(Imie + " ");
                linia.Append(Nazwisko + " (" + Wiek() + ")" + " ");
                linia.Append(Plec + " ");
                linia.Append(PESEL + " ");
                linia.Append(Funkcja + " ");
                DateTime d = DataZapisu;
                string d_day = Convert.ToString(d.Day);
                string d_month = Convert.ToString(d.Month);
                string d_year = Convert.ToString(d.Year);
                if (d_month.Length == 1)
                {
                    d_month = "0" + Convert.ToString(d.Month);
                }
                if (d_day.Length == 1)
                {
                    d_day = "0" + Convert.ToString(d.Day);
                }
                string d_z = d_year + "-" + d_month + "-" + d_day;
                linia.Append(d_z);
                Console.WriteLine(linia);
            }

            public object Clone()
            {
                var cz_z = (CzlonekZespolu) MemberwiseClone();
                return cz_z;
            }

            public int CompareTo(CzlonekZespolu cz_z)
            {
                string I_cz = cz_z.Imie;
                string N_cz = cz_z.Nazwisko;
                string I = this.Imie;
                string N = this.Nazwisko;

                int dl_i = Math.Min(I.Length, I_cz.Length);
                int dl_n = Math.Min(N.Length, N_cz.Length);

                if (this.Imie == cz_z.Imie)
                {
                    int prawda = 0;

                    for (int i = 0; i < dl_n; i++)
                    {
                        if ((int)N[i] != (int)N_cz[i])
                        {
                            if ((int)N[i] < (int)N_cz[i])
                            {
                                prawda = 1;
                                break;
                            }
                            else
                            {
                                prawda = -1;
                                break;
                            }
                        }
                    }

                    if (prawda == 0)
                    {
                        if (N.Length < N_cz.Length)
                        {
                            prawda = 1;
                        }
                        else
                        {
                            prawda = -1;
                        }
                    }

                    if (prawda == 1)
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    int prawda = 0;

                    for(int i = 0; i < dl_i; i++)
                    {
                        if((int)I[i] != (int)I_cz[i])
                        {
                            if ((int)I[i] < (int)I_cz[i])
                            {
                                prawda = 1;
                                break;
                            }
                            else
                            {
                                prawda = -1;
                                break;
                            }
                        }
                    }

                    if(prawda == 0)
                    {
                        if(I.Length < I_cz.Length)
                        {
                            prawda = 1;
                        }
                        else
                        {
                            prawda = -1;
                        }
                    }

                    if(prawda == 1)
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                }
            }
        }

        public class KierownikZespolu : Osoba, ICloneable
        {
            int doswiadczenie;
            public int Doswiadczenie
            {
                get
                {
                    return doswiadczenie;
                }
                set
                {
                    doswiadczenie = value;
                }
            }
            public KierownikZespolu()
            {

            }
            public KierownikZespolu(string imie_1, string nazwisko_1, string data_urodzenia_1, string PESEL_1, Plcie plec_1, int doswiadczenie_1)
            {
                Imie = imie_1;
                Nazwisko = nazwisko_1;
                PESEL = PESEL_1;
                Plec = plec_1;
                DateTime data;
                DateTime.TryParseExact(data_urodzenia_1, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out data);
                DataUrodzenia = data;
                Doswiadczenie = doswiadczenie_1;
            }
            new public string ToString()
            {
                //override public void ToString()
                /*
                StringBuilder linia = new StringBuilder();
                linia.Append(Imie + " ");
                linia.Append(Nazwisko + " ");
                DateTime d = DataUrodzenia;
                string d_day = Convert.ToString(d.Day);
                string d_month = Convert.ToString(d.Month);
                string d_year = Convert.ToString(d.Year);
                if (d_month.Length == 1)
                {
                    d_month = "0" + Convert.ToString(d.Month);
                }
                if (d_day.Length == 1)
                {
                    d_day = "0" + Convert.ToString(d.Day);
                }
                string d_u = d_day + "." + d_month + "." + d_year;
                linia.Append(d_u + " ");
                linia.Append(PESEL + " ");
                linia.Append(Plec + " ");
                linia.Append(Doswiadczenie + " ");
                Console.Writeline(linia);
                */

                DateTime d = DataUrodzenia;
                string d_day = Convert.ToString(d.Day);
                string d_month = Convert.ToString(d.Month);
                string d_year = Convert.ToString(d.Year);
                if (d_month.Length == 1)
                {
                    d_month = "0" + Convert.ToString(d.Month);
                }
                if (d_day.Length == 1)
                {
                    d_day = "0" + Convert.ToString(d.Day);
                }
                string d_u = d_day + "." + d_month + "." + d_year;



                string linia = "";
                linia += Imie + " ";
                linia += Nazwisko + " ";
                linia += d_u + " ";
                linia += PESEL + " ";
                linia += Plec + " ";
                linia += Doswiadczenie + " ";

                return linia;
            }

            public object Clone()
            {
                var k_z = (KierownikZespolu)MemberwiseClone();
                return k_z;
            }
        }

        public class Zespol : ICloneable
        {
            private int liczbaCzlonkow;
            public int LiczbaCzlonkow
            {
                get
                {
                    return liczbaCzlonkow;
                }
                set
                {
                    liczbaCzlonkow = value;
                }
            }
            private string nazwa;
            public string Nazwa
            {
                get
                {
                    return nazwa;
                }
                set
                {
                    nazwa = value;
                }
            }
            private KierownikZespolu kierownik;
            public KierownikZespolu Kierownik
            {
                get
                {
                    return kierownik;
                }
                set
                {
                    kierownik = value;
                }
            }
            private List<CzlonekZespolu> czlonkowie;
            public List<CzlonekZespolu> Czlonkowie
            {
                get
                {
                    return czlonkowie;
                }
                set
                {
                    czlonkowie = value;
                }
            }
            public Zespol()
            {
                LiczbaCzlonkow = 0;
                Nazwa = null;
                Kierownik = null;
                Czlonkowie = new List<CzlonekZespolu>();
            }
            public Zespol(string nazwa_1, KierownikZespolu kierownik_1) : this()
            {
                Nazwa = nazwa_1;
                Kierownik = kierownik_1;
            }
            public void DodajCzlonka(CzlonekZespolu c)
            {
                LiczbaCzlonkow++;

                DateTime d = c.DataUrodzenia;
                string d_day = Convert.ToString(d.Day);
                string d_month = Convert.ToString(d.Month);
                string d_year = Convert.ToString(d.Year);
                if (d_month.Length == 1)
                {
                    d_month = "0" + Convert.ToString(d.Month);
                }
                if (d_day.Length == 1)
                {
                    d_day = "0" + Convert.ToString(d.Day);
                }
                string d_u = d_year + "-" + d_month + "-" + d_day;

                d = c.DataZapisu;
                d_day = Convert.ToString(d.Day);
                d_month = Convert.ToString(d.Month);
                d_year = Convert.ToString(d.Year);
                if (d_month.Length == 1)
                {
                    d_month = "0" + Convert.ToString(d.Month);
                }
                if (d_day.Length == 1)
                {
                    d_day = "0" + Convert.ToString(d.Day);
                }
                string d_z = d_year + "-" + d_month + "-" + d_day;

                Czlonkowie.Add(new CzlonekZespolu(c.Imie, c.Nazwisko, d_u, c.PESEL, c.Plec, c.Funkcja, d_z));
            }
            new public void ToString()
            {
                Console.WriteLine("Zespół: " + Nazwa);
                StringBuilder linia = new StringBuilder();
                linia.Append("Kierownik: ");
                linia.Append(Kierownik.Imie + " ");
                linia.Append(Kierownik.Nazwisko + " ");
                DateTime d = Kierownik.DataUrodzenia;
                string d_day = Convert.ToString(d.Day);
                string d_month = Convert.ToString(d.Month);
                string d_year = Convert.ToString(d.Year);
                if (d_month.Length == 1)
                {
                    d_month = "0" + Convert.ToString(d.Month);
                }
                if (d_day.Length == 1)
                {
                    d_day = "0" + Convert.ToString(d.Day);
                }
                string d_u = d_day + "." + d_month + "." + d_year;
                linia.Append(d_u + " ");
                linia.Append(Kierownik.PESEL + " ");
                linia.Append(Kierownik.Plec + " ");
                linia.Append(Kierownik.Doswiadczenie + " ");
                Console.WriteLine(linia);
                linia.Clear();
                foreach (CzlonekZespolu element in Czlonkowie)
                {
                    linia.Append(element.Imie + " ");
                    linia.Append(element.Nazwisko + " ");

                    d = element.DataUrodzenia;
                    d_day = Convert.ToString(d.Day);
                    d_month = Convert.ToString(d.Month);
                    d_year = Convert.ToString(d.Year);
                    if (d_month.Length == 1)
                    {
                        d_month = "0" + Convert.ToString(d.Month);
                    }
                    if (d_day.Length == 1)
                    {
                        d_day = "0" + Convert.ToString(d.Day);
                    }
                    d_u = d_day + "." + d_month + "." + d_year;
                    linia.Append(d_u + " ");

                    linia.Append(element.PESEL + " ");
                    linia.Append(element.Plec + " ");
                    linia.Append(element.Funkcja + " ");

                    d = element.DataZapisu;
                    d_day = Convert.ToString(d.Day);
                    d_month = Convert.ToString(d.Month);
                    d_year = Convert.ToString(d.Year);
                    if (d_month.Length == 1)
                    {
                        d_month = "0" + Convert.ToString(d.Month);
                    }
                    if (d_day.Length == 1)
                    {
                        d_day = "0" + Convert.ToString(d.Day);
                    }
                    string d_z = d_day + "-" + d_month + "-" + d_year;
                    linia.Append("(" + d_z + ")");

                    Console.WriteLine(linia);
                    linia.Clear();
                }
            }
            public bool JestCzlonkiem(string pesel_1)
            {
                bool czy_prawda = false;
                for(int i = 0; i < LiczbaCzlonkow; i++)
                {
                    CzlonekZespolu Cz = Czlonkowie[i];
                    if(pesel_1 == Cz.PESEL)
                    {
                        czy_prawda = true;
                        break;
                    }
                }
                return czy_prawda;
            }
            public bool JestCzlonkiem(string imie_1, string nazwisko_1)
            {
                bool czy_prawda = false;
                for (int i = 0; i < LiczbaCzlonkow; i++)
                {
                    CzlonekZespolu Cz = Czlonkowie[i];
                    if ((imie_1 == Cz.Imie)&&(nazwisko_1 == Cz.Nazwisko))
                    {
                        czy_prawda = true;
                        break;
                    }
                }
                return czy_prawda;
            }
            public void UsunCzlonka(string pesel_1)
            {
                if(JestCzlonkiem(pesel_1))
                {
                    for (int i = 0; i < LiczbaCzlonkow; i++)
                    {
                        CzlonekZespolu Cz = Czlonkowie[i];
                        if (pesel_1 == Cz.PESEL)
                        {
                            czlonkowie.Remove(Cz);
                            break;
                        }
                    }
                    LiczbaCzlonkow--;
                }
                else
                {
                    return;
                }
            }
            public void UsunCzlonka(string imie_1, string nazwisko_1)
            {
                if (JestCzlonkiem(imie_1, nazwisko_1))
                {
                    for (int i = 0; i < LiczbaCzlonkow; i++)
                    {
                        CzlonekZespolu Cz = Czlonkowie[i];
                        if ((imie_1 == Cz.Imie) && (nazwisko_1 == Cz.Nazwisko))
                        {
                            Czlonkowie.Remove(Cz);
                            break;
                        }
                    }
                    LiczbaCzlonkow--;
                }
                else
                {
                    return;
                }
            }
            public void UsunWszystkich()
            {
                while(LiczbaCzlonkow > 0)
                {
                    LiczbaCzlonkow--;
                    Czlonkowie.Remove(Czlonkowie[LiczbaCzlonkow]);
                }
                return;
            }
            public List<CzlonekZespolu> WyszukajCzlonkow(string funkcja_1)
            {
                List<CzlonekZespolu> Lista = new List<CzlonekZespolu>();
                for (int i = 0; i < LiczbaCzlonkow; i++)
                {
                    CzlonekZespolu Cz = Czlonkowie[i];
                    if (funkcja_1 == Cz.Funkcja)
                    {
                        DateTime d = Cz.DataUrodzenia;
                        string d_day = Convert.ToString(d.Day);
                        string d_month = Convert.ToString(d.Month);
                        string d_year = Convert.ToString(d.Year);
                        if (d_month.Length == 1)
                        {
                            d_month = "0" + Convert.ToString(d.Month);
                        }
                        if (d_day.Length == 1)
                        {
                            d_day = "0" + Convert.ToString(d.Day);
                        }
                        string d_u = d_year + "-" + d_month + "-" + d_day;

                        d = Cz.DataZapisu;
                        d_day = Convert.ToString(d.Day);
                        d_month = Convert.ToString(d.Month);
                        d_year = Convert.ToString(d.Year);
                        if (d_month.Length == 1)
                        {
                            d_month = "0" + Convert.ToString(d.Month);
                        }
                        if (d_day.Length == 1)
                        {
                            d_day = "0" + Convert.ToString(d.Day);
                        }
                        string d_z = d_year + "-" + d_month + "-" + d_day;

                        Lista.Add(new CzlonekZespolu(Cz.Imie, Cz.Nazwisko, d_u, Cz.PESEL, Cz.Plec, Cz.Funkcja, d_z));
                    }
                }
                return Lista;
            }
            public List<CzlonekZespolu> WyszukajCzlonkow(int miesiac)
            {
                List<CzlonekZespolu> Lista = new List<CzlonekZespolu>();
                for (int i = 0; i < LiczbaCzlonkow; i++)
                {
                    CzlonekZespolu Cz = Czlonkowie[i];
                    if (miesiac == Cz.DataZapisu.Month)
                    {
                        DateTime d = Cz.DataUrodzenia;
                        string d_day = Convert.ToString(d.Day);
                        string d_month = Convert.ToString(d.Month);
                        string d_year = Convert.ToString(d.Year);
                        if (d_month.Length == 1)
                        {
                            d_month = "0" + Convert.ToString(d.Month);
                        }
                        if (d_day.Length == 1)
                        {
                            d_day = "0" + Convert.ToString(d.Day);
                        }
                        string d_u = d_year + "-" + d_month + "-" + d_day;

                        d = Cz.DataZapisu;
                        d_day = Convert.ToString(d.Day);
                        d_month = Convert.ToString(d.Month);
                        d_year = Convert.ToString(d.Year);
                        if (d_month.Length == 1)
                        {
                            d_month = "0" + Convert.ToString(d.Month);
                        }
                        if (d_day.Length == 1)
                        {
                            d_day = "0" + Convert.ToString(d.Day);
                        }
                        string d_z = d_year + "-" + d_month + "-" + d_day;

                        Lista.Add(new CzlonekZespolu(Cz.Imie, Cz.Nazwisko, d_u, Cz.PESEL, Cz.Plec, Cz.Funkcja, d_z));
                    }
                }
                return Lista;
            }
            public void ZmienKierownika(KierownikZespolu kierownik_1)
            {
                Kierownik = kierownik_1;
                return;
            }
            public void ZmienNazwe(string nazwa)
            {
                Nazwa = nazwa;
                return;
            }
            public object Clone()
            {
                var z = (Zespol)MemberwiseClone();
                return z;
            }
            public void Sortuj()
            {
                int n = LiczbaCzlonkow;
                while(n > 1)
                {
                    for (int i = 0; i < n-1; i++)
                    {
                        if(Czlonkowie[i].CompareTo(Czlonkowie[i + 1]) == 3)
                        {
                            CzlonekZespolu tymczasowy = Czlonkowie[i];
                            Czlonkowie[i] = Czlonkowie[i + 1];
                            Czlonkowie[i + 1] = tymczasowy;
                        }
                    }
                    n--;
                }
            }

            public static void ZapiszXML(string nazwa_1, Zespol z)
            {
                XmlSerializer x = new XmlSerializer(typeof(Zespol));
                using (Stream s = File.Create(nazwa_1 + ".xml"))
                    x.Serialize(s, z);
;           }

            public static Zespol OdczytajXML(string nazwa_1)
            {
                Zespol z;
                XmlSerializer x = new XmlSerializer(typeof(Zespol));
                using (Stream s = File.OpenRead(nazwa_1))
                    z = (Zespol)x.Deserialize(s);
                return z;
            }
        }
    }
}