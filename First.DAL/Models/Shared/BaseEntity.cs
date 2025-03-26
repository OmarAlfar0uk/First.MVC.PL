using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.DAL.Models.Shared
{
   public  class BaseEntity
    {
        public int Id { get; set; } //pk

        public int CreatedBy { get; set; } //User Id

        public DateTime CreateOn { get; set; }

        public int LastModifiedBy { get; set; } //UserId

        public DateTime LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; } //SoftDelet
    }
}
