using BoatRentalSvc.Classes;
using BoatRentalSvc.Interfaces;
using BoatRentalSvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalSvc.BusinessLogic
{
    public class BoatRentalBusinessLogic : IBoatRentalBusinessLogic
    {
        private BoatDbContext _dbContext;
        private IBoatBusinessLogic _boatBusinessLogic;
        public BoatRentalBusinessLogic(BoatDbContext dbContext, IBoatBusinessLogic boatBusinessLogic)
        {
            _dbContext = dbContext;
            _boatBusinessLogic = boatBusinessLogic;
        }

        public BoatRental GetBoatRental(int boatId, DateTime asOfTime)
        {
            using (_dbContext)
            {
                var result = _dbContext.BoatRentals.FirstOrDefault(x => x.BoatId == boatId && asOfTime >= x.StartTime && asOfTime <= x.EndTime);
                return result;
            }
        }

        public List<BoatRental> GetBoatRentals()
        {
            using (_dbContext)
            {
                var result = _dbContext.BoatRentals?.ToList();
                return result;
            }
        }

        public async Task<BoatRental> RentBoat(int boatId, string customerName, DateTime From)
        {
            BoatRental boatRental = new BoatRental
            {
                BoatId = boatId,
                CustomerName = customerName,
                StartTime = From,
                EndTime = DateTime.MaxValue
            };
            if (ValidateRentalDetails(boatRental))
            {
                using(_dbContext)
                {
                    await  _dbContext.BoatRentals.AddAsync(boatRental);
                    await _dbContext.SaveChangesAsync();
                    return boatRental;
                }
            }
            return null;
        }

        public async Task<BoatRental> ReturnBoat(int boatId, string customerName)
        {
            using(_dbContext)
            {
                var boatRental = _dbContext.BoatRentals.FirstOrDefault(x => x.BoatId == boatId && x.CustomerName == customerName);
                if(boatRental == null)
                {
                    throw new Exception($"No rented boat for this customer: {customerName} with Boat Id: {boatId}");
                }
                boatRental.EndTime = DateTime.Now;
                _dbContext.BoatRentals.Update(boatRental);
                await _dbContext.SaveChangesAsync();
                return boatRental;
            }
        }

        private bool ValidateRentalDetails(BoatRental boatRental)
        {
            using (_dbContext)
            {
                var result = _dbContext.Boats.FirstOrDefault(x => x.Id == boatRental.BoatId);
                if (result == null)
                {
                    throw new Exception("Boat ID does not exist");
                }
                var availableToRent = _dbContext.BoatRentals.FirstOrDefault(x => x.BoatId == boatRental.BoatId && x.EndTime > boatRental.EndTime);
                if(availableToRent!=null)
                {
                    throw new Exception("Boat Id is not available for rent at this moment, it is already rented to other user");
                }
            }
            if (string.IsNullOrWhiteSpace(boatRental.CustomerName))
                throw new Exception("Customer Name required");
            if (boatRental.EndTime <= boatRental.StartTime)
                throw new Exception("End time can't be less than or equal to Start time");

            return true;
        }
    }
}
