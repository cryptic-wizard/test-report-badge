using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace TestReporterBadge
{
    class Program
    {
        private static string owner;
        private static string repo;
        private static string branch;
        private static string job;

        static void Main(string[] args)
        {
            GithubApiClient githubApiClient = new GithubApiClient();

            githubApiClient.owner = "impolitetulip";
            githubApiClient.repo = "test-reporter-badge";
            githubApiClient.branch = "main";
            githubApiClient.job = "Specflow Tests";

            githubApiClient.GetReadMeContents();
        }
    }
}
