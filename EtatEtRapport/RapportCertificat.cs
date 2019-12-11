using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicus.EtatEtRapport
{
    public partial class RapportCertificat
    {

        public RapportCertificat()
        {

        }
        public DateTime DateExam { get; set; }
        public DateTime DateNaissancePatient { get; set; }
        public string LieudeNaissancePatient { get; set; }
        public string NomPrenomPatient { get; set; }
        public DateTime Faitle { get; set; }
        public string Asignature { get; set; }
         public string Pratique { get; set; }

       
    }
}
