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
            owner = "impolitetulip";
            repo = "test-reporter-badge";
            branch = "main";
            job = "Specflow Tests";
            GithubApi.GetLatestTestUrl(owner, repo, branch, job);
        }
    }
}
