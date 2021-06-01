using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models;

namespace UBAInterviewPrepAPI.DAL.Data.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {

        //do we have custom methods we want to implement that are specific to the CarRepository alone...??
        IEnumerable<Car> GetPaginatedCars(int Page, int Limit);
    }
}
