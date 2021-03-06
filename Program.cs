using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClient
{
    class Joke
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("setup")]
        public string Setup { get; set; }
        [JsonPropertyName("punchline")]
        public string Punchline { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();






            //Menu
            Console.WriteLine("Welcome to the Joke Dispenser.");
            bool joking = true;
            while (joking == true)
            {
                Console.WriteLine("Would you like some (R)andom jokes or (P)rogramming jokes?   ");
                var jokeType = Console.ReadLine().ToUpper();
                Console.WriteLine("Do you want to hear one joke, or ten? Yeah, I know it's weird, but that's all the API allows for. (One or Ten)   ");
                var jokeQuantity = Console.ReadLine().ToUpper();
                //Tell 1 random joke
                if (jokeType == "R" && jokeQuantity == "ONE")
                {
                    var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/random");
                    var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);
                    Console.WriteLine();
                    Console.WriteLine(joke.Setup);
                    Console.WriteLine(joke.Punchline);
                    Console.WriteLine();
                }
                //Tell 10 random jokes
                if (jokeType == "R" && jokeQuantity == "TEN")
                {
                    var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/ten");
                    var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);
                    Console.WriteLine();
                    foreach (var joke in jokes)
                    {
                        Console.WriteLine(joke.Setup);
                        Console.WriteLine(joke.Punchline);
                        Console.WriteLine();
                    }
                }
                //Tell 1 programming joke
                if (jokeType == "P" && jokeQuantity == "ONE")
                {
                    var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/programming/random");
                    var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);
                    Console.WriteLine();
                    foreach (var joke in jokes)
                    {
                        Console.WriteLine(joke.Setup);
                        Console.WriteLine(joke.Punchline);
                        Console.WriteLine();
                    }
                }
                //Tell 10 programming jokes
                if (jokeType == "P" && jokeQuantity == "TEN")
                {
                    var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/programming/ten");
                    var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);
                    Console.WriteLine();
                    foreach (var joke in jokes)
                    {
                        Console.WriteLine(joke.Setup);
                        Console.WriteLine(joke.Punchline);
                        Console.WriteLine();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Do you want some more jokes? (Yes or No)   ");
                var response = Console.ReadLine().ToUpper();
                if (response == "N" || response == "NO")
                {
                    joking = false;
                }
            }



        }
    }
}
