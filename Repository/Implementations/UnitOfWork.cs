using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private OlympediaDbContext context = new OlympediaDbContext();
        private GenericRepository<Game> gameRepository;
        private GenericRepository<Athlete> athleteRepository;
        private GenericRepository<Result> resultRepository;
        public GenericRepository<Athlete> AthleteRepository
        {
            get
            {
                if (this.athleteRepository == null)
                {
                    this.athleteRepository = new GenericRepository<Athlete>(context);
                }
                return athleteRepository;
            }
        }

        public GenericRepository<Game> GameRepository
        {
            get
            {
                if (this.gameRepository == null)
                {
                    this.gameRepository = new GenericRepository<Game>(context);
                }
                return gameRepository;
            }
        }
        public GenericRepository<Result> ResultRepository
        {
            get
            {
                if (this.resultRepository == null)
                {
                    this.resultRepository = new GenericRepository<Result>(context);
                }
                return resultRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
