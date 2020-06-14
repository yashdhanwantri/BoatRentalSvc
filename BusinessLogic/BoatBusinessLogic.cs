using AutoMapper;
using BoatRentalSvc.Classes;
using BoatRentalSvc.Interfaces;
using BoatRentalSvc.Models.EditModel;
using BoatRentalSvc.Models.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.BusinessLogic
{
    public class BoatBusinessLogic : IBoatBusinessLogic
    {
        public readonly IMapper _mapper;
        public readonly BoatDbContext _boatDbContext;
        public BoatBusinessLogic(IMapper mapper,BoatDbContext boatDbContext)
        {
            _mapper = mapper;
            _boatDbContext = boatDbContext;
        }
        public List<BoatReadModel> GetAllBoats()
        {
            using(_boatDbContext)
            {
                var data = _boatDbContext.Boats.ToList();
                if(data!=null)
                {
                    List<BoatReadModel> result = new List<BoatReadModel>();
                    foreach(var item in data)
                    {
                        result.Add(_mapper.Map<BoatReadModel>(item));
                    }
                    return result;
                }
                
                return null;
            }
        }

        public BoatReadModel GetBoatById(int boatId)
        {
            using(_boatDbContext)
            {
                var boat = _boatDbContext.Boats.FirstOrDefault(x=> x.Id == boatId);
                if(boat != null)
                {
                    return _mapper.Map<BoatReadModel>(boat);
                }
                return null;
            }
        }

        public async Task<BoatReadModel> RegisterBoat(BoatEditModel editModel)
        {
            var model = _mapper.Map<Boat>(editModel);
            using(_boatDbContext)
            {
                await _boatDbContext.Boats.AddAsync(model);
                await _boatDbContext.SaveChangesAsync();
            }
            return _mapper.Map<BoatReadModel>(model);
        }

        public async Task<bool> RemoveBoat(int boatId)
        {
            using(_boatDbContext)
            {
                var result = _boatDbContext.Boats.FirstOrDefault(x => x.Id == boatId);
                if (result != null)
                {
                    _boatDbContext.Boats.Remove(result);
                    await _boatDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
