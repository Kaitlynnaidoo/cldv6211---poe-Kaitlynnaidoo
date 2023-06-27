using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Models
{
    [Index(nameof(DetailId), Name = "UQ_Inspector_1", IsUnique = true)]
    public partial class Inspector
    {
        public Inspector()
        {
            CarRentals = new HashSet<CarRental>();
        }

        [Key]
        [Column("InspectorID")]
        [StringLength(4)]
        public string InspectorId { get; set; }
        [Column("DetailID")]
        public int? DetailId { get; set; }

        [ForeignKey(nameof(DetailId))]
        [InverseProperty("Inspector")]
        public virtual Detail PersonalDetails { get; set; }
        [InverseProperty(nameof(CarRental.Inspector))]
        public virtual ICollection<CarRental> CarRentals { get; set; }
    }
}
