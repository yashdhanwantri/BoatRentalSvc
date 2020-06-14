using BoatRentalSvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.Interfaces
{
    public interface IBoatRentalBusinessLogic
    {
        Task<BoatRental> RentBoat(int boatId, string customerName, DateTime From, DateTime To);
        Task<BoatRental> ReturnBoat(int boatId, string customerName);
        Task<List<BoatRental>> GetBoatRentals();
        Task<BoatRental> GetBoatRental(int boatId, string customerName);
    }
}
