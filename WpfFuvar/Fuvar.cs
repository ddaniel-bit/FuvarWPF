using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFuvar
{
    internal class Fuvar
    {
        int Taxi_azon;
        string Indulas_ido;
        int Utazas_ido;
        double Megtett_tav;
        double Veteldij;
        double Borravalo;
        string Fizetes_mod;

        public Fuvar(int taxi_azon, string indulas_ido, int utazas_ido, double megtett_tav, double veteldij, double borravalo, string fizetes_mod)
        {
            Taxi_azon = taxi_azon;
            Indulas_ido = indulas_ido;
            Utazas_ido = utazas_ido;
            Megtett_tav = megtett_tav;
            Veteldij = veteldij;
            Borravalo = borravalo;
            Fizetes_mod = fizetes_mod;
        }

        public int Taxi_azon_p { get => Taxi_azon; set => Taxi_azon = value; }
        public string Indulas_ido_p { get => Indulas_ido; set => Indulas_ido = value; }
        public int Utazas_ido_p { get => Utazas_ido; set => Utazas_ido = value; }
        public double Megtett_tav_p { get => Megtett_tav; set => Megtett_tav = value; }
        public double Veteldij_p { get => Veteldij; set => Veteldij = value; }
        public double Borravalo_p { get => Borravalo; set => Borravalo = value; }
        public string Fizetes_mod_p { get => Fizetes_mod; set => Fizetes_mod = value; }
    }
}
