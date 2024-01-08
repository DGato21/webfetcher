using Data.Gateway.GenericWebsiteGateway.Interfaces;
using Domain.Services.WebFetcherService.Interfaces;
using Infrastructure.Configuration;
using Infrastructure.Configuration.AbstractConfigs;
using Infrastructure.Configuration.Auxiliar;
using Infrastructure.CrossCutting;
using Infrastructure.Extensions;

namespace Domain.Core.WebsiteFetcher
{
    public class WebsiteFetcher
    {
        private readonly ABaseConfiguration configuration;
        private readonly IWebFetcherService webFetcherService;
        private readonly IGenericWebsiteGateway websiteGateway;

        public WebsiteFetcher(ABaseConfiguration configuration,
            IWebFetcherService webFetcherService,
            IGenericWebsiteGateway genericWebsiteGateway)
        {
            this.configuration = configuration;
            this.webFetcherService = webFetcherService;
            this.websiteGateway = genericWebsiteGateway;
        }

        public Task FetchWebsite(Guid requestGuid)
        {
            
            switch (this.configuration.FetchType)
            {
                case Infrastructure.Configuration.WebFetchType.Website:
                    var response = fetchSingleWebsite(this.configuration as WebsiteConfiguration);
                    break;
                case Infrastructure.Configuration.WebFetchType.AutomaticWebsite:
                    response = fetchAutomaticWebsite(this.configuration as WebsiteAutoConfiguration);
                    break;
            }

            return Task.CompletedTask;
        }

        //TODO: Check if the use of both WebPageSniffer is working correctly for a generic case

        private IList<Domain.DTO.FetchResultDTO> fetchAutomaticWebsite(WebsiteAutoConfiguration configuration)
        {
            IList<Domain.DTO.FetchResultDTO> result = new List<Domain.DTO.FetchResultDTO>();
            for (int i = 0; i < configuration.PageList.Count; i++)
            {
                AutomaticSectionFetch section = configuration.PageList[i];
                var request = Domain.DTO.Mappers.WebsiteFetcherMapper.ToWebsiteGatewayRequest(configuration);

                //Validators (implement Validators???)
                if (section == null)
                    throw new Exception($"{this.GetType().FullName}: Invalid Section definition.");

                //Check if RelativeURL is Empty
                if (request.RelativeUrl == null)
                    throw new Exception($"{this.GetType().FullName}: Missing relative URL");

                //Meaning that is a File Fetcher
                if (section.FileFetch != null)
                {
                    var data = this.websiteGateway.FetchFile(request);
                    result.Add(new Domain.DTO.FileResultDTO (
                        data.Result, 
                        section.FileFetch.OutputFolder, 
                        section.FileFetch.OutputFileName, 
                        section.FileFetch.OutputFileExtension));
                }
                else
                {
                    var response = this.websiteGateway.FetchHtml(request);
                    if (section.isRedirect)
                    {
                        string nextSite = WebPageSniffer.SearchURLFromContentDivAndClass(response.Result, section.Section.DivMainFilter, section.Section.SubDivElementFilter);
                        //In case of redirect, means that the next fetch section relative URL should be the URL that was found in here

                        if (configuration.PageList.Count < i + 1 && configuration.PageList[i + 1].receiveRelativeUrlFromPreviousSection)
                            configuration.PageList[i + 1].RelativeURL = nextSite.CleanUrl(configuration.MainPageURL);
                    }
                    if (section.saveContent)
                    {
                        result.Add(new Domain.DTO.HtmlResultDTO(response.Result));
                    }
                }
            }
            return result;
        }

        private IList<Domain.DTO.FetchResultDTO> fetchSingleWebsite(WebsiteConfiguration configuration)
        {
            IList<Domain.DTO.FetchResultDTO> result = new List<Domain.DTO.FetchResultDTO>(1); //It will have only one response

            try
            {
                SectionFetch? sectionFetch = configuration.SectionToFetch;
                FileFetchConfiguration? fileFetch = configuration.FileFetch;

                var request = Domain.DTO.Mappers.WebsiteFetcherMapper.ToWebsiteGatewayRequest(configuration);

                /*
                 * 3 Cases:
                 * - SectionFetch != null && FileFetch != null:
                 * We want to Fetch a File from a Particular Section
                 * (this case should be done using the WebsiteAutoConfiguration ideally)
                 * 
                 * - SectionFetch == null && FileFetch != null
                 *                        && RelativeURL != null:
                 * We have a RelativeURL and we want to Fetch directly the File
                 * 
                 * - SectionFetch != null && FileFetch == null
                 *                        && RelativeURL != null
                 * We want to Fetch a Particular Section directly
                 */


                if (sectionFetch != null && fileFetch != null)
                {
                    var response = this.websiteGateway.FetchHtml(request);
                    string nextSite = WebPageSniffer.SearchURLFromContentDivAndClass(response.Result, sectionFetch.DivMainFilter, sectionFetch.SubDivElementFilter);
                    request.RelativeUrl = nextSite.CleanUrl(configuration.MainPageURL);
                    var data = this.websiteGateway.FetchFile(request);

                    result.Add(new Domain.DTO.FileResultDTO(
                        data.Result,
                        fileFetch.OutputFolder,
                        fileFetch.OutputFileName,
                        fileFetch.OutputFileExtension));
                }
                else if (fileFetch != null)
                {
                    if (request.RelativeUrl == null)
                        throw new Exception($"{this.GetType().FullName}: Missing relative URL");

                    var data = this.websiteGateway.FetchFile(request);

                    result.Add(new Domain.DTO.FileResultDTO(
                        data.Result,
                        fileFetch.OutputFolder,
                        fileFetch.OutputFileName,
                        fileFetch.OutputFileExtension));
                }
                else if (sectionFetch != null)
                {
                    if (request.RelativeUrl == null)
                        throw new Exception($"{this.GetType().FullName}: Missing relative URL");

                    var response = this.websiteGateway.FetchHtml(request);

                    var data = WebPageSniffer.GetPageContentFromSection(response.Result, sectionFetch.DivMainFilter);

                    result.Add(new Domain.DTO.HtmlResultDTO(data));
                }
            }
            catch (Exception ex) { }

            return result;
        }

        //Auxiliar Methods
    }
}
