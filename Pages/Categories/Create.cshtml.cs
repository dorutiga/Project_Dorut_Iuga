using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Dorut_Iuga.Data;
using Project_Dorut_Iuga.Models;

namespace Project_Dorut_Iuga.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Project_Dorut_Iuga.Data.Project_Dorut_IugaContext _context;

        public CreateModel(Project_Dorut_Iuga.Data.Project_Dorut_IugaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
