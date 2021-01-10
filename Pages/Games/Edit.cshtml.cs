using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Dorut_Iuga.Data;
using Project_Dorut_Iuga.Models;

namespace Project_Dorut_Iuga.Pages.Games
{
    public class EditModel : GameCategoriesPageModel
    {
        private readonly Project_Dorut_Iuga.Data.Project_Dorut_IugaContext _context;

        public EditModel(Project_Dorut_Iuga.Data.Project_Dorut_IugaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game
             .Include(b => b.Developer)
             .Include(b => b.GameCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
              .FirstOrDefaultAsync(m => m.ID == id);


            if (Game == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Game);
            ViewData["DeveloperID"] = new SelectList(_context.Set<Developer>(), "ID", "DeveloperName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookToUpdate = await _context.Game
            .Include(i => i.Developer)
            .Include(i => i.GameCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Game>(
            bookToUpdate,
            "Book",
            i => i.Title, i => i.GameType,
            i => i.Price, i => i.PublishingDate, i => i.Developer))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }
    }




}
    

