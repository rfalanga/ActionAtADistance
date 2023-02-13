using ActionAtaDistance1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
//using System.Deployment.Application;  //Not sure this is needed; and might not have the assembly included
using System.Linq;
using System.Net;
using System.Windows;

namespace ActionAtaDistance1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string _Name;

        private static AuthorsModel authorsModel;

        public App()
        {
            _Name = "ActionAtaDistance1";

            // Note: not deploying this app anyway; it is used for demo purposes only

            //try
            //{
            //    Version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            //}
            //catch (InvalidDeploymentException)
            //{
            //    //// you cannot read publish version when app isn't installed 
            //    //// (e.g. during debug)
            //    Version = "App not installed.";
            //}

            // TODO: in order to illustrate a global dependence upon Action at a Distance, might want to create a static class, with a AuthorModel in it
            authorsModel = new AuthorsModel(new DbContextOptions<AuthorsModel>());

            if (ConfigurationManager.AppSettings["EnableLogging"] != null)
            {
                if (ConfigurationManager.AppSettings["EnableLogging"].ToLower() == "true")
                {
                    Logging.CoreEventLog.EnableLogging = true;
                    try
                    {
                        Logging.CoreEventLog.IP_Address = Dns.GetHostAddresses(Environment.MachineName).FirstOrDefault().ToString();
                    }
                    catch (System.Net.Sockets.SocketException ex)
                    {
                        Logging.CoreEventLog.LogEvent("Dns.GetHostAddresses", null, null, ex.Message, true);
                    }
                }
            }

        }

        public static AuthorsModel MainDataContext 
        { 
            get { return authorsModel; }
            set { authorsModel = value; }
        }

        public static string Name 
        { get { return _Name; } }

        public static string Version { get; set; }
    }
}
