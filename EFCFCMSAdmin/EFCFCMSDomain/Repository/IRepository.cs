using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCFCMSDomain
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }
        T Get (int id);
        void Save(T itemToBeSaved);
        void Delete(T itemToDelete);
    }
}
