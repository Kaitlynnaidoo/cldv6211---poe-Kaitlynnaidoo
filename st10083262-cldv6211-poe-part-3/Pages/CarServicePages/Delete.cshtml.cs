using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10083262_cldv6211_poe_part_3.Data;
using st10083262_cldv6211_poe_part_3.Models;

namespace st10083262_cldv6211_poe_part_3.Pages.CarServicePages
{
    public class DeleteModel : PageModel
    {
        private readonly st10083262_cldv6211_poe_part_3.Data.DBContext _context;

        public DeleteModel(st10083262_cldv6211_poe_part_3.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CarService CarService { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CarService == null)
            {
                return NotFound();
            }

            var carservice = await _context.CarService.FirstOrDefaultAsync(m => m.RegistrationNumber == id);

            if (carservice == null)
            {
                return NotFound();
            }
            else 
            {
                CarService = carservice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.CarService == null)
            {
                return NotFound();
            }
            var carservice = await _context.CarService.FindAsync(id);

            if (carservice != null)
            {
                CarService = carservice;
                _context.CarService.Remove(CarService);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
