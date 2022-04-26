using Caliburn.Micro;
using MMFoodDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>
    {        
        private CreateRecipeViewModel _createRecpieVM;
        private IEventAggregator _events;
        private SimpleContainer _contaier;

        public ShellViewModel(CreateRecipeViewModel createRecipeVM, IEventAggregator events,
            SimpleContainer container)
        {
            _events = events;
            _createRecpieVM = createRecipeVM;
            _contaier = container;

            _events.Subscribe(this);

            ActivateItem(_contaier.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_createRecpieVM);
        }
    }
}
