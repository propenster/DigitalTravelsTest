using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Models.InvestmentModels;

namespace UBAInterviewPrepAPI.Data.Repositories.PortfolioRepo
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {


        public PortfolioRepository(MyDataContext context) : base(context)
        {

        }
    }


}
