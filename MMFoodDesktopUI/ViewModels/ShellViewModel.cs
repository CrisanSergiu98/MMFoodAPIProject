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

        public ShellViewModel(CreateRecipeViewModel createRecipeVM, IEventAggregator events)
        {
            _events = events;
            _createRecpieVM = createRecipeVM;

            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_createRecpieVM);
        }
    }
}
