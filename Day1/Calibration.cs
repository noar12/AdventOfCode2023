using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Day1
{
    public partial class Calibration
    {
        private readonly string[] _rawCalibrationValues;
        public Calibration(string inputFilePath)
        {
            try
            {
                _rawCalibrationValues = File.ReadAllLines(inputFilePath);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int GetCalibrationSum(bool includeSpelledDigit = false)
        {
            return includeSpelledDigit ? GetCalibrationWithSpelledValue().Sum() : GetCalibrationValue().Sum();
        }



        private List<int> GetCalibrationValue()
        {
            var output = new List<int>();
            var regex = new Regex(@"\d");//RawCalibRegex();
            foreach (string rawCalibText in _rawCalibrationValues)
            {
                string firstDigitText = regex.Matches(rawCalibText).First().Value;
                string lastDigitText = regex.Matches(rawCalibText).Last().Value;
                if (int.TryParse(firstDigitText + lastDigitText, out int calibValue))
                {
                    output.Add(calibValue);
                }
            }
            return output;
        }

        private List<int> GetCalibrationWithSpelledValue()
        {
            var output = new List<int>();
            var regex = new Regex(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine))"); //RawCalibWithSpelledDigitRegex();
            foreach (string rawCalibText in _rawCalibrationValues)
            {
                string firstDigitText = regex.Matches(rawCalibText).First().Groups[1].Value;
                int calibValue;
                if (int.TryParse(firstDigitText, out int tens))
                {
                    calibValue = tens * 10;
                }
                else
                {
                    calibValue = IntifySpelledDigit(firstDigitText) * 10;
                }
                string lastDigitText = regex.Matches(rawCalibText).Last().Groups[1].Value;
                if (int.TryParse(lastDigitText, out int unit))
                {
                    calibValue += unit;
                }
                else
                {
                    calibValue += IntifySpelledDigit(lastDigitText);
                }
                //Console.WriteLine($"{rawCalibText} -> {calibValue}");
                output.Add(calibValue);
            }
            
            return output;
        }

        private int IntifySpelledDigit(string spelledDigit) =>
            spelledDigit switch
            {
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => throw new InvalidCastException($"{spelledDigit} is not a valid number")
            };


        //[GeneratedRegex(@"\d")]
        //private static partial Regex RawCalibRegex();
        //[GeneratedRegex(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine))")]
        //private static partial Regex RawCalibWithSpelledDigitRegex();
    }
}
