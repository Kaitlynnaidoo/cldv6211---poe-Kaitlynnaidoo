using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Models
{
    [Index(nameof(DetailId), Name = "UQ_Drivers_1", IsUnique = true)]
    public partial class Driver
    {
        public Driver()
        {
            CarRentals = new HashSet<CarRental>();
        }

        [Key]
        [Column("DriverID")]
        public int DriverId { get; set; }
        [Column("DetailID")]
        public int? DetailId { get; set; }
        [StringLength(60)]
        public string ResidenceAddress { get; set; }

        [ForeignKey(nameof(DetailId))]
        [InverseProperty("Driver")]
        public virtual Detail PersonalDetails { get; set; }
        [InverseProperty(nameof(CarRental.Driver))]
        public virtual ICollection<CarRental> CarRentals { get; set; }
    }
}
