using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Models
{
    public partial class Detail
    {
        [Key]
        [Column("DetailID")]
        public int DetailId { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [StringLength(10)]
        public string MobileNumber { get; set; }

        [InverseProperty("PersonalDetails")]
        public virtual Driver Driver { get; set; }
        [InverseProperty("PersonalDetails")]
        public virtual Inspector Inspector { get; set; }
    }
}
