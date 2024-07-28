using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositryPatternWithUNT.core.Models
{
    public class Jop
    {
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
