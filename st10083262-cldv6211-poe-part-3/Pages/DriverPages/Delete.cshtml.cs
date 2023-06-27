using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10083262_cldv6211_poe_part_3.Data;
using st10083262_cldv6211_poe_part_3.Models;

namespace st10083262_cldv6211_poe_part_3.Pages.DriverPages
{
    public class DeleteModel : PageModel
    {
        private readonly st10083262_cldv6211_poe_part_3.Data.DBContext _context;

        public DeleteModel(st10083262_cldv6211_poe_part_3.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Driver Driver { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Driver == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver.FirstOrDefaultAsync(m => m.DriverId == id);

            if (driver == null)
            {
                return NotFound();
            }
            else 
            {
                Driver = driver;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Driver == null)
            {
                return NotFound();
            }
            var driver = await _context.Driver.FindAsync(id);

            if (driver != null)
            {
                Driver = driver;
                _context.Driver.Remove(Driver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
