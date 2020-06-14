using BoatRentalSvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.BusinessLogic
{
    public class BoatBusinessLogic : IBoatBusinessLogic
    {
        public Task<List<Boat>> GetAllBoats()
        {
            throw new NotImplementedException();
        }

        public Task<Boat> GetBoatById(int boatId)
        {
            throw new NotImplementedException();
        }

        public Task RegisterBoat(Boat boat)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBoat(int boatId)
        {
            throw new NotImplementedException();
        }
    }
}
