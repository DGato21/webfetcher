namespace Infrastructure.Extensions
{
    public static class UrlExtensions
    {
        public static string CleanUrl(this string urlStr, string basePath)
        {
            return urlStr.Replace(basePath, string.Empty);
        }
    }
}
