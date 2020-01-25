using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace BusinessLayer
{
    public class PruzanjeUslugaBusiness
    {
        private PruzanjeUslugaRepository pruzanjeuslugaRepository;

        public PruzanjeUslugaBusiness()
            {
                this.pruzanjeuslugaRepository = new PruzanjeUslugaRepository();
             }

        public List<Pruzanje_Usluga> GetAllPruzanje_Usluga()
            {
                 return this.pruzanjeuslugaRepository.GetAllPruzanje_Usluga();
            } 
        public bool InsertPruzanje_Usluga(Pruzanje_Usluga pruzanjeusluga)
        {
            int result=0;
            if(pruzanjeusluga!=null)
            {
                result=this.pruzanjeuslugaRepository.InsertPruzanje_Usluga(pruzanjeusluga);
            }
            if(result>0)
            {
                return true;
            }
            return false;
        } 

        public bool DeletePruzanje_Usluga(Pruzanje_Usluga s)
        {
            int result;
            result=this.pruzanjeuslugaRepository.DeletePruzanje_Usluga(s);

            if(result>0)
            {
                return true;
            }
            return false;
        } 
    }
}
