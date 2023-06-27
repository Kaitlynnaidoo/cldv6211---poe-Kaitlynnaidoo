using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Models
{
    public partial class CarService
    {
        public CarService()
        {
            CarRentals = new HashSet<CarRental>();
            Cars = new HashSet<Car>();
        }

        [Key]
        [StringLength(6)]
        public string RegistrationNumber { get; set; }
        [Column("KMTravelled")]
        public int? Kilometerstravelled { get; set; }
        [Column("ServicedKM")]
        public int? ServicedKilometers { get; set; }

        [InverseProperty(nameof(CarRental.CarNoNavigation))]
        public virtual ICollection<CarRental> CarRentals { get; set; }
        [InverseProperty(nameof(Car.RegisteredCar))]
        public virtual ICollection<Car> Cars { get; set; }
    }
}
