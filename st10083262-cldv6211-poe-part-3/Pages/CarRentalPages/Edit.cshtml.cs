using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using st10083262_cldv6211_poe_part_3.Data;
using st10083262_cldv6211_poe_part_3.Models;

namespace st10083262_cldv6211_poe_part_3.Pages.CarRentalPages
{
    public class EditModel : PageModel
    {
        private readonly st10083262_cldv6211_poe_part_3.Data.DBContext _context;

        public EditModel(st10083262_cldv6211_poe_part_3.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarRental CarRental { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CarRental == null)
            {
                return NotFound();
            }

            var carrental =  await _context.CarRental.FirstOrDefaultAsync(m => m.RentalId == id);
            if (carrental == null)
            {
                return NotFound();
            }
            CarRental = carrental;
           ViewData["RegistrationNumber"] = new SelectList(_context.Set<CarService>(), "RegistrationNumber", "RegistrationNumber");
           ViewData["DriverId"] = new SelectList(_context.Set<Driver>(), "DriverId", "DriverId");
           ViewData["InspectorId"] = new SelectList(_context.Set<Inspector>(), "InspectorId", "InspectorId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CarRental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarRentalExists(CarRental.RentalId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarRentalExists(int id)
        {
          return (_context.CarRental?.Any(e => e.RentalId == id)).GetValueOrDefault();
        }
    }
}
