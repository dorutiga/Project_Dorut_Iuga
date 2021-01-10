using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_Dorut_Iuga.Data;
using Project_Dorut_Iuga.Models;

namespace Project_Dorut_Iuga.Pages.Games
{
    public class IndexModel : PageModel

    {
        private readonly Project_Dorut_Iuga.Data.Project_Dorut_IugaContext _context;

        public IndexModel(Project_Dorut_Iuga.Data.Project_Dorut_IugaContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; }
        public GameData GameD { get; set; }
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            GameD = new GameData();

            GameD.Games = await _context.Game
            .Include(b => b.Developer)
            .Include(b => b.GameCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                GameID = id.Value;
                Game game = GameD.Games
                .Where(i => i.ID == id.Value).Single();
                GameD.Categories = game.GameCategories.Select(s => s.Category);
            }
        }

       
    }
}
