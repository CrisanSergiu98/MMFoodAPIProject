using System.Collections.Generic;
using System.ComponentModel;

namespace MMFoodDesktopUI.Models
{
    public interface ICategoryDisplayModel
    {
        string Description { get; set; }
        string Name { get; set; }
        string PictureUrl { get; set; }
        List<CategoryDisplayModel> SearchResults { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}