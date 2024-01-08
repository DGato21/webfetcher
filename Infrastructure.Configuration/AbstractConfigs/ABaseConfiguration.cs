namespace Infrastructure.Configuration.AbstractConfigs
{
    /// <summary>
    /// Base Configuration interface to encapsulate all the configurations available in a single interface type
    /// </summary>
    public abstract class ABaseConfiguration
    {
        public string MainPageURL { get; set; }

        public readonly WebFetchType FetchType;
    }
}
