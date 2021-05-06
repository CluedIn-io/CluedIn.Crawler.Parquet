using CluedIn.Core;
using CluedIn.Crawling.Parquet.Core;

using ComponentHost;

namespace CluedIn.Crawling.Parquet
{
    [Component(ParquetConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class ParquetCrawlerComponent : CrawlerComponentBase
    {
        public ParquetCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

