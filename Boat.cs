using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc
{
    public class Boat
    {
        [Key]
        public int Number { get; set; }
        [Required]
        public int BoatName { get; set; }
        [Required]
        [Column(TypeName ="decimal(10,4)")]
        public decimal HourlyRate { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
