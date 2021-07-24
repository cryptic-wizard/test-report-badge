Feature: GithubApi

Background:
	Given the owner name is impolitetulip
	And the repo name is test-reporter-badge
	And the branch name is main
	And the job name is Specflow Tests

Scenario: Get Latest Jobs Returns Correct URL
	When I get the latest jobs url
	Then the latest jobs url is returned

Scenario: Get Latest Test Returns Correct URL
	When I get the latest test url
	Then the latest test url is returned

Scenario: Get Latest Test Html Returns Correct URL
	When I get the latest test html url
	Then the latest test html url is returned

Scenario: Get Latest Test Badge Returns Correct URL
	When I get the latest test badge url
	Then the latest test badge url is returned