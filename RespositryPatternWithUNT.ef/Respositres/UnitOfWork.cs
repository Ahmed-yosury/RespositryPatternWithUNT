using RespositryPatternWithUNT.core.Interfaces;
using RespositryPatternWithUNT.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositryPatternWithUNT.ef.Respositres
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRespositry<Employee> Employees { get; private set; }
        public IJopRespositry Jops { get; private set; }



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            
            Employees =new BaseRespositry<Employee>(_context);
            Jops=new jopRespositry(_context);
        }

        public int complate()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
