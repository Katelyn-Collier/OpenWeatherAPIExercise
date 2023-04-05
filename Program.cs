using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPIExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Hello! Please enter your API key:");
            var key = Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter your city name:");
                var city = Console.ReadLine();
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={key}";

                var response = client.GetStringAsync(weatherURL).Result;
                var weatherResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(weatherResponse);
                Console.WriteLine();

                Console.WriteLine("Would you like to choose a different city?");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input.ToLower() == "no");
                {
                    break;
                }
            }
        }
   
    }

}