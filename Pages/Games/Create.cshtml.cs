using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Dorut_Iuga.Data;
using Project_Dorut_Iuga.Models;

namespace Project_Dorut_Iuga.Pages.Games
{
    public class CreateModel : GameCategoriesPageModel
    {
        private readonly Project_Dorut_Iuga.Data.Project_Dorut_IugaContext _context;

        public CreateModel(Project_Dorut_Iuga.Data.Project_Dorut_IugaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DeveloperID"] = new SelectList(items: _context.Set<Developer>(), "ID", "DeveloperName");
            var Game = new Game();
            Game.GameCategories = new List<GameCategory>();
            PopulateAssignedCategoryData(_context, Game);
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newGame = new Game();
            if (selectedCategories != null)
            {
                newGame.GameCategories = new List<GameCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new GameCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newGame.GameCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Game>(
            newGame,
            "Game",
            i => i.Title, i => i.GameType,
            i => i.Price, i => i.PublishingDate, i => i.DeveloperID))
            {
                _context.Game.Add(newGame);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newGame);
            return Page();
        }



    }
}