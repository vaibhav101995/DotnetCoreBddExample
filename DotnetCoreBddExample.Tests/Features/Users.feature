Feature: Users Resource
	

	Scenario:  Verify User can able to Login using EmailID & Password
	Given I open the Employee Dashboard &  able to see User login page 
    And I fill "John12@gmail.com" into  the emailID textbox && "John1234" into the Password textbox  
	When I click   the "Submit"  button
	Then validate "John1234"  User password on the screen && user can able to login Employee Dashboard 


Scenario: Verify Admin can open employee dashboard for adding new user
    Given I open the  Sample Portal 
	And I click the "Add User" Button to  add user details from employee dasboard
	And New page will open to fill  new user data 
    And I fill following  user data '{"EmailID":"suraj@lti.com","ProfilePassword":"Newuser1233","UserRole":"Employee" }'
    When I click on the "Add User"  button
    Then validate "suraj@lti.com" as new  userEMailID into user details & user is created 
