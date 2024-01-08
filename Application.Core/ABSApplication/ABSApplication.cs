using Application.Core.ABSApplication.Interfaces;
using Domain.Core.ABSReporter;
using Domain.Services.WebFetcherService.Interfaces;
using Infrastructure.Configuration.SpecificConfigs;
using Infrastructure.Core;

namespace Application.Core.ABSApplication
{
    public class ABSApplication : IABSApplication
    {
        private readonly IWebFetcherService webFetcherService;

        public ABSApplication()
        {
            ServiceInjection.LoadServices(out this.webFetcherService);
        }

        public Task<bool> GenerateABSReport(ABSGatewayConfiguration configuration)
        {
            ABSReporter absReporter = new ABSReporter(configuration, this.webFetcherService);

            return absReporter.GenerateReport();
        }
    }
}
