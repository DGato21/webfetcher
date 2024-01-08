using Application.Core.ABSApplication;
using Application.Core.ABSApplication.Interfaces;
using Infrastructure.Configuration;

namespace PresentationCLI.Controllers
{
    public class WebFileFetchController
    {
        private readonly Configuration configuration;
        private readonly IABSApplication absApplication;

        public WebFileFetchController(Configuration configuration)
        {
            this.configuration = configuration;
            absApplication = new ABSApplication();
        }

        public async Task<bool> GenerateABSReport()
        {
            try
            {
                Console.WriteLine("WebFileFetchController.GenerateABSReport: Generating ABS Report.");
                return await absApplication.GenerateABSReport(configuration.absGatewayConfiguration);
            }
            catch (Exception ex)
            {
                Console.WriteLine("WebFileFetchController.GenerateABSReport: Error Generating ABS Report.");
                return await Task.FromException<bool>(ex);
            }
        }
    }
}
