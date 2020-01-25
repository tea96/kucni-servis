using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace BusinessLayer
{
    public class OcenaBusiness
    {
        private OcenaRepository ocenaRepository;

        public OcenaBusiness()
            {
                this.ocenaRepository = new OcenaRepository(); }

        public List<Ocena> GetAllOcena()
            {
                 return this.ocenaRepository.GetAllOcena();
            } 
        public bool InsertOcena(Ocena ocena)
        {
            int result=0;
                if(ocena!=null)
                {
                    result=this.ocenaRepository.InsertOcena(ocena);
                }
                    if(result>0)
                {
                    return true;
                }
                return false;
        } 

        public bool DeleteOcena(int id)
        {
            int result;
            result=this.ocenaRepository.DeleteOcena(id);

            if(result>0)
             {
            return true;
             }
            return false;
        }

        public bool UpdateOcena(Ocena s)
        {
            int result = 0;
            if (s != null)
            {
                result = this.ocenaRepository.UpdateOcena(s);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
