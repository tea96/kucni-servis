using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace BusinessLayer
{
    public class UslugaBusiness
    {
        private UslugaRepository uslugaRepository;

        public UslugaBusiness()
        {
            this.uslugaRepository = new UslugaRepository();
        }

        public List<Usluga> GetAllUsluga()
        {
            return this.uslugaRepository.GetAllUsluga();
        } 

        public bool InsertUsluga(Usluga usluga)
        {
            int result=0;
            if(usluga!=null)
            {
                result=this.uslugaRepository.InsertUsluga(usluga);
            }
            if(result>0)
            {
                return true;
            }
            return false;
        } 

        public bool DeleteUsluga(int id)
        {
            int result;
            result=this.uslugaRepository.DeleteUsluga(id);

            if(result>0)
            {
                return true;
            }
            return false;
        }

        public List<Usluga> UslugaPoKorisniku(int id)
        {
            return this.uslugaRepository.UslugaPoKorisniku(id);
        }

    }
}
