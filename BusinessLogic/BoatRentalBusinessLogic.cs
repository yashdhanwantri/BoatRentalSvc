using BoatRentalSvc.Classes;
using BoatRentalSvc.Interfaces;
using BoatRentalSvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.BusinessLogic
{
    public class BoatRentalBusinessLogic: IBoatRentalBusinessLogic
    {
        private BoatDbContext _dbContext;
        private IBoatBusinessLogic _boatBusinessLogic;
        public BoatRentalBusinessLogic(BoatDbContext dbContext, IBoatBusinessLogic boatBusinessLogic)
        {
            _dbContext = dbContext;
            _boatBusinessLogic = boatBusinessLogic;
        }

        public Task<BoatRental> GetBoatRental(int boatId, string customerName)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoatRental>> GetBoatRentals()
        {
            throw new NotImplementedException();
        }

        public Task<BoatRental> RentBoat(int boatId, string customerName, DateTime From, DateTime To)
        {
            throw new NotImplementedException();
        }

        public Task<BoatRental> ReturnBoat(int boatId, string customerName)
        {
            throw new NotImplementedException();
        }
    }
}
