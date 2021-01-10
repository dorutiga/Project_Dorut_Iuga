using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_Dorut_Iuga.Data;

namespace Project_Dorut_Iuga.Models
{
    public class GameCategoriesPageModel:PageModel
 {
 public List<AssignedCategoryData> AssignedCategoryDataList;
    public void PopulateAssignedCategoryData(Project_Dorut_IugaContext context,
    Game game)
    {
        var allCategories = context.Category;
        var gameCategories = new HashSet<int>(
        game.GameCategories.Select(c => c.GameID));
        AssignedCategoryDataList = new List<AssignedCategoryData>();
        foreach (var cat in allCategories)
        {
            AssignedCategoryDataList.Add(new AssignedCategoryData
            {
                CategoryID = cat.ID,
                Name = cat.CategoryName,
                Assigned = gameCategories.Contains(cat.ID)
            });
        }
    }
    public void UpdateBookCategories(Project_Dorut_IugaContext context,
    string[] selectedCategories, Game bookToUpdate)
    {
        if (selectedCategories == null)
        {
            bookToUpdate.GameCategories = new List<GameCategory>();
            return;
        }
        var selectedCategoriesHS = new HashSet<string>(selectedCategories);
        var bookCategories = new HashSet<int>
        (bookToUpdate.GameCategories.Select(c => c.Category.ID));
        foreach (var cat in context.Category)
        {
            if (selectedCategoriesHS.Contains(cat.ID.ToString()))
            {
                if (!bookCategories.Contains(cat.ID))
                {
                    bookToUpdate.GameCategories.Add(
                    new GameCategory
                    {
                        GameID = bookToUpdate.ID,
                        CategoryID = cat.ID
                    });
                }
            }
            else
            {
                if (bookCategories.Contains(cat.ID))
                {
                    GameCategory courseToRemove
                    = bookToUpdate
                    .GameCategories
                    .SingleOrDefault(i => i.CategoryID == cat.ID);
                    context.Remove(courseToRemove);
                }
            }
        }
    }
}

}
