using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.DAL.Data.Context;
using UBAInterviewPrepAPI.DAL.Data.Repositories;
using UBAInterviewPrepAPI.Domain.Models.InvestmentModels;

namespace UBAInterviewPrepAPI.DAL.Data.Repositories.PortfolioRepo
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {


        public PortfolioRepository(MyDataContext context) : base(context)
        {

        }
    }


}
