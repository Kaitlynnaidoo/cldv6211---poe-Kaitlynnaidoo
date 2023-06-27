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
    public class DetailsModel : PageModel
    {
        private readonly st10083262_cldv6211_poe_part_3.Data.DBContext _context;

        public DetailsModel(st10083262_cldv6211_poe_part_3.Data.DBContext context)
        {
            _context = context;
        }

      public CarRental CarRental { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CarRental == null)
            {
                return NotFound();
            }

            var carrental = await _context.CarRental.FirstOrDefaultAsync(m => m.RentalId == id);
            if (carrental == null)
            {
                return NotFound();
            }
            else 
            {
                CarRental = carrental;
            }
            return Page();
        }
    }
}
