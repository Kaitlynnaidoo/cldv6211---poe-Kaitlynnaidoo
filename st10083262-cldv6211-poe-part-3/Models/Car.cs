﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace st10083262_cldv6211_poe_part_3.Models
{
    public partial class Car
    {
        [Key]
        [Column("CarID")]
        public int CarId { get; set; }
        [StringLength(6)]
        public string RegistrationNumber { get; set; }
        [Column("BodyTypeID")]
        public int? BodyTypeId { get; set; }
        [Column("MakeID")]
        public int? MakeId { get; set; }
        [StringLength(25)]
        public string Model { get; set; }
        public bool? IsAvailable { get; set; }

        [ForeignKey(nameof(BodyTypeId))]
        [InverseProperty(nameof(CarBodyType.Cars))]
        public virtual CarBodyType BodyType { get; set; }
        [ForeignKey(nameof(RegistrationNumber))]
        [InverseProperty(nameof(CarService.Cars))]
        public virtual CarService RegisteredCar { get; set; }
        [ForeignKey(nameof(MakeId))]
        [InverseProperty(nameof(CarMake.Cars))]
        public virtual CarMake Make { get; set; }
    }
}
