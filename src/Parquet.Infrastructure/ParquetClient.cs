using System;
using System.Net;
using System.Threading.Tasks;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Parquet.Core;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Logging;
using Parquet;
using System.IO;
using Parquet.Data;
using System.Linq;
using System.Collections.Generic;

namespace CluedIn.Crawling.Parquet.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class ParquetClient
    {
        private const string BaseUri = "http://sample.com";

        private readonly ILogger<ParquetClient> log;

        private readonly IRestClient client;

        public ParquetClient(ILogger<ParquetClient> log, ParquetCrawlJobData parquetCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
        {
            if (parquetCrawlJobData == null)
            {
                throw new ArgumentNullException(nameof(parquetCrawlJobData));
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.client = client ?? throw new ArgumentNullException(nameof(client));

            // TODO use info from parquetCrawlJobData to instantiate the connection
            client.BaseUrl = new Uri(BaseUri);
            client.AddDefaultParameter("api_key", parquetCrawlJobData.ApiKey, ParameterType.QueryString);
        }

        public IEnumerable<DataColumn[]> GetData(string file)
        {
            using (Stream fileStream = System.IO.File.OpenRead(file))
            {
                // open parquet file reader
                using (var parquetReader = new ParquetReader(fileStream))
                {
                    // get file schema (available straight after opening parquet reader)
                    // however, get only data fields as only they contain data values
                    DataField[] dataFields = parquetReader.Schema.GetDataFields();

                    // enumerate through row groups in this file
                    for (int i = 0; i < parquetReader.RowGroupCount; i++)
                    {
                        // create row group reader
                        using (ParquetRowGroupReader groupReader = parquetReader.OpenRowGroupReader(i))
                        {
                            // read all columns inside each row group (you have an option to read only
                            // required columns if you need to.
                            yield return dataFields.Select(groupReader.ReadColumn).ToArray();
                        }
                    }
                }
            }
        }

        public AccountInformation GetAccountInformation()
        {
            //TODO - return some unique information about the remote data source
            // that uniquely identifies the account
            return new AccountInformation("", "");
        }
    }
}
