/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ActionAtaDistance1"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace ActionAtaDistance1.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            //CommunityToolkit.Mvvm.DependencyInjection.Ioc(() => Ioc.Default); // TODO: I'm not sure if this line is needed, with modifications, or not.

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            Ioc.Default.Register<MainViewModel>();
            Ioc.Default.Register<AuthorsViewModel>();
            Ioc.Default.Register<MysteryBooksViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AuthorsViewModel AuthorsVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AuthorsViewModel>();
            }
        }

        public MysteryBooksViewModel MysteryBooksVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MysteryBooksViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}