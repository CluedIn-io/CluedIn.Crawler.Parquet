using System.Collections.Generic;
using CluedIn.Crawling.Parquet.Core;

namespace CluedIn.Crawling.Parquet.Integration.Test
{
  public static class ParquetConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { ParquetConstants.KeyName.ApiKey, "demo" }
            };
    }
  }
}
