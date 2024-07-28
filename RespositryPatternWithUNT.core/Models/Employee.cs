using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RespositryPatternWithUNT.core.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string Name { get; set; }
         
        public string photopath { get; set; }
        public DateOnly date { get; set; }

        [ForeignKey("Author")]
        public int JopId { get; set; }
        public Jop jop { get; set; }



    }
}
