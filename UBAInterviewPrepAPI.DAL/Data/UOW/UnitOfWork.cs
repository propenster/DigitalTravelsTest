using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.DAL.Data.Context;
using UBAInterviewPrepAPI.DAL.Data.Repositories;

namespace UBAInterviewPrepAPI.DAL.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDataContext _context;

        public UnitOfWork(MyDataContext context)
        {
            _context = context;
            Cars = new CarRepository(_context);

        }

        public ICarRepository Cars { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
