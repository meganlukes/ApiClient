using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new HttpClient();
            var responseAsString = await client.GetStringAsync("https://official-joke-api.appspot.com/jokes/random");


            Console.WriteLine(responseAsString);
        }
    }
}
