using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Models
{
    public partial class CarRental
    {
        public CarRental()
        {
            CarReturns = new HashSet<CarReturn>();
        }

        [Key]
        [Column("RentalID")]
        public int RentalId { get; set; }
        [StringLength(6)]
        public string RegistrationNumber { get; set; }
        [Column("InspectorID")]
        [StringLength(4)]
        public string InspectorId { get; set; }
        [Column("DriverID")]
        public int? DriverId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "money")]
        public decimal? RentalPrice { get; set; }

        [ForeignKey(nameof(RegistrationNumber))]
        [InverseProperty(nameof(CarService.CarRentals))]
        public virtual CarService CarNoNavigation { get; set; }
        [ForeignKey(nameof(DriverId))]
        [InverseProperty("CarRentals")]
        public virtual Driver Driver { get; set; }
        [ForeignKey(nameof(InspectorId))]
        [InverseProperty("CarRentals")]
        public virtual Inspector Inspector { get; set; }
        [InverseProperty(nameof(CarReturn.RentalInfo))]
        public virtual ICollection<CarReturn> CarReturns { get; set; }
    }
}
