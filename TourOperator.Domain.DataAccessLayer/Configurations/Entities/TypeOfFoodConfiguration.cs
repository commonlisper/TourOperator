using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Domain.DataAccessLayer.Configurations.Entities
{
    public class TypeOfFoodConfiguration : EntityTypeConfiguration<TypeOfFood>
    {
        public TypeOfFoodConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Title).IsRequired();
            Property(t => t.Description).IsRequired().HasColumnType("varchar(max)");
            Property(t => t.CanRemove).IsOptional();
        }
    }
}
