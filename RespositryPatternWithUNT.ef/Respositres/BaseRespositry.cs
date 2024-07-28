using Microsoft.EntityFrameworkCore;
using RespositryPatternWithUNT.core.Const;
using RespositryPatternWithUNT.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RespositryPatternWithUNT.ef.Respositres
{
    public class BaseRespositry<T> : IBaseRespositry<T> where T : class
    {
        protected ApplicationDbContext _Context { get; set; }
        public BaseRespositry( ApplicationDbContext context)
        {
            _Context = context;
            
        }
        public T GetById(int id)
        {
            
            return _Context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _Context.Set<T>().ToList();
                
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _Context.Set<T>().ToListAsync();
        }

        public T Find(Expression<Func<T, bool>> Match)
        {
            return _Context.Set<T>().SingleOrDefault(Match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> Match, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query=_Context.Set<T>().Where(Match);
            if(take.HasValue)
                query = query.Take(take.Value);
            if(skip.HasValue)
                query = query.Skip(skip.Value);
            if (orderBy != null)
            {
                if(orderByDirection == OrderBy.Ascending)
                query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            return query.ToList();
        }

        public async Task<T> Add(T entity)
        {
            await _Context.AddAsync(entity);
            

            return entity;

        }

        public void Update(T entity)
        {
            //await _Context.Set<T>().Update(entity);
            //_Context.SaveChanges();
            //return entity;
           // _Context.Set<T>.Update(entity);
              _Context.Update(entity);
            
        }

        public void Delete(T entity)
        {
           _Context.Remove(entity);
          
        }

       
    }
}
