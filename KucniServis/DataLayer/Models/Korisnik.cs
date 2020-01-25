using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Korisnik
    {
        public int Id_korisnika {get;set;}
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme;
        public string Sifra { get; set; }
        public string Grad { get; set; }
        public string Adresa { get; set; }
        public string EMail;
        public string Broj_telefona { get; set; }
        public string Admin { get; set; }

        public string GetSetKorisnickoIme
        {
            get { return KorisnickoIme; }
            set { KorisnickoIme = value; }
        }

        public string GetSetEMail
        {
            get { return EMail; }
            set { EMail= value; }
        }



    }
}
