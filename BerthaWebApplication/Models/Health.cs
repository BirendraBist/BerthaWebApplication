using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BerthaWebApplication.Models
{
    public class Health
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Record form health
        public int HealthId { get; set; }
        public DateTime DateTime { get; set; }
       public string Location { get; set; }
        public double BodyTemperature { get; set; }
        public double UpperbloodPressure { get; set; }
        public double LowerbloodPressure { get; set; }
        public double Heartbeat { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
