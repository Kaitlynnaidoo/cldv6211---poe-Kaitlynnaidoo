using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Models
{
    public partial class CarBodyType
    {
        public CarBodyType()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        [Column("BodyTypeID")]
        public int BodyTypeId { get; set; }
        [StringLength(50)]
        public string BodyTypeName { get; set; }

        [InverseProperty(nameof(Car.BodyType))]
        public virtual ICollection<Car> Cars { get; set; }
    }
}
