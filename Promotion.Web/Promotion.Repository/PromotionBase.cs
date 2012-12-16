using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Promotion.model;
using System.Data.Entity;

namespace Promotion.Repository
{
    public class PromotionBase<C>:IDisposable where C:DbContext,new()
    {
        private C _DataContext

        public virtual C DataContext
        {
            get{
                    if(_DataContext == null)
                    {
                        _DataContext = new C();
                        this.AllowSerialization = true
                    }
                return _DataContext
            
            }
        }
        public virtual bool AllowSerialization
        {
            get{
                return _DataContext.Configuration.ProxyCreationEnabled;
            }
            set{
                _DataContext.Configuration.ProxyCreationEnabled = !value;
            }
        }

        public virtual T Get<T>(Expression<Func<T,bool>> predicate) where T:class
        {
            if (predicate!= null)
	        {
	          using(DataContext)
            {
                return DataContext.Set<T>().Where(predicate).FirstOrDefault();
            }
        }
        else
            {
                throw.new ApplicationException("Pls pass a valid predicate expression");
            }
    }

        public IQueryable<T> GetList<T>(Expression<Func<T,bool>> predicate) where T:class
        {
           if (predicate!=null)
	        {
		         using(DataContext)
                 {
                     return DataContext.Set<T>().Where(predicate);
                 }
	        }
            else
	{
               throw.new ApplicationException("Pls pass valid predicate expression");
	}

        }

        public IQueryable<T> GetList<T,TKey>(Expression<Func<T,bool>> predicate,Expression<Func<TKey,bool>> orderby)where T:class
        {
            try 
	        {	        
		        return GetList(predicate).OrderBy(orderby);
	        }
	        catch (Exception ex)
	        {
		
		       // throw;
	        }
            return null;
        }


}
