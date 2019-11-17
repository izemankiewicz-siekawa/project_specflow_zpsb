Feature: JSH-91_As_a_user_I_would_like_to_log_in_J.S.Hamilton_website

#--------------------------------------------------------------------------------
Background: Navigate to J.S.Hamilton website
	Given I open J.S.Hamilton login page

#--------------------------------------------------------------------------------
Scenario:[JSH-91]_LOGIN_I_can_log_into_J.S.Hamilton_website
	Given I can see login view
	When I write login 'polska1'
	And I write password '@Basic123'
	And I write tenant 'QA'
	And I click on Submit button
	Then I am logged to J.S.Hamilton main page
	And I click on Logout button

#--------------------------------------------------------------------------------
Scenario:[JSH-91]_LOGIN_I_can_log_into_J.S.Hamilton_website_without_tenant
	Given I can see login view
	When I write login 'admin'
	And I write password '123qwe'
	And I write tenant ''
	And I click on Submit button
	Then I am logged to J.S.Hamilton main page
	And I click on Logout button

#--------------------------------------------------------------------------------
#https://tracker.intive.com/jira/browse/JSHAMILTLIMS-759
Scenario:[JSH-91]_LOGIN_I_can_log_into_J.S.Hamilton_website_using_"ENTER"
	Given I can see login view
	When I write login 'admin'
	And I write password '123qwe'
	And I write tenant 'QA'
	And I click ENTER on keyboard
	Then I am logged to J.S.Hamilton main page
	And I click on Logout button

#--------------------------------------------------------------------------------
#https://tracker.intive.com/jira/browse/JSHAMILTLIMS-760
Scenario:[JSH-91]_LOGIN_I_can't_log_into_J.S.Hamilton_website._I'm_missing_all_inputs
	Given I can see login view
	When I write login ''
	And I write password ''
	And I write tenant ''
	And I click on Submit button
	Then I can see error message

#--------------------------------------------------------------------------------
#https://tracker.intive.com/jira/browse/JSHAMILTLIMS-761
Scenario:[JSH-91]_LOGIN_I_can't_log_into_J.S.Hamilton_website._User_isn't_in_database
	Given I can see login view
	When I write login 'Janusz'
	And I write password '#qaz123'
	And I write tenant ''
	And I click on Submit button
	Then I can see error message

#--------------------------------------------------------------------------------
#https://tracker.intive.com/jira/browse/JSHAMILTLIMS-762
@smoke
Scenario:[JSH-91]_LOGIN_I_can't_log_into_J.S.Hamilton_website_using_wrong_password
	Given I can see login view
	When I write login 'admin'
	And I write password '#qaz123'
	And I write tenant ''
	And I click on Submit button
	Then I can see error message

#--------------------------------------------------------------------------------
#https://tracker.intive.com/jira/browse/JSHAMILTLIMS-763
Scenario:[JSH-91]_LOGIN_I_can_log_out_form_J.S.Hamilton_webiste
	Given I can see login view
	And I am logged as default user using login 'admin' with password '123qwe' and tenant 'QA'
	When I click on Logout button
	Then I can see J.S.Hamilton login form

#--------------------------------------------------------------------------------
#https://tracker.intive.com/jira/browse/JSHAMILTLIMS-764
Scenario:[JSH-91]_LOGIN_I_can't_add_new_contractor_when_I'm_not_logged_to_J.S.Hamilton
	Given I write following website address 'http://d-hamilton.azurewebsites.net/contractor-module/create-contractor'
	Then I am redirected to J.S.Hamiltin login page