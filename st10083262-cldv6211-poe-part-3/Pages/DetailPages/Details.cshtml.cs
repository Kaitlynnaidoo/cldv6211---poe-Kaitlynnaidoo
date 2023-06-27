using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using st10083262_cldv6211_poe_part_3.Data;
using st10083262_cldv6211_poe_part_3.Models;

namespace st10083262_cldv6211_poe_part_3.Pages.DetailPages
{
    public class DetailsModel : PageModel
    {
        private readonly st10083262_cldv6211_poe_part_3.Data.DBContext _context;

        public DetailsModel(st10083262_cldv6211_poe_part_3.Data.DBContext context)
        {
            _context = context;
        }

      public Detail Detail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Detail == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.FirstOrDefaultAsync(m => m.DetailId == id);
            if (detail == null)
            {
                return NotFound();
            }
            else 
            {
                Detail = detail;
            }
            return Page();
        }
    }
}
