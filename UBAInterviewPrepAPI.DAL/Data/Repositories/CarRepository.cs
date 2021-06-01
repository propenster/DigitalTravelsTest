using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.DAL.Data.Context;
using UBAInterviewPrepAPI.Domain.Models;

namespace UBAInterviewPrepAPI.DAL.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {

        public CarRepository(MyDataContext context) : base(context)
        {

        }
        public IEnumerable<Car> GetPaginatedCars(int Page, int Limit)
        {
            return MyDataContext.Cars.Skip((Page - 1) * Limit).Take(Limit).ToList();
        }

        public MyDataContext MyDataContext
        {
            get { return Context as MyDataContext; }
        }
    }
}
