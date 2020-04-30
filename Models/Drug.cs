using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrugRelatedDeaths.Models
{
    public class Drug
    {
        [Key]
        public string ID { get; set; }
        public string Cocaine { get; set; }
        public string Heroin { get; set; }
        public string Fentanyl { get; set; }

        public string FentanylAnalogue { get; set; }
        public string Oxycodone { get; set; }
        public string Oxymorphone { get; set; }
        public string Ethanol { get; set; }
        public string Hydrocodone { get; set; }
        public string Benzodiazepine { get; set; }
        public string Methadone { get; set; }
        public string Amphet { get; set; }
        public string Tramad { get; set; }
        
    }
}
