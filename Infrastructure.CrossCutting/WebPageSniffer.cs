using HtmlAgilityPack;

namespace Infrastructure.CrossCutting
{
    public static class WebPageSniffer
    {
        public static string GetPageContentFromSection(string htmlContent, string section)
        {
            string? content = null;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            try
            {
                var htmlNode = htmlDoc.DocumentNode.SelectNodes(section);

                if (htmlNode.Any())
                    content = htmlNode.First().InnerHtml;
            }
            catch (Exception ex) { throw ex; }

            return content;
        }

        public static string SearchURLFromContentDivAndClass(string htmlContent, string sectionFilter, string classFilter)
        {
            string? url = null;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            try
            {
                var htmlNode = htmlDoc.DocumentNode.SelectNodes(sectionFilter);

                url = htmlNode.Descendants("div")
                    .Where(div => div.HasClass(classFilter))
                    .First().Descendants("a")
                    .Select(a => a.GetAttributeValue("href", ""))
                    .Where(link => !string.IsNullOrEmpty(link))
                    .FirstOrDefault();
            }
            catch (Exception ex) { throw ex; }


            return url;
        }

        public static string SearchURLFromContentAElementAndAriaLabel(string htmlContent, string section, string ariaLabelFilter)
        {
            string? url = null;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            try
            {
                var htmlNode = htmlDoc.DocumentNode.SelectNodes(section);

                url = htmlNode.Descendants("a")
                    .Where(a => a.GetAttributeValue("aria-label", "").Contains(ariaLabelFilter, StringComparison.InvariantCultureIgnoreCase))
                    .Select(a => a.GetAttributeValue("href", ""))
                    .Where(link => !string.IsNullOrEmpty(link))
                    .FirstOrDefault();
            }
            catch (Exception ex) { throw ex; }


            return url;
        }

        //DEPRECATED
        /*
        private static string findHRefRecursive(INode element)
        {
            string hRefValue = null;

            if (element != null && element.Descendants().Any())
            {
                foreach (var child in element.Descendants())
                {
                    if (child.HasChildNodes && child.ChildNodes.Length > 0) { findHRefRecursive(child); }
                    else { if (child.NodeName == "href") { return child.NodeValue; } }
                }
            }

            return hRefValue;
        }
        */
    }
}
