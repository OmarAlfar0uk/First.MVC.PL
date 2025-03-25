using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.BLL.DataTransferObjects
{
    public  class CreatedDebartmentDTO
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Code is required!")]
        [Range(100, int.MaxValue, ErrorMessage = "Code must be at least 100.")]
        public string Code { get; set; } = string.Empty;

        public DateOnly DateOfCreation { get; set; } = DateOnly.FromDateTime(DateTime.Now); 

        public string? Description { get; set; }
    }
}
