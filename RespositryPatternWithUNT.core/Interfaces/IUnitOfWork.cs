using RespositryPatternWithUNT.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositryPatternWithUNT.core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRespositry<Employee> Employees { get; }
      
        IJopRespositry Jops { get; }
        int complate();

    }
}
