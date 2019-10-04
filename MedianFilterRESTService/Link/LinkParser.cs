using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedianFilterRESTService.Link
{
    public class LinkParser
    {
        public static Link Parse(string data, string windowSize)
        {
            var parsedData = ParseData(data);
            var parsedWindowSize = ParseWindowSize(windowSize);
            if (parsedWindowSize > parsedData.Count())
                throw new Exception("The window size should be less than the signal length");
            return new Link(parsedData, parsedWindowSize);
        }

        private static IEnumerable<int> ParseData(string data)
        {
            var numbers = TryParseToInt32(data);
            if (numbers != null)
                return numbers;
            else
                throw new Exception("Сould not convert array of values to Int32 value. List the values separated by commas without spaces like \"1,2,3,4,5\"");
        }

        private static int ParseWindowSize(string windowSize)
        {
            if (Int32.TryParse(windowSize, out int result))
                if (result > 0)
                    return result;
                else
                    throw new Exception("The window size must be more than 0!");
            else
                throw new Exception("The window size must be an Int32 value!");
        }


        private static IEnumerable<int> TryParseToInt32(string data)
        {
            var stringNumbers = data.Split(',');
            List<int> intNumbers = new List<int>();
            foreach(var stringNumber in stringNumbers)
            {
                if (!Int32.TryParse(stringNumber, out int intValue))
                    return null;
                else
                    intNumbers.Add(intValue);
            }
            return intNumbers;

        }
    }
}