using CluedIn.Crawling.Parquet.Core;

namespace CluedIn.Crawling.Parquet.Infrastructure.Factories
{
    public interface IParquetClientFactory
    {
        ParquetClient CreateNew(ParquetCrawlJobData parquetCrawlJobData);
    }
}
