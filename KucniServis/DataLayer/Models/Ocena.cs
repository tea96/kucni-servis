using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Ocena
    {
        public int Id_ocene { get; set; }
        public int Id_korisnika { get; set; }
        public int Vrednost { get; set; }

    }
}
