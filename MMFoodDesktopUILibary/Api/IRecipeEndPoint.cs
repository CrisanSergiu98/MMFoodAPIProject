using MMFoodDesktopUILibrary.Models;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibary.Api
{
    public interface IRecipeEndPoint
    {
        Task PostRecipe(RecipeModel recipe);
    }
}