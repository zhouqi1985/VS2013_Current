using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PetFeedEvents.Database.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(string dbName)
            : base(dbName)
        { }
        public List<T> GetEntityQueryList<T, U>(ref DataPage dp, Expression<Func<T, bool>> exp, Expression<Func<T, U>> orderexp) where T : class
        {

            List<T> querylist = new List<T>();
            DbSet<T> _dbset = this.Set<T>();
            dp.RowCount = _dbset.Where(exp).Count();
            if (dp.PageSize == 0)
            {
                querylist = _dbset.Where(exp).OrderByDescending(orderexp).ToList<T>();
            }
            else
            {
                querylist = _dbset.Where(exp).OrderByDescending(orderexp).Skip(dp.PageSize * (dp.PageIndex - 1)).Take(dp.PageSize).ToList<T>();
            }
            return querylist;
        }

    }
}
