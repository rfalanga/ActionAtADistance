using System.Deployment.Application;
using System.Windows;

namespace ActionAtaDistance1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string _Name;

        public App()
        {
            _Name = "ActionAtaDistance1";

            try
            {
                Version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (InvalidDeploymentException)
            {
                //// you cannot read publish version when app isn't installed 
                //// (e.g. during debug)
                Version = "App not installed.";
            }
        }

        public static string Name 
        { get { return _Name; } }

        public static string Version { get; set; }
    }
}
