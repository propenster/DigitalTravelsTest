using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Data.Repositories;

namespace UBAInterviewPrepAPI.Data.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }

        int Commit();
    }
}
