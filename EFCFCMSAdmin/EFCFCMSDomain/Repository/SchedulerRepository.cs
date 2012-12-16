using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCFCMSDomain.DBContext;

namespace EFCFCMSDomain.Repository
{
    public class SchedulerRepository:IRepository<Scheduler>
    {


        public IQueryable<Scheduler> All
        {
            get { throw new NotImplementedException(); }
        }

        public void Save(Scheduler itemToBeSaved)
        {
            throw new NotImplementedException();
        }

        public void Delete(Scheduler itemToDelete)
        {
            throw new NotImplementedException();
        }


        public Scheduler Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
