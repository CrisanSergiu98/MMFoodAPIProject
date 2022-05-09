using AutoMapper;
using MMFoodDesktopUILibary.Api;
using MMFoodDesktopUILibrary.Api;
using MMFoodDesktopUILibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class CategoryDisplayModel : INotifyPropertyChanged, ICategoryDisplayModel
    {
        private ICategoryEndPoint _categoryEndPoint;
        private IMapper _mapper;

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                SearchResults = _mapper.Map<List<CategoryDisplayModel>>(_categoryEndPoint.SearchByName(value));

                Console.WriteLine("");

                CallPropertyChanged(nameof(Name));
            }
        }

        public string Description { get; set; }
        public string PictureUrl { get; set; }

        public List<CategoryDisplayModel> SearchResults { get; set; }

        public CategoryDisplayModel(ICategoryEndPoint categoryEndPoint, IMapper mapper)
        {
            _categoryEndPoint = categoryEndPoint;
            _mapper = mapper;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
