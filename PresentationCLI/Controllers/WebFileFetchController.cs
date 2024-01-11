using Application.Core.ABSApplication;
using Application.Core.ABSApplication.Interfaces;
using Application.Core.ApiFetchApplication;
using Application.Core.ApiFetchApplication.Interface;
using Application.Core.WebsiteFetchApplication;
using Application.Core.WebsiteFetchApplication.Interface;
using Infrastructure.Configuration;

namespace PresentationCLI.Controllers
{
    public class WebFileFetchController
    {
        private readonly Configuration configuration;
        private readonly IABSApplication absApplication;
        private readonly IWebsiteFetchApplication websiteFetchApplication;

        public WebFileFetchController(Configuration configuration)
        {
            this.configuration = configuration;
            this.absApplication = new ABSApplication();
            this.websiteFetchApplication = new WebsiteFetchApplication();
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

        public void FetchWebsiteApplication()
        {
            try
            {
                Console.WriteLine("WebFileFetchController.FetchWebsiteApplication: Start FetchWebsiteList.");
                this.websiteFetchApplication.FetchWebsiteList(this.configuration.configurationList).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebFileFetchController.FetchWebsiteApplication: Error {ex.Message}.");
            }
        }
    }
}
