using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Zespol_projekt;
//using static ZespolGUI.OsobaWindow;

namespace ZespolGUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Osoba.Zespol zespol = new Osoba.Zespol();
        public MainWindow()
        {
            InitializeComponent();

            zespol = Osoba.Zespol.OdczytajXML("pliczek.XML");

            foreach (Osoba.CzlonekZespolu cz_z in zespol.Czlonkowie)
            {
                DateTime d = cz_z.DataUrodzenia;
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

                lstCzlonkowie.Items.Add(cz_z.Imie + " " + cz_z.Nazwisko + ", " + cz_z.PESEL + " " + d_u + " " + cz_z.Funkcja);
            }

            TxtNazwa.Text = zespol.Nazwa;
            TxtKierownik.Text = zespol.Kierownik.ToString();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Osoba.CzlonekZespolu cz_z = new Osoba.CzlonekZespolu();
            OsobaWindow okno = new OsobaWindow(cz_z);
            okno.ShowDialog();
            zespol.DodajCzlonka(cz_z);
            DateTime d = cz_z.DataUrodzenia;
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

            lstCzlonkowie.Items.Add(cz_z.Imie + " " + cz_z.Nazwisko + ", " + cz_z.PESEL + " " + d_u + " " + cz_z.Funkcja);
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = lstCzlonkowie.SelectedIndex;
            lstCzlonkowie.Items.RemoveAt(zaznaczony);
            zespol.Czlonkowie.RemoveAt(zaznaczony);
        }

        private void btnZmien_Click(object sender, RoutedEventArgs e)
        {
            OsobaWindow okno = new OsobaWindow(zespol.Kierownik);
            okno.ShowDialog();
            zespol.Kierownik = (Osoba.KierownikZespolu)okno._osoba;
            TxtKierownik.Text = zespol.Kierownik.ToString();
        }

        private void btnZmienCzlonka_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = lstCzlonkowie.SelectedIndex;
            OsobaWindow okno = new OsobaWindow(zespol.Czlonkowie[zaznaczony]);
            okno.ShowDialog();
            Osoba.CzlonekZespolu cz_z = (Osoba.CzlonekZespolu)okno._osoba;
            zespol.Czlonkowie[zaznaczony] = cz_z;

            DateTime d = cz_z.DataUrodzenia;
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

            string cz = cz_z.Imie + " " + cz_z.Nazwisko + ", " + cz_z.PESEL + " " + d_u + " " + cz_z.Funkcja;
            lstCzlonkowie.Items[zaznaczony] = cz;
        }

        private void txtKierownik_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                zespol = Osoba.Zespol.OdczytajXML(filename);

                lstCzlonkowie.Items.Clear();
                foreach (Osoba.CzlonekZespolu cz_z in zespol.Czlonkowie)
                {
                    DateTime d = cz_z.DataUrodzenia;
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

                    lstCzlonkowie.Items.Add(cz_z.Imie + " " + cz_z.Nazwisko + ", " + cz_z.PESEL + " " + d_u + " " + cz_z.Funkcja);
                }

                TxtNazwa.Text = zespol.Nazwa;
                TxtKierownik.Text = zespol.Kierownik.ToString();
            }
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if(result == true)
            {
                string filename = dlg.FileName;
                zespol.Nazwa = TxtNazwa.Text;
                Osoba.Zespol.ZapiszXML(filename, zespol);
            }
        }

        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
