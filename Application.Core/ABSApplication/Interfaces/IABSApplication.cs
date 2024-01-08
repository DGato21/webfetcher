using Infrastructure.Configuration.SpecificConfigs;

namespace Application.Core.ABSApplication.Interfaces
{
    public interface IABSApplication
    {
        public Task<bool> GenerateABSReport(ABSGatewayConfiguration configuration);
    }
}
