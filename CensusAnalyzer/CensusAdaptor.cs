using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CensusAnalyzer
{
    public abstract class CensusAdaptor
    {
        protected string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            if (File.Exists(csvFilePath))
            {
                throw new CensusAnalyzerException("File not found", CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyzerException("Invalid File Type", CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);

            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyzerException("Incorrect header in data", CensusAnalyzerException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}