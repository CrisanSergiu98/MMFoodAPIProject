using Caliburn.Micro;
using MMFoodDesktopUI.Models;
using MMFoodDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MMFoodDesktopUI
{
    public class Bootstrapper: BootstrapperBase
    {
        /// <summary>
        /// A DependencyInjection system that Caliburn.Micro has
        /// </summary>
        private SimpleContainer _container = new SimpleContainer();

        /// <summary>
        /// The Constructor
        /// </summary>
        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }

        /// <summary>
        /// Overrite of Configure to use our DI Container
        /// </summary>
        protected override void Configure()
        {
            _container.Instance(_container);

            // Creating singletons for WindowManager and EventAggregator so we don't create multiple instances for it
            // A Singleton creates an isntance of the class for scopted for the lifetime of the application
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();
            // Using Reflection we are going to map all our Views and ViewModels to use our DI System
            // For now the ViewModels wont have Interfaces, they are going to when we set up the Unit Test Class
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        /// <summary>
        /// Override of the OnStartup from Bootstrapper.
        /// We are going to Diplay our ShellView here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        /// <summary>
        /// Override the GetIsntance from Bootstrapper to use our Caliburn.Micro DI Container.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        /// <summary>
        /// Override the GetAllIsntances as well
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        /// <summary>
        /// Override the Build up so it uses the Caliburn.Micro DI Container.
        /// </summary>
        /// <param name="instance"></param>
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
