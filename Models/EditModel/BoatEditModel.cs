using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.Models.EditModel
{
    public class BoatEditModel
    {
        public string BoatName { get; set; }
        public decimal HourlyRate { get; set; }
        public string ImagePath { get; set; }
    }
}
