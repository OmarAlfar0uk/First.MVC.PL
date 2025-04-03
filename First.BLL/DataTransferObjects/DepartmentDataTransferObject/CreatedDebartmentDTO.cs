using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.BLL.DataTransferObjects.DepartmentDataTransferObject
{
    public  class CreatedDebartmentDTO
    {
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public DateOnly DateOfCreation { get; set; }

        public string? Description { get; set; }
    }
}
