﻿using AutoLotConsoleApp.EF;
using AutoLotDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
            _table.Add(entity);
            return SaveChanges();
        }

        public int AddRange(IList<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }

        public int Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException || ex is CommitFailedException)
            {
                // Thrown when there is a concurrency error or a transaction failure
                Console.WriteLine("Something went wrong: " + ex.Message);
                throw;
            }
        }

        public int Delete(int id, byte[] timeStamp)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }
        public T GetOne(int? id) => _table.Find(id);

        public virtual List<T> GetAll() => _table.ToList();

        public List<T> ExecuteQuery(string sql) => _table.SqlQuery(sql).ToList();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) => _table.SqlQuery(sql, sqlParametersObjects).ToList();
        #endregion
    }
}
