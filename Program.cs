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
            var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/random_joke");


            var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);
            foreach (var item in jokes)
            {
                Console.WriteLine($"The ID of the joke is {item.Id} and it is a {item.Type} type joke. The setup: {item.Setup}, the punchline: {item.Punchline}.");
            }
            //Menu
            Console.WriteLine();



        }
    }
}
