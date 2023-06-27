using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10083262_cldv6211_poe_part_3.Data;
using st10083262_cldv6211_poe_part_3.Models;

namespace st10083262_cldv6211_poe_part_3.Pages.CarRentalPages
{
    public class IndexModel : PageModel
    {
        private readonly st10083262_cldv6211_poe_part_3.Data.DBContext _context;

        public IndexModel(st10083262_cldv6211_poe_part_3.Data.DBContext context)
        {
            _context = context;
        }

        public IList<CarRental> CarRental { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CarRental != null)
            {
                CarRental = await _context.CarRental
                .Include(c => c.CarNoNavigation)
                .Include(c => c.Driver)
                .Include(c => c.Inspector).ToListAsync();
            }
        }
    }
}
