using CluedIn.Crawling.Parquet.Core;

namespace CluedIn.Crawling.Parquet
{
    public class ParquetCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<ParquetCrawlJobData>
    {
        public ParquetCrawlerJobProcessor(ParquetCrawlerComponent component) : base(component)
        {
        }
    }
}
