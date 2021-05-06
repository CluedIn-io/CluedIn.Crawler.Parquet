using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.Parquet;
using CluedIn.Crawling.Parquet.Infrastructure.Factories;
using Moq;
using Shouldly;
using Xunit;

namespace Crawling.Parquet.Unit.Test
{
    public class ParquetCrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public ParquetCrawlerBehaviour()
        {
            var nameClientFactory = new Mock<IParquetClientFactory>();

            _sut = new ParquetCrawler(nameClientFactory.Object);
        }

        [Fact]
        public void GetDataReturnsData()
        {
            var jobData = new CrawlJobData();

            _sut.GetData(jobData)
                .ShouldNotBeNull();
        }
    }
}
