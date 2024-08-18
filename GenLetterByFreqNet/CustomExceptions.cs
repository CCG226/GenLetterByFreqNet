using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenLetterByFreqNET
{

    internal class InvalidCharacterAmountException : Exception

    {

        public InvalidCharacterAmountException() { }

        public InvalidCharacterAmountException(string message)
            : base(message) { }
    }
    internal class InvalidWeightException : Exception

    {

        public InvalidWeightException() { }

        public InvalidWeightException(string message)
            : base(message) { }
    }
    internal class ChartMappingFailureException : Exception

    {

        public ChartMappingFailureException() { }

        public ChartMappingFailureException(string message)
            : base(message) { }
    }
}
