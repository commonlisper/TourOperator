using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TourOperator.Domain.Data.Entities
{
    [MetadataType(typeof(CountryMetadata))]
    public partial class Country
    {
        public class CountryMetadata
        {
            [Required]
            [StringLength(200, MinimumLength = 3, ErrorMessage = "Более 3х символов")]
            [Remote("CheckCountryName", "Admin")]
            public string Name { get; set; }
        }
    }    
}
