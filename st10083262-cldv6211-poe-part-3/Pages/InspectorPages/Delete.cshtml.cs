using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10083262_cldv6211_poe_part_3.Data;
using st10083262_cldv6211_poe_part_3.Models;

namespace st10083262_cldv6211_poe_part_3.Pages.InspectorPages
{
    public class DeleteModel : PageModel
    {
        private readonly st10083262_cldv6211_poe_part_3.Data.DBContext _context;

        public DeleteModel(st10083262_cldv6211_poe_part_3.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Inspector Inspector { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Inspector == null)
            {
                return NotFound();
            }

            var inspector = await _context.Inspector.FirstOrDefaultAsync(m => m.InspectorId == id);

            if (inspector == null)
            {
                return NotFound();
            }
            else 
            {
                Inspector = inspector;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Inspector == null)
            {
                return NotFound();
            }
            var inspector = await _context.Inspector.FindAsync(id);

            if (inspector != null)
            {
                Inspector = inspector;
                _context.Inspector.Remove(Inspector);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
