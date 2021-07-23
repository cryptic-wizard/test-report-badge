using NUnit.Framework;
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
        private TestReporterBadge.WorkflowRun workflowRun;

        #region ScenarioSteps

        [BeforeScenario]
        public void BeforeScenario()
        {
            org = null;
            owner = null;
            repo = null;
            user = null;
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

        [When(@"I get the latest workflow run")]
        public void WhenIGetTheLatestWorkflowRun()
        {
            workflowRun = GithubApi.GetLatestWorkflowRun(owner, repo, branch);
        }

        #endregion

        #region ThenSteps

        [Then(@"the latest workflow run url is returned")]
        public void ThenTheLatestWorkflowRunUrlIsReturned()
        {
            Assert.IsNotNull(workflowRun);
            Assert.IsTrue(workflowRun.url.Contains(owner), "ERROR - Workflow run did not contain owner");
            Assert.IsTrue(workflowRun.url.Contains(repo), "ERROR - Workflow run did not contain repo");
        }

        #endregion
    }
}
