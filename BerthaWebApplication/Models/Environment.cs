using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BerthaWebApplication.Models
{
    public class Environment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EvnironmentId { get; set; }
        public DateTime DateTime { get; set; }
        
        public string Location { get; set; }
        public double Oxygen { get; set; }
        public double Dustpartical { get; set; }
        public double Carbonmonoxide { get; set; }
        public double Nitrogen { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }


    }
}