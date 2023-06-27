using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Models
{
    public partial class CarMake
    {
        public CarMake()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        [Column("MakeID")]
        public int MakeId { get; set; }
        [StringLength(20)]
        public string MakeName { get; set; }

        [InverseProperty(nameof(Car.Make))]
        public virtual ICollection<Car> Cars { get; set; }
    }
}
