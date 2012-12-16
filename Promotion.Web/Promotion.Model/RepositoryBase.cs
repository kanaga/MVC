using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Promotion.Model;
using System.Data.Entity;
namespace Promotion.Model
{
    public class RepositoryBase<C>:IDisposable
        where C :DbContext,new()
    {

    }
}
