using Microsoft.EntityFrameworkCore;
using RespositryPatternWithUNT.core.Interfaces;
using RespositryPatternWithUNT.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositryPatternWithUNT.ef.Respositres
{
    internal class jopRespositry : BaseRespositry<Jop>, IJopRespositry
    {
        private readonly ApplicationDbContext _context;
        public jopRespositry( ApplicationDbContext context):base(context) 
        {
            _context = context;
            
        }
        public IEnumerable<Jop> Getjops()
        {

          return   _context.Set<Jop>().ToList();   
        

        }
    }
}
