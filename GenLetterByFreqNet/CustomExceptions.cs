using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenLetterByFreqNET
{
    internal class InvalidOverrideWeightArraySize : Exception

    {

        public InvalidOverrideWeightArraySize() { }

        public InvalidOverrideWeightArraySize(string message)
            : base(message) { }
    }
    internal class InvalidCharacterAmountException : Exception

    {

        public InvalidCharacterAmountException() { }

        public InvalidCharacterAmountException(string message)
            : base(message) { }
    }
    internal class InvalidWeightTotalException : Exception

    {

        public InvalidWeightTotalException() { }

        public InvalidWeightTotalException(string message)
            : base(message) { }
    }
}
