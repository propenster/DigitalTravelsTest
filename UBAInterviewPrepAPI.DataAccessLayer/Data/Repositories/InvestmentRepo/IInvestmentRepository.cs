using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Models.InvestmentModels;

namespace UBAInterviewPrepAPI.Data.Repositories.InvestmentRepo
{
    public interface IInvestmentRepository : IGenericRepository<Investment>
    {

        //Custom Data Access Methods for InvestmentRepo
        IEnumerable<Investment> GetPaginatedInvestments(int Page, int Limit);
        //We will use the FindByCondition here to fetch Investments for a particular User...
        IEnumerable<Investment> FindInvestmentsForParticularUser(Guid UserId);

    }
}
