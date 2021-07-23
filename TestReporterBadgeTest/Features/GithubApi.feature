Feature: GithubApi

Background:
	Given the owner name is impolitetulip
	And the repo name is test-reporter-badge
	And the branch name is main

Scenario: Get Latest Workflow Run Returns Correct URL
	When I get the latest workflow run
	Then the latest workflow run url is returned