using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RespositryPatternWithUNT.core.Dtos
{
    public class EmployeeDtos
    {
        public int? Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }

        public IFormFile image { get; set; }
        public DateOnly date { get; set; }

        public int JopId { get; set; }

    }
}
