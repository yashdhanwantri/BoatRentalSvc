using BoatRentalSvc.Models.EditModel;
using BoatRentalSvc.Models.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.Interfaces
{
    public interface IBoatBusinessLogic
    {
        BoatReadModel GetBoatById(int boatId);
        List<BoatReadModel> GetAllBoats();
        Task<BoatReadModel> RegisterBoat(BoatEditModel editModel);
        Task<bool> RemoveBoat(int boatId);
    }
}
