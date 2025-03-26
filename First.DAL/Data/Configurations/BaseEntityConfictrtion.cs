using First.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.DAL.Data.Configurations
{
    public class BaseEntityConfictrtion<T> : IEntityTypeConfigrtion<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder) 
        {
            builder.Property(D => D.CreateOn).HasDefaultValueSql("GETDATE()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
