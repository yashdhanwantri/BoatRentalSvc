using AutoMapper;
using BoatRentalSvc.Models.EditModel;
using BoatRentalSvc.Models.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.Classes
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<BoatEditModel, Boat>();
            CreateMap<Boat, BoatReadModel>();
        }
    }
}
