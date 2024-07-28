using RespositryPatternWithUNT.core.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RespositryPatternWithUNT.core.Interfaces
{
    public interface IBaseRespositry<T> where T : class
    {
        T GetById(int id);  
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Find(Expression<Func<T, bool>> Match);
        IEnumerable<T> FindAll(Expression<Func<T, bool>>? Match, int? take, int? skip,
        Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

        Task<T> Add(T entity);
        void Update(T entity);
        void Delete(T  entity);
    }
}
