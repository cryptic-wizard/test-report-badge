using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace TestReporterBadge
{
    public static class GithubApi
    {
        public static string GetLatestJobsUrl(string owner, string repo, string branch = null)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.github.com/");
            RestRequest request = new RestRequest("repos/" + owner + '/' + repo + "/actions/runs");
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

                if (branch == null)
                {
                    workflowRunToken = workflowRunTokens.SelectToken("[0]");
                    string jobsUrl = workflowRunToken.SelectToken("jobs_url").ToString();
                    return jobsUrl;
                }
                else
                {
                    for (uint i = 0; i < totalCount; i++)
                    {
                        workflowRunToken = workflowRunTokens.SelectToken('[' + i.ToString() + ']');
                        headBranch = workflowRunToken.SelectToken("head_branch").ToString();

                        if (headBranch == branch)
                        {
                            string jobsUrl = workflowRunToken.SelectToken("jobs_url").ToString();
                            return jobsUrl;
                        }

                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        public static string GetLatestTestUrl(string owner, string repo, string branch, string job)
        {
            string jobsUrl = GetLatestJobsUrl(owner, repo, branch);

            RestClient client = new RestClient();
            //client.BaseUrl = new Uri("https://api.github.com/");
            RestRequest request = new RestRequest(jobsUrl);
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
                JToken jobsToken = jsonResponse.SelectToken("jobs");
                JToken jobToken;
                string jobName;

                for (uint i = 0; i < totalCount; i++)
                {
                    jobToken = jobsToken.SelectToken('[' + i.ToString() + ']');
                    jobName = jobToken.SelectToken("name").ToString();

                    if(jobName == job)
                    {
                        string htmlUrl = jobToken.SelectToken("html_url").ToString();
                        return htmlUrl;
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
