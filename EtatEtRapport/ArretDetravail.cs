using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicus.EtatEtRapport
{
    public partial class ArretDetravail
    {
        public ArretDetravail()
        {

        }
        public string compteurarret { get; set; }
        public DateTime DateDebutArret { get; set; }
        public string NomPrenomPatient { get; set; }
        public DateTime DateNaissancePatient { get; set; }
        public string LieudeNaissancePatient { get; set; }
     
        public DateTime Faitle { get; set; }
        public string Asignature { get; set; }
        public string Nbjour { get; set; }
        public bool autorisées { get; set; }
        public bool nonautorisées { get; set; }
    }
}
