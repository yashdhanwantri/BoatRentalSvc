using BoatRentalSvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.Interfaces
{
    public interface IBoatRentalBusinessLogic
    {
        List<BoatRental> GetBoatRentals();
        BoatRental GetBoatRental(int boatId, DateTime asOfTime);
        Task<BoatRental> RentBoat(int boatId, string customerName, DateTime From);
        Task<BoatRental> ReturnBoat(int boatId, string customerName);
        
    }
}
