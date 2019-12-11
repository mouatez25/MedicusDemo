using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicus.EtatEtRapport
{
    public partial class TableauDeBordClass
    {
     /*   public TableauDeBordClass(DateTime d1,DateTime d2,string rb,string vl,string rm)
        {
            Date1 = d1;
            Date2 = d1;
            rb = Rubrique;
            Valeur = vl;
            Remarque = rm;
        }*/
        public TableauDeBordClass( )
        {
         
        }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }

        public string Rubrique { get; set; }
        public string Valeur { get; set; }
        public string Remarque { get; set; }
    }
}
