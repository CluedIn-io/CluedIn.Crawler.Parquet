using System;
using System.Collections.Generic;
using System.Text;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using Parquet.Data;

namespace CluedIn.Crawling.Parquet.ClueProducers
{
    public class DataClueProducer : BaseClueProducer<DataColumn[]>
    {
        private readonly IClueFactory _factory;

        public DataClueProducer(IClueFactory factory)
        {
            _factory = factory;
        }

        protected override Clue MakeClueImpl(DataColumn[] input, Guid id)
        {
           
            DataColumn firstColumn = input[0];

            var clue = _factory.Create("/Customer", firstColumn.Data.GetValue(0).ToString(), id);


            var data = clue.Data.EntityData;


            if (!string.IsNullOrEmpty(firstColumn.Data.GetValue(0).ToString()))
            {
                data.Name = firstColumn.Data.GetValue(0).ToString();
            }

            return clue;
        }
    }
}



