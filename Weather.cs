using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Weather
{
    class Weather
    {
        static void Main(string[] args)
        {
            var RegexDictionary = GetRegexDictionary();
            PrintRegexDictionary(RegexDictionary);                  
        }

        private static void PrintRegexDictionary(Dictionary<string, KeyValuePair<float, string>> regexDictionary)
        {

            foreach (var d in regexDictionary.OrderBy(x => x.Value.Key))
            {
                Console.WriteLine($"{d.Key} => {d.Value.Key:f2} => {d.Value.Value}");
            }
        }

        private static Dictionary<string, KeyValuePair<float, string>> GetRegexDictionary()
        {
            string pattern = @"(?<city>[A-Z]{2})(?<temperature>\d+.\d+)(?<weather>[A-Za-z]+)\|";
            string text = Console.ReadLine();
            var WeatherDictionary = new Dictionary<string, KeyValuePair<float, string>>();

            while (text != "end")
            {
                if (Regex.IsMatch(text, pattern))
                {
                    var match = Regex.Match(text, pattern);
                    var city = match.Groups["city"].Value;
                    var temperature = float.Parse(match.Groups["temperature"].Value);
                    var weather = match.Groups["weather"].Value;

                    if (!WeatherDictionary.ContainsKey(city))
                    {
                        WeatherDictionary[city] = new KeyValuePair<float, string>(temperature, weather);
                    }
                    else
                    {
                        WeatherDictionary[city] = new KeyValuePair<float, string>(temperature, weather);
                    }
                }
                text = Console.ReadLine();
            }

            return WeatherDictionary;
        }
    }
}
