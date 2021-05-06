using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Parquet.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.Parquet.Unit.Test.ParquetProvider
{
    public abstract class ParquetProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<IParquetClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected ParquetProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<IParquetClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            Sut = new Parquet.ParquetProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
