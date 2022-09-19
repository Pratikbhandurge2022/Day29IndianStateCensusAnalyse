using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CensusAnalyzer.DTO;
namespace CensusAnalyzer
{
    public class CensusAnalyzer
    {
        public enum Country
        {
            INDIA
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdaptorFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}