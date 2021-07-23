using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace TestReporterBadge
{
    public static class GithubApi
    {
        public static WorkflowRun GetLatestWorkflowRun(string user, string repo, string branch)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.github.com/");
            RestRequest request = new RestRequest("repos/" + user + '/' + repo + "/actions/runs");
            IRestResponse response;

            try
            {
                response = client.Get(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("ERROR - HTTP status code = " + response.StatusCode.ToString());
                }

                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
                uint totalCount = uint.Parse(jsonResponse.SelectToken("total_count").ToString());
                JToken workflowRunTokens = jsonResponse.SelectToken("workflow_runs");
                JToken workflowRunToken;
                string headBranch;

                for (uint i = 0; i < totalCount; i++)
                {
                    workflowRunToken = workflowRunTokens.SelectToken('[' + i.ToString() + ']');
                    headBranch = workflowRunToken.SelectToken("head_branch").ToString();

                    if (headBranch == branch)
                    {
                        string url = workflowRunToken.SelectToken("url").ToString();
                        url = url.Replace("https://api.github.com/repos", "https://github.com");
                        WorkflowRun workflowRun = new WorkflowRun();
                        workflowRun.url = url;
                        return workflowRun;
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
