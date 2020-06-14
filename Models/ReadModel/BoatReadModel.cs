using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.Models.ReadModel
{
    public class BoatReadModel
    {
        public int Id { get; set; }
        public string BoatName { get; set; }
        public decimal HourlyRate { get; set; }
        public string ImagePath { get; set; }
    }
}
