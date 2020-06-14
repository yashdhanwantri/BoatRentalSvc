using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.Models
{
    public class BoatRental
    {
        [Key]
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BoatId { get; set; }
        public Boat Boat { get; set; }
    }
}
