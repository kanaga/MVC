using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFMVC.Data.Infrastructure;
using EFMVC.Model;
namespace EFMVC.Data.Repositories
{
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
        {
        public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}