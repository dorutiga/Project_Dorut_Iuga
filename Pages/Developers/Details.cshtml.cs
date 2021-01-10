using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Dorut_Iuga.Data;
using Project_Dorut_Iuga.Models;

namespace Project_Dorut_Iuga.Pages.Developers
{
    public class DetailsModel : PageModel
    {
        private readonly Project_Dorut_Iuga.Data.Project_Dorut_IugaContext _context;

        public DetailsModel(Project_Dorut_Iuga.Data.Project_Dorut_IugaContext context)
        {
            _context = context;
        }

        public Developer Developer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Developer = await _context.Developer.FirstOrDefaultAsync(m => m.ID == id);

            if (Developer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
