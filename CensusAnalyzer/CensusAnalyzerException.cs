using System;
using System.Runtime.Serialization;

namespace CensusAnalyzer
{

    [Serializable]
    public class CensusAnalyzerException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INCORRECT_HEADER,
            INCORRECT_DELIMITER,
            INVALID_FILE_TYPE,
            INCORRECT_DELIMETER,
            NO_SUCH_COUNTRY
        }
        public ExceptionType eType;
        public CensusAnalyzerException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }
    }
}