using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TourOperator.Domain.Data.DomainModel;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Domain.DataAccessLayer.Configurations.Entities
{
    public class HotelConfiguration : EntityTypeConfiguration<Hotel>
    {
        public HotelConfiguration()
        {
            Property(h => h.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(h => h.Name).IsRequired().HasMaxLength(200).HasColumnType("nvarchar");            
            Property(h => h.Description).IsOptional().HasColumnType("nvarchar(max)");
            Property(h => h.TimestampBytes).IsConcurrencyToken(true);
        }
    }
}
