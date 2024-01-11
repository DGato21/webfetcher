using Application.Core.ABSApplication;
using Application.Core.ABSApplication.Interfaces;
using Application.Core.ApiFetchApplication;
using Application.Core.ApiFetchApplication.Interface;
using Application.Core.WebsiteFetchApplication;
using Application.Core.WebsiteFetchApplication.Interface;
using Infrastructure.Configuration;

namespace PresentationCLI.Controllers
{
    public class ApiFetchController
    {
        private readonly Configuration configuration;
        private readonly IApiFetchApplication apiFetchApplication;

        public ApiFetchController(Configuration configuration)
        {
            this.configuration = configuration;
            this.apiFetchApplication = new ApiFetchApplication();
        }
    }
}
