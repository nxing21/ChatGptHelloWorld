using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace MyChatGpt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {sk-SECRET}");

            var requestJson = new
            {
                prompt = "Come up with a name for a poke resturant.",
                max_tokens = 1024,
                temperature = 0.1f,
                model = "text-davinci-003"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(requestJson), Encoding.UTF8, "application/json");

            // Access API
            HttpResponseMessage response = client.PostAsync(@"https://api.openai.com/v1/completions", 
                new StringContent(JsonConvert.SerializeObject(requestJson), Encoding.UTF8, "application/json");).Result;
            
            string responseJson = response.Content.ReadAsStringAsync().Result;

            // Deserialize result
            dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

            Console.WriteLine("Result: " + responseObject.choices[0].text);

        }
    }
}
