using GenLetterByFreqNet;
using System.Text;

namespace GenLetterByFreqNET
{
    public class CharGenerator
    {


        private readonly CharFrequencyData[] CharFrequencyChart;
        //Default set up of all alphabet chars A-Z, generation based off of letter frequencies in oxford english dictionary
        public CharGenerator(bool highAccuracyMode = true)
        {
            FrequencyChartBuilder freqChartBuilder = new FrequencyChartBuilder(highAccuracyMode);
            CharFrequencyChart = freqChartBuilder.Default();
        }
        //This set up allows users to replace the default ocford character chart.
        //The char keys in the dictionary will be the charts character values.
        //The double values in the dictionary will be the corresponding character key's frequency value.
        public CharGenerator(Dictionary<char, double> overrideCharacterSet, bool highAccuracyMode = true)
        {

            ArgValidator.isCustomSetSizeValid(overrideCharacterSet);

            ArgValidator.isWeightCustomValuesValid(overrideCharacterSet);

            FrequencyChartBuilder freqChartBuilder = new FrequencyChartBuilder(highAccuracyMode);
            CharFrequencyChart = freqChartBuilder.CustomCharacterSet(overrideCharacterSet);
        }
   
        //generate single random character 
        public char GetRandomCharacter()
        {
           return MapRandomValueToCharacter(GenerateRandomInteger());
        }
        //generate multiple random characters 
        public string GetRandomCharacters(int amount)
        {
            
            ArgValidator.isAmountLessThanOrEqualToZero(amount);

            StringBuilder randomizedCharacterSequence = new StringBuilder();

            for(int i = 0; i < amount;i++)
            {
                randomizedCharacterSequence.Append(MapRandomValueToCharacter(GenerateRandomInteger()));
            }

            return randomizedCharacterSequence.ToString();

        }
        //generate random int, int corresponds to cummulative value
        private long GenerateRandomInteger()
        {
            long rangeMax = Convert.ToInt64(CharFrequencyChart[CharFrequencyChart.Length - 1].CumulativeValue) + 1;
      
            return Random.Shared.NextInt64(0, rangeMax);
        }

        //Iterates through character chart's cumulative values to map randomly generated integer to a character
        private char MapRandomValueToCharacter(long randValue)
        {

            for(int i = 0; i < CharFrequencyChart.Length; i++)
            {
                //if random value is less than or equal to cummulative value of current character iterations cummulative value
                //then return current character as a character representation of the randomly generated integer value 
                if (randValue <= CharFrequencyChart[i].CumulativeValue)
                {
                    return CharFrequencyChart[i].Character;
                }
    
           }
            //if for some reason we fail to map randomly generated integer
            //this should never happen!
            throw new ChartMappingFailureException("Failed To Map Randomly Generated Value To A Valid Character");
            
        }
    }
}
