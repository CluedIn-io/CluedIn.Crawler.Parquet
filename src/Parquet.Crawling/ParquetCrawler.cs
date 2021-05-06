using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.Parquet.Core;
using CluedIn.Crawling.Parquet.Infrastructure.Factories;

namespace CluedIn.Crawling.Parquet
{
    public class ParquetCrawler : ICrawlerDataGenerator
    {
        private readonly IParquetClientFactory clientFactory;
        public ParquetCrawler(IParquetClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is ParquetCrawlJobData parquetcrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(parquetcrawlJobData);

            foreach (var objects in client.GetData("<Insert File Path to Parquet File>"))
            {
                yield return objects;
            }

        }
    }
}
