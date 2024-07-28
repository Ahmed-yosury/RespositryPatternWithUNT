using Microsoft.EntityFrameworkCore;
using RespositryPatternWithUNT.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositryPatternWithUNT.ef
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Jop> jops { get; set; }
    }
}
