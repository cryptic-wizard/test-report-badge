using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace TestReporterBadge
{
    class Program
    {
        private static RestClient client = new RestClient();
        private static string baseAddress = "https://api.github.com/";
        private static string user;
        private static string repo;

        static void Main(string[] args)
        {
            client.BaseUrl = new Uri(baseAddress);
            user = "impolitetulip";
            repo = "test-reporter-badge";
            GetActionRuns(user, repo);
        }

        static void GetActionRuns(string user, string repo)
        {
            RestRequest request = new RestRequest("repos/" + user + '/' + repo + "/actions/runs");
            IRestResponse response;

            try
            {
                response = client.Get(request);

                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("ERROR - Status Code " + response.StatusCode.ToString());
                }

                Console.WriteLine(response.Content);
                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            }
            catch(Exception)
            {

            }

            //return response;
        }
    }
}
