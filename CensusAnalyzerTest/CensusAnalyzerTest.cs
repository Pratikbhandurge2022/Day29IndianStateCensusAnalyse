using NUnit.Framework;
using CensusAnalyzer;
using CensusAnalyzer.POCO;
using Newtonsoft.Json;
using System.Collections.Generic;
using CensusAnalyzer.DTO;
using static CensusAnalyzer.CensusAnalyzer;

namespace CensusAnalyzerTest
{
    public class CensusAnalyserTestTests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"D:\BridgeLabz\Day29\CensusAnalyzerTest\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"D:\BridgeLabz\Day29\CensusAnalyzerTest\WrongHeaderIndiaStateCodes.csv";
        static string delimiterIndianCensusFilePath = @"D:\BridgeLabz\Day29\CensusAnalyzerTest\IndianStateCensusDelimeter.csv";
        static string wrongIndianStateCensusFilePath = @"D:\BridgeLabz\Day29\CensusAnalyzerTest\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"D:\BridgeLabz\Day29\CensusAnalyzerTest\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"D:\BridgeLabz\Day29\CensusAnalyzerTest\IndiaStateCodes.CSV";
        static string wrongIndianStateCodeFileType = @"D:\BridgeLabz\Day29\CensusAnalyzerTest\IndiaStateCodes.txt";
        static string delimiterIndianStateCodeFilePath = @"D:\BridgeLabz\Day29\CensusAnalyzerTest\DelimiterIndiaStateCodes.csv";
        static string wrongHeaderStateCodeFilePath = @"D:\BridgeLabz\Day29\CensusAnalyzerTest\WrongHeaderIndiaStateCodes.csv";

        CensusAnalyzer.CensusAnalyzer censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyzer.CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}