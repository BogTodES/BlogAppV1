using BlogAppV1.Common;
using BlogAppV1.DataAccess;
using BlogAppV1.DataAccess.EFConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.DataAccess
{
    public class BaseRepository<TEntiy>
        where TEntiy : class, IEntity
    {
        private readonly BlogAppDBContext _context;
        protected DbSet<TEntiy> Query;
        public BaseRepository(BlogAppDBContext context)
        {
            this._context = context;
            Query = _context.Set<TEntiy>();
        }

        public IQueryable<TEntiy> Get()
        {
            return Query.AsQueryable();
        }

        public TEntiy Insert(TEntiy entity)
        {
            Query.Add(entity);
            return entity;
        }

        public TEntiy Update(TEntiy entitty)
        {
            Query.Update(entitty);

            return entitty;
        }

        public void Delete(TEntiy entity)
        {
            Query.Remove(entity);
        }
    }
}
