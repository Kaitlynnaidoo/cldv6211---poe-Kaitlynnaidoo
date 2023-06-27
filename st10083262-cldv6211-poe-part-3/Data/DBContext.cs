using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using st10083262_cldv6211_poe_part_3.Models;

namespace st10083262_cldv6211_poe_part_3.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<st10083262_cldv6211_poe_part_3.Models.Car> Car { get; set; } = default!;

        public DbSet<st10083262_cldv6211_poe_part_3.Models.CarBodyType> CarBodyType { get; set; } = default!;

        public DbSet<st10083262_cldv6211_poe_part_3.Models.CarMake> CarMake { get; set; } = default!;

        public DbSet<st10083262_cldv6211_poe_part_3.Models.CarRental> CarRental { get; set; } = default!;

        public DbSet<st10083262_cldv6211_poe_part_3.Models.CarReturn> CarReturn { get; set; } = default!;

        public DbSet<st10083262_cldv6211_poe_part_3.Models.CarService> CarService { get; set; } = default!;

        public DbSet<st10083262_cldv6211_poe_part_3.Models.Detail> Detail { get; set; } = default!;

        public DbSet<st10083262_cldv6211_poe_part_3.Models.Driver> Driver { get; set; } = default!;

        public DbSet<st10083262_cldv6211_poe_part_3.Models.Inspector> Inspector { get; set; } = default!;
    }
}
