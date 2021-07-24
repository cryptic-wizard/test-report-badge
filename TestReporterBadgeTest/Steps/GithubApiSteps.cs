using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestReporterBadge;

namespace TestReporterBadgeTest.Steps
{
    [Binding]
    public sealed class GithubApiSteps
    {
        private string org;
        private string owner;
        private string repo;
        private string user;
        private string branch;
        private string job;
        private string badgeUrl;
        private string jobsUrl;
        private string htmlUrl;
        private string checkRunsUrl;

        #region ScenarioSteps

        [BeforeScenario]
        public void BeforeScenario()
        {
            org = null;
            owner = null;
            repo = null;
            user = null;
            branch = null;
            job = null;
            jobsUrl = null;
            htmlUrl = null;
            badgeUrl = null;
        }

        [AfterScenario]
        public void AfterScenario()
        {

        }

        #endregion

        #region GivenSteps

        [Given(@"the owner name is (.*)")]
        public void GivenTheOwnerNameIsX(string owner)
        {
            this.owner = owner;
        }

        [Given(@"the job name is (.*)")]
        public void GivenTheJobNameIsX(string job)
        {
            this.job = job;
        }

        [Given(@"the repo name is (.*)")]
        public void GivenTheRepositoryNameIsX(string repo)
        {
            this.repo = repo;
        }

        [Given(@"the branch name is (.*)")]
        public void GivenTheBranchNameIsX(string branch)
        {
            this.branch = branch;
        }

        [Given(@"the user name is (.*)")]
        public void GivenTheUserNameIsX(string user)
        {
            this.user = user;
        }

        [Given(@"the org name is (.*)")]
        public void GivenTheOrgNameIsX(string org)
        {
            this.org = org;
        }

        #endregion

        #region WhenSteps

        [When(@"I get the latest jobs url")]
        public void WhenIGetTheLatestJobsUrl()
        {
            jobsUrl = GithubApi.GetLatestJobsUrl(owner, repo, branch);
        }

        [When(@"I get the latest test url")]
        public void WhenIGetTheLatestTestUrl()
        {
            checkRunsUrl = GithubApi.GetLatestTestUrl(owner, repo, branch, job);
        }

        [When(@"I get the latest test html url")]
        public void WhenIGetTheLatestTestHtmlUrl()
        {
            htmlUrl = GithubApi.GetLatestTestHtmlUrl(owner, repo, branch, job);
        }

        [When(@"I get the latest test badge url")]
        public void WhenIGetTheLatestTestBadgeUrl()
        {
            badgeUrl = GithubApi.GetLatestTestBadgeUrl(owner, repo, branch, job);
        }


        #endregion

        #region ThenSteps

        [Then(@"the latest jobs url is returned")]
        public void ThenTheLatestJobsUrlIsReturned()
        {
            Assert.IsNotNull(jobsUrl);
            Console.WriteLine(jobsUrl);
            Assert.IsTrue(jobsUrl.Contains(owner), "ERROR - Jobs URL did not contain owner");
            Assert.IsTrue(jobsUrl.Contains(repo), "ERROR - Jobs URL did not contain repo");
            Assert.IsTrue(jobsUrl.Contains("jobs"), "ERROR - Jobs URL did not contain jobs");
        }

        [Then(@"the latest test url is returned")]
        public void ThenTheLatestTestUrlIsReturned()
        {
            Assert.IsNotNull(checkRunsUrl);
            Console.WriteLine(checkRunsUrl);
            Assert.IsTrue(checkRunsUrl.Contains(owner), "ERROR - Check runs URL did not contain owner");
            Assert.IsTrue(checkRunsUrl.Contains(repo), "ERROR - Check runs URL did not contain repo");
            Assert.IsTrue(checkRunsUrl.Contains("check-runs"), "ERROR - Check runs URL did not contain check-runs");
        }

        [Then(@"the latest test html url is returned")]
        public void ThenTheLatestTestHtmlUrlIsReturned()
        {
            Assert.IsNotNull(htmlUrl);
            Console.WriteLine(htmlUrl);
            Assert.IsTrue(htmlUrl.Contains(owner), "ERROR - HTML URL did not contain owner");
            Assert.IsTrue(htmlUrl.Contains(repo), "ERROR - HTML URL did not contain repo");
            Assert.IsTrue(htmlUrl.Contains("runs"), "ERROR - HTML URL did not contain runs");
        }

        [Then(@"the latest test badge url is returned")]
        public void ThenTheLatestTestBadgeUrlIsReturned()
        {
            Assert.IsNotNull(badgeUrl);
            Console.WriteLine(badgeUrl);
            Assert.IsTrue(badgeUrl.Contains("img.shields.io/badge"), "ERROR - Badge URL did not contain img.shields.io/badge");
        }


        #endregion
    }
}
