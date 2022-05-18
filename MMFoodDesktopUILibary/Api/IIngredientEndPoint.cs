using MMFoodDesktopUILibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibary.Api
{
    public interface IIngredientEndPoint
    {        
        Task<List<IngredientModel>> SearchByName(string name);
    }
}