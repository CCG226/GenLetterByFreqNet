using System.Text;

namespace GenLetterByFreqNET
{
    public class Generator
    {
        /// <summary>
        /// NOTE: USING TUPLE FOR CharacterFrequencyChart ARRAY FOR FUN TO MAXIMIZE PERFORMANCE 
        /// I recgonize it would be better for readability if Tuple for CharFrequencyChart was a class 
        /// </summary>
        private (char Character, double FrequencyValue, double CumulativeValue)[] CharFrequencyChart;
        //Default set up of all alphabet chars A-Z, generation based off of letter frequencies in english vocabulary
        public Generator()
        {
            CharFrequencyChart = FrequencyChartBuilder.Default();
        }
        //This Generator set up allows user to override default character frequency values
        //that control how likely at random chacter is to be generated 
        //pass in a array of 26 decimal values, 
        //each array position represents a alphabetical character starting at A
        public Generator(double[] overrideLetterWeights)
        {
            ArgValidator.isOverrideWeightsSizeEqualToAlphabetSize(overrideLetterWeights);

            ArgValidator.isWeightsEqualTo100(overrideLetterWeights);

            CharFrequencyChart = FrequencyChartBuilder.CustomPercent(overrideLetterWeights);

        }
        //this set up allows users to override the entire character chart
        //the char keys in the dictionary will be the charts character values
        //the double values in the dictionary will be the corresponding
        //character key's frequency value
        public Generator(Dictionary<char, double> overrideCharacterSet)
        {
            ArgValidator.isWeightsEqualTo100(overrideCharacterSet);
          
            CharFrequencyChart = FrequencyChartBuilder.CustomCharacterSet(overrideCharacterSet);
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
        //generate random int from 0 to 100,000
        //*(customized frequency charts allow for 99,500 - 100,500 to be max of random range)
        private int GenerateRandomInteger()
        {
            return new Random().Next(0, Convert.ToInt32(CharFrequencyChart[CharFrequencyChart.Length - 1].CumulativeValue) + 1);
        }

        //iterate through character chart's cumulative values
        //to map randomly generted integer to a character
        private char MapRandomValueToCharacter(int randValue)
        {

            for(int i = 0; i < CharFrequencyChart.Length; i++)
            {
                //if random value is less than or equal to cummulative value
                //of current character iterations cummulative value
                //then return current character as a character representation of
                //the randomly generated integer value 
                if (randValue <= CharFrequencyChart[i].CumulativeValue)
                {
                    return CharFrequencyChart[i].Character;
                }
    
           }
            //if for some reason we fail to map randomly generated integer
            //this should never happen
            throw new ChartMappingFailureException("Failed To Map Randomly Generated Value To A Valid Character");
            
        }
    }
}