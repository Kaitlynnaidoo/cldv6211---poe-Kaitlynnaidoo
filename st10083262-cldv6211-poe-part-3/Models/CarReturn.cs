using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Models
{
    public partial class CarReturn
    {
        [Key]
        [Column("ReturnID")]
        public int ReturnId { get; set; }
        [Column("RentalID")]
        public int? RentalId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ReturnDate { get; set; }
        [Column(TypeName = "money")]
        public decimal? FineAmount { get; set; }
        public int? ElapsedDays { get; set; }

        [ForeignKey(nameof(RentalId))]
        [InverseProperty(nameof(CarRental.CarReturns))]
        public virtual CarRental RentalInfo { get; set; }
    }
}
