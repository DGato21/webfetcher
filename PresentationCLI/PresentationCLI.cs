using Infrastructure.Configuration;
using Newtonsoft.Json;
using PresentationCLI.Controllers;

namespace PresentationCLI
{
    public class PresentationCLI
    {
        public static void Main(string[] args)
        {
            //Load Configurations
            Console.WriteLine("Main: Loading configurations.");
            Configuration configuration = LoadConfiguration();

            //Load Application Controllers
            WebFileFetchController webFileFetchController;
            LoadControllers(out webFileFetchController, configuration);

            _ = webFileFetchController.GenerateABSReport();

            //The Output file configuration is available in confs/Development.json: by default it is in the executable dir, on Output/output.csv

            Console.WriteLine("Main: Finish");
        }

        private static Configuration LoadConfiguration()
        {
            var configuration = new Configuration();

            try
            {
                string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"confs\Development.json");
                string confStr = File.ReadAllText(path);
                configuration = JsonConvert.DeserializeObject<Configuration>(confStr);
            }
            catch (Exception ex) { Console.WriteLine("Error loading configuration file. Using default configurations..."); }

            return configuration;
        }

        private static void LoadControllers(out WebFileFetchController absGatewayController,
                                            Configuration configuration)
        {
            absGatewayController = new WebFileFetchController(configuration);
        }
    }
}
