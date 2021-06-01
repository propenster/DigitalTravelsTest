using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.DAL.Data.Repositories;

namespace UBAInterviewPrepAPI.DAL.Data.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }

        int Commit();
    }
}
