using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfFuvar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> taxi_adatok = new List<Fuvar>();
        public MainWindow()
        {
            InitializeComponent();
            //balra: -
            //jobbra: Vedrán Krisztián
            StreamReader sr = new StreamReader("fuvar.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                //MessageBox.Show(adatok[0]+" " + adatok[1] + " " + adatok[2] + " " + adatok[3] + " " + adatok[4] + " " + adatok[5] + " " + adatok[6]);
                taxi_adatok.Add(new Fuvar(int.Parse(adatok[0]), adatok[1], int.Parse(adatok[2]), double.Parse(adatok[3]), double.Parse(adatok[4]), double.Parse(adatok[5]), adatok[6]));
            }
            sr.Close();
        }

        private void btnFeladat3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(taxi_adatok.Count().ToString()+ " fuvar");
        }

        private void btnFeladat4_Click(object sender, RoutedEventArgs e)
        {
            double taxibevetel = 0;
            int taxifuvarszam = 0;
            foreach (var item in taxi_adatok)
            {
                if (item.Taxi_azon_p == 6185)
                {
                    taxibevetel += item.Veteldij_p + item.Borravalo_p;
                    taxifuvarszam += 1;
                }
            }
            MessageBox.Show(taxifuvarszam + " fuvar alatt: $" + taxibevetel);
        }

        private void btnFeladat5_Click(object sender, RoutedEventArgs e)
        {
            int bankkartya = 0;
            int keszpenz = 0;
            int vitatott = 0;
            int ingyenes = 0;
            int ismeretlen = 0;

            foreach (var item in taxi_adatok)
            {
                if (item.Fizetes_mod_p == "bankkártya")
                {
                    bankkartya++;
                }
                if (item.Fizetes_mod_p == "készpénz")
                {
                    keszpenz++;
                }
                if (item.Fizetes_mod_p == "vitatott")
                {
                    vitatott++;
                }
                if (item.Fizetes_mod_p == "ingyenes")
                {
                    ingyenes++;
                }
                if (item.Fizetes_mod_p == "ismeretlen")
                {
                    ismeretlen++;
                }
            }
            MessageBox.Show($"bankkártya: {bankkartya} fuvar\nkészpénz: {keszpenz} fuvar\nvitatott: {vitatott} fuvar\ningyenes: {ingyenes} fuvar\nismeretlen: {ismeretlen} fuvar");
        }

        private void btnFeladat6_Click(object sender, RoutedEventArgs e)
        {
            double taxiskm = 0;
            foreach (var item in taxi_adatok)
            {
                taxiskm += item.Megtett_tav_p;
            }
            taxiskm *= 1.6;
            MessageBox.Show(Math.Round(taxiskm, 2).ToString()+" km");
        }

        private void btnFeladat7_Click(object sender, RoutedEventArgs e)
        {
            int max_fuvar_hossz = 0;
            int taxiid = 0;
            double megtett_tav = 0;
            double veteldij = 0;

            foreach (var item in taxi_adatok)
            {
                if (item.Utazas_ido_p > max_fuvar_hossz)
                {
                    max_fuvar_hossz = item.Utazas_ido_p;
                    taxiid = item.Taxi_azon_p;
                    megtett_tav = item.Megtett_tav_p;
                    veteldij = item.Veteldij_p;
                }
            }
            MessageBox.Show($"Leghosszabb fuvar:\nFuvar hossza: {max_fuvar_hossz} másodperc\nTaxi azonosító: {taxiid}\nMegtett távolság: {megtett_tav} km\nVételdíj: ${veteldij}");

        }

        private void btnFeladat8_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("hibak.txt"))
            {
                {
                    sw.WriteLine();
                    foreach (var item in taxi_adatok)
                    {
                        if (item.Utazas_ido_p > 0 && item.Veteldij_p>0 && item.Megtett_tav_p==0)
                        {
                            sw.WriteLine(item.Taxi_azon_p+";"+item.Indulas_ido_p + ";" + item.Utazas_ido_p + ";" + item.Megtett_tav_p + ";" + item.Veteldij_p + ";" + item.Borravalo_p + ";" + item.Fizetes_mod_p);
                        }
                    }
                }
            }
        }
    }
}
