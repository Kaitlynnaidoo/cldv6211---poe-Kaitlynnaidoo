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
    public class IndexModel : PageModel
    {
        private readonly st10083262_cldv6211_poe_part_3.Data.DBContext _context;

        public IndexModel(st10083262_cldv6211_poe_part_3.Data.DBContext context)
        {
            _context = context;
        }

        public IList<Driver> Driver { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Driver != null)
            {
                Driver = await _context.Driver
                .Include(d => d.PersonalDetails).ToListAsync();
            }
        }
    }
}
