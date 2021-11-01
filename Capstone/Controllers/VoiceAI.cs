using System;
using System.Diagnostics;
using RestSharp;

namespace Capstone.Controllers
{
    class VoiceAI
    {

        public string GetRequest(string input)
        {
            string url = "http://127.0.0.1:5000/" + input;


            var client = new RestClient(url);
            var request = new RestRequest();

            var response = client.Get(request);

            Console.WriteLine(response.Content.ToString());
            Trace.WriteLine(response.Content.ToString());

            return response.Content.ToString();
        }
    }
}
