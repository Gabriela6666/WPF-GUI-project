using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zespol_projekt
{
    public enum Plcie 
    {
        K,
        M
    }

    class Program
    {

        static void Main(string[] args)
        {
            Osoba.KierownikZespolu A = new Osoba.KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070100211", (Plcie)1, 5);
            //A.ToString();
            //Console.WriteLine();

            Osoba.CzlonekZespolu B = new Osoba.CzlonekZespolu("Witold", "Adamski", "1992-10-22", "92102266738", (Plcie)1, "sekretarz", "01-sty-2020");
            //B.ToString();
            //Console.WriteLine();

            Osoba.CzlonekZespolu C = new Osoba.CzlonekZespolu("Jan", "Janowski", "1992-03-15", "92031532652", (Plcie)1, "programista", "01-sty-2020");
            Osoba.CzlonekZespolu D = new Osoba.CzlonekZespolu("Jan", "But", "1992-05-16", "92051613915", (Plcie)1, "programista", "01-cze-2019");
            Osoba.CzlonekZespolu E = new Osoba.CzlonekZespolu("Beata", "Nowak", "1993-11-22", "93112225023", (Plcie)0, "projektant", "01-sty-2020");
            Osoba.CzlonekZespolu F = new Osoba.CzlonekZespolu("Anna", "Mysza", "1991-07-22", "91072235964", (Plcie)0, "projektant", "31-lip-2019");

            Osoba.Zespol X = new Osoba.Zespol("Grupa IT", A);
            X.DodajCzlonka(B);
            X.DodajCzlonka(C);
            X.DodajCzlonka(D);
            X.DodajCzlonka(E);
            X.DodajCzlonka(F);
            X.ToString();
            Console.WriteLine();

            Console.WriteLine("W '" + X.Nazwa + "' znajduje się osoba o numerze PESEL: " + B.PESEL);
            if(X.JestCzlonkiem(B.PESEL))
            {
                Console.WriteLine("prawda");
            }
            else
            {
                Console.WriteLine("fałsz");
            }
            Console.WriteLine();


            Console.WriteLine("W '" + X.Nazwa + "' znajduje się osoba o numerze PESEL: " + 91072235963);
            if (X.JestCzlonkiem("91072235963"))
            {
                Console.WriteLine("prawda");
            }
            else
            {
                Console.WriteLine("fałsz");
            }
            Console.WriteLine();

            X.UsunCzlonka(B.PESEL);
            Console.WriteLine("Witold Adamski został usunięty z zespołu.");
            Console.WriteLine();
            Console.WriteLine("W '" + X.Nazwa + "' znajduje się osoba o numerze PESEL: " + B.PESEL);
            if (X.JestCzlonkiem(B.PESEL))
            {
                Console.WriteLine("prawda");
            }
            else
            {
                Console.WriteLine("fałsz");
            }
            Console.WriteLine();
            X.DodajCzlonka(B);
            Console.WriteLine("Witold Adamski został dodany do zespołu.");
            Console.WriteLine();

            string f = "programista";
            Console.WriteLine("Lista osób z zespołu " + X.Nazwa + " pełniących funkcję: " + f);
            List<Osoba.CzlonekZespolu> Y = X.WyszukajCzlonkow(f);
            foreach(Osoba.CzlonekZespolu z in Y)
            {
                z.ToString();
            }
            Console.WriteLine();


            Console.WriteLine("Stworzono nowy zespół.");
            Osoba.Zespol Q = (Osoba.Zespol)X.Clone();
            Osoba.KierownikZespolu G = new Osoba.KierownikZespolu("Rafał", "Marzec", "1988-03-21", "88032112357", (Plcie)1, 6);
            Q.ZmienKierownika(G);
            Q.ZmienNazwe("NowaGrupa");            
            Q.ToString();
            Console.WriteLine();
            Console.WriteLine("Stary zespół: ");
            X.ToString();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Posortowany: ");
            X.Sortuj();
            X.ToString();
            Console.WriteLine();
            Console.WriteLine("Po odczytaniu:");
            Osoba.Zespol.ZapiszXML("pliczek", X);
            Osoba.Zespol.ZapiszXML("pliczek_nowy", Q);
            Osoba.Zespol.OdczytajXML("pliczek").ToString();
            Console.WriteLine();
            Osoba.Zespol.OdczytajXML("pliczek_nowy").ToString();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
