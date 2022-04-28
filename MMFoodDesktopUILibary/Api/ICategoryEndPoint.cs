using MMFoodDesktopUILibary.Models;
using MMFoodDesktopUILibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibary.Api
{
    public interface ICategoryEndPoint
    {
        Task<List<CategoryModel>> GetAll();
    }
}