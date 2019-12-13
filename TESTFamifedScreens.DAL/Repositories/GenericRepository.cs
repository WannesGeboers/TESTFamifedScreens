using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TESTFamifedScreens.DAL.Context;

namespace TESTFamifedScreens.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FamifedDatabaseContext _context;
        private readonly DbSet<T> table = null;

        public GenericRepository(FamifedDatabaseContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Delete(int id)
        {
            var res = table.Find(id);
            if (res != null)
            {
                table.Remove(res);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
