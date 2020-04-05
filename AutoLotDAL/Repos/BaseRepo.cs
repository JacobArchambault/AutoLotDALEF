using AutoLotConsoleApp.EF;
using AutoLotDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.Repos
{
    public class BaseRepo<T> : IDisposable,IRepo<T> where T:EntityBase, new()
    {
        private readonly DbSet<T> _table;
        private readonly AutoLotEntities _db;
        public BaseRepo()
        {
            _db = new AutoLotEntities();
            _table = _db.Set<T>();
        }
        protected AutoLotEntities Context => _db;

        #region IDisposable Support

        protected void Dispose()
        {
            _db?.Dispose();
        }
        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Save(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
