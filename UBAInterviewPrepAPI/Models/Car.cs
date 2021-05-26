using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Chasis { get; set; }
        public decimal Weight { get; set; }
        public DateTime DateAssembled { get; set; }
    }
}
