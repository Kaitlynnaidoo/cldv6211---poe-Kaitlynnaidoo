using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using st10083262_cldv6211_poe_part_3.Data;
using st10083262_cldv6211_poe_part_3.Models;

namespace st10083262_cldv6211_poe_part_3.Pages.CarRentalPages
{
    public class CreateModel : PageModel
    {
        private readonly st10083262_cldv6211_poe_part_3.Data.DBContext _context;

        public CreateModel(st10083262_cldv6211_poe_part_3.Data.DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RegistrationNumber"] = new SelectList(_context.Set<CarService>(), "RegistrationNumber", "RegistrationNumber");
        ViewData["DriverId"] = new SelectList(_context.Set<Driver>(), "DriverId", "DriverId");
        ViewData["InspectorId"] = new SelectList(_context.Set<Inspector>(), "InspectorId", "InspectorId");
            return Page();
        }

        [BindProperty]
        public CarRental CarRental { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CarRental == null || CarRental == null)
            {
                return Page();
            }

            _context.CarRental.Add(CarRental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
