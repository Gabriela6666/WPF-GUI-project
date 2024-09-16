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
using System.Windows.Shapes;
using Zespol_projekt;

namespace ZespolGUI
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaWindow.xaml
    /// </summary>
    public partial class OsobaWindow : Window
    {
        public OsobaWindow()
        {
            InitializeComponent();
        }

        public Osoba _osoba;

        public OsobaWindow(Osoba osoba) : this()
        {
            _osoba = osoba;
            if(_osoba is Osoba.KierownikZespolu)
            {
                lblLabel.Content = "Doświadczenie";
                Osoba.KierownikZespolu osoba_1 = (Osoba.KierownikZespolu) _osoba;
                TxtPESEL.Text = osoba.PESEL;
                TxtImie.Text = osoba.Imie;
                TxtNazwisko.Text = osoba.Nazwisko;
                TxtDataUr.Text = osoba.DataUrodzenia.ToString("dd-MMM-yyyy");
                cmbPlec.Text = ((osoba.Plec)== Plcie.K) ? "kobieta" : "mężczyzna";
                TxtTekst.Text = osoba_1.Doswiadczenie.ToString();
            }
            else
            {
                lblLabel.Content = "Funkcja";
                Osoba.CzlonekZespolu osoba_1 = (Osoba.CzlonekZespolu)_osoba;
                TxtPESEL.Text = osoba.PESEL;
                TxtImie.Text = osoba.Imie;
                TxtNazwisko.Text = osoba.Nazwisko;
                TxtDataUr.Text = osoba.DataUrodzenia.ToString("dd-MMM-yyyy");
                cmbPlec.Text = ((osoba.Plec) == Plcie.K) ? "kobieta" : "mężczyzna";
                TxtTekst.Text = osoba_1.Funkcja;
            }
        }

        public void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if(TxtPESEL.Text != "" && TxtImie.Text != "" && TxtNazwisko.Text != "" && TxtTekst.Text != "")
            {
                _osoba.PESEL = TxtPESEL.Text;
                _osoba.Imie = TxtImie.Text;
                _osoba.Nazwisko = TxtNazwisko.Text;
                DateTime data;
                string data_urodzenia_1 = TxtDataUr.Text;
                DateTime.TryParseExact(data_urodzenia_1, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out data);
                _osoba.DataUrodzenia = data;
                _osoba.Plec = (cmbPlec.Text == "kobieta") ? Plcie.K : Plcie.M;
                if(_osoba is Osoba.KierownikZespolu)
                {
                    Osoba.KierownikZespolu osoba_1 = (Osoba.KierownikZespolu)_osoba;
                    osoba_1.Doswiadczenie = Int32.Parse(TxtTekst.Text);
                }
                else
                {
                    Osoba.CzlonekZespolu osoba_1 = (Osoba.CzlonekZespolu)_osoba;
                    osoba_1.Funkcja = TxtTekst.Text;
                }
            }
            DialogResult = true;
            
        }

        public void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
