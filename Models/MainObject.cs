using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DrugRelatedDeaths.Models
{



    public class MainObject
    {
        public class Drug_Info
        {
            [Key]
            
            public string ID { get; set; }
            public string Sex { get; set; }
            public string ResidenceCity { get; set; }
            public string Race { get; set; }
           // public string MannerofDeath { get; set; }
            public string ResidenceCounty { get; set; }

           // public string DeathType { get; set; }
            public DateTime Date { get; set; }
            public int Age { get; set; }
            
            public string DescriptionofInjury { get; set; }
            [NotMapped]
            public IEnumerable<Drug> Drugs { get; set; }
        }
   




        //public int Zip { get; set; }
        // public string City { get; set; }
        // public string State { get; set; }
        // public float Latitude { get; set; }

        //  public float Longitude { get; set; }




    }
}





