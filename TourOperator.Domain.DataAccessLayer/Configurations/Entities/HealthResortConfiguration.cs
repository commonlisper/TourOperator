using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperator.Domain.Data.DomainModel;

namespace TourOperator.Domain.DataAccessLayer.Configurations.Entities
{
    public class HealthResortConfiguration : EntityTypeConfiguration<HealthResort>
    {
        public HealthResortConfiguration()
        {
            Property(hr => hr.Name).IsRequired().HasMaxLength(200);
            Property(hr => hr.TimestampBytes).IsConcurrencyToken(true);
        }
    }
}
