using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace BusinessLayer
{
    public class KorisnikBusiness
    {
        private KorisnikRepository korisnikRepository;

        public KorisnikBusiness()
        {
            this.korisnikRepository = new KorisnikRepository();
        }

        public List<Korisnik> GetAllKorisnik()
        {
            return this.korisnikRepository.GetAllKorisnik();
        }

        public bool InsertKorisnik(Korisnik korisnik)
        {
            int result = 0;
            if (korisnik != null)
            {
                result = this.korisnikRepository.InsertKorisnik(korisnik);
            }
            if (result > 0)
            {
                return true;
            }
            return false;

        }

        public bool DeleteKorisnik(int id)
        {
            int result;
            result = this.korisnikRepository.DeleteKorisnik(id);

            if (result > 0)
            {
                return true;
            }
            return false;

        }

        public bool UpdateKorisnik(Korisnik s)
        {
            int result = 0;
            if (s != null)
            {
                result = this.korisnikRepository.UpdateKorisnik(s);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }


        public Korisnik Login(string username, string password)
        {
            

            foreach (Korisnik k in korisnikRepository.GetAllKorisnik())
            {
                if (k.KorisnickoIme == username && k.Sifra == password)
                {
                    return k;

                }

            }
            return null;
        }


        public List<Korisnik> PretraziPoGradu(string grad)
        {
            
            List<Korisnik> nova = new List<Korisnik>();

            foreach (Korisnik k in korisnikRepository.GetAllKorisnik())
            {
                if (k.Grad == grad) nova.Add(k);
            }
            return nova;
        }

    }
}
