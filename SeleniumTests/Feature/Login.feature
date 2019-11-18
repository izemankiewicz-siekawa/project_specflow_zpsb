Feature: As a user I want to login to page

Scenario: I want to corret login page
Given I open home page
And I click in Sign in button 
And I write login 'testowyzpsb@email.com'
And I write password 'testzpsb'
When I click submit button
Then I see page MY ACCOUNT

