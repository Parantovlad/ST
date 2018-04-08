using Microsoft.EntityFrameworkCore;
using STDAL.EF;
using STDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDAL.Repositories
{
    public abstract class BaseRepository<T> where T : class, new()
    {
        protected STDBContext Context;
        protected DbSet<T> Table;

        public T Get(int id) => Table.Find(id);
        public IEnumerable<T> GetAll() => Table.ToList();

        public void Create(T item)
        {
            Table.Add(item);
            SaveChanges();
        }

        public void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(T item)
        {
            Context.Entry(item).State = EntityState.Deleted;
            SaveChanges();
        }

        internal void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
