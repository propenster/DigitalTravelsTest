using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.DAL.Data.Context;
using UBAInterviewPrepAPI.DAL.Data.Repositories;
using UBAInterviewPrepAPI.Domain.Models.InvestmentModels;

namespace UBAInterviewPrepAPI.DAL.Data.Repositories.InvestmentRepo
{
    public class InvestmentRepository : GenericRepository<Investment>, IInvestmentRepository
    {

        public InvestmentRepository(MyDataContext context) : base(context)
        {

        }




        public IEnumerable<Investment> FindInvestmentsForParticularUser(Guid UserId)
        {
            return FindByCondition(x => x.UserId == UserId);
        }

        public IEnumerable<Investment> GetPaginatedInvestments(int Page, int Limit)
        {
            return MyDataContext.Investments.Skip((Page - 1) * Limit).Take(Limit).ToList();
        }

        public MyDataContext MyDataContext
        {
            get
            {
                return Context;
            }
        }

    }
}
