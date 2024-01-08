using Domain.Services.WebFetcherService.Model;

namespace Infrastructure.Configuration.SpecificConfigs
{
    public class ABSGatewayConfiguration
    {
        public string MainPageBaseURL { get; set; } = "https://www.abs.gov.au";
        public string MainPageRelativeURL { get; set; } = "/statistics/labour/employment-and-unemployment/labour-force-australia";

        public string DownloadFileFolder { get; set; } = "Downloads";
        public string MainFileName { get; set; } = "data.xlsx";
        public int DateColumnNr { get; set; } = 0;
        public string DateStringFormat { get; set; } = "MMM-yyyy";

        public string OutputFileFolder { get; set; } = "Downloads";
        public string OutputFileName { get; set; } = "output.csv";

        public string SECTION_MAINPAGE_FILTER { get; set; } = ".//*[contains(@class,'view-display-id-topic_latest_release_block')]";
        public string SECTION_MAINPAGE_HREFDIV { get; set; } = "views-row";

        public string SECTION_DATAPAGE_FILTER { get; set; } = ".//*[contains(@class,'download-link file file--mime-application-vnd-openxmlformats-officedocument-spreadsheetml-sheet file--x-office-spreadsheet')]";
        public string SECTION_DATAPAGE_HREFDIV { get; set; } = "Table 1.";

        public string FILE_TABLE_SHEET { get; set; } = "Data1";
        public int? FILE_FILTERTABLE_ROWNR { get; set; } = 8;

        public ABSWebsiteRequestDto ToABSWebsiteRequestDto()
        {
            return new ABSWebsiteRequestDto
            {
                DownloadFileFolder = DownloadFileFolder,
                MainPageBaseURL = MainPageBaseURL,
                MainPageRelativeURL = MainPageRelativeURL,
                SECTION_MAINPAGE_FILTER = SECTION_MAINPAGE_FILTER,
                SECTION_MAINPAGE_HREFDIV = SECTION_MAINPAGE_HREFDIV,
                SECTION_DATAPAGE_FILTER = SECTION_DATAPAGE_FILTER,
                SECTION_DATAPAGE_HREFDIV = SECTION_DATAPAGE_HREFDIV
            };
        }
    }
}
