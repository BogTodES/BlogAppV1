using BlogAppV1.Common;
using BlogAppV1.DataAccess;
using BlogAppV1.DataAccess.EFConfig;
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

        public BaseRepository(BlogAppDBContext context)
        {
            this._context = context;
        }

        public IQueryable<TEntiy> Get()
        {
            return _context.Set<TEntiy>().AsQueryable();
        }

        public TEntiy Insert(TEntiy entity)
        {
            _context.Set<TEntiy>().Add(entity);
            return entity;
        }

        public TEntiy Update(TEntiy entitty)
        {
            _context.Set<TEntiy>().Update(entitty);

            return entitty;
        }

        public void Delete(TEntiy entity)
        {
            _context.Set<TEntiy>().Remove(entity);
        }
    }
}
