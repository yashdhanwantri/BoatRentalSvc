using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.Interfaces
{
    public interface IBoatBusinessLogic
    {
        Task<Boat> GetBoatById(int boatId);
        Task<List<Boat>> GetAllBoats();
        Task RegisterBoat(Boat boat);
        Task RemoveBoat(int boatId);
    }
}
