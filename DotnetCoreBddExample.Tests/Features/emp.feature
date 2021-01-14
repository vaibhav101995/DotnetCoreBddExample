Feature: Employee Dashboard
	
Scenario: Verify user can open Employee Dashboard for showing employee details   
	Given I  open the  Sample Portal 
	And I click  the "Employee"  MenuBar  to show  employee details
	Then validate "John Rose" as a employee Name in Employee  Details  is displayed on the screen
	
	Scenario: Verify user can open employee dashboard for adding new employee data
	Given I open the emp  Sample Portal 
	And I click on the "Employee" MenuBar to show all  employee data
	And I click the "Add" Button to  add employee details  from employee dasboard
	And New page will open  to fill  new employee data 
    And I fill following employee  details '{"EmployeeName":"Rahul Jais","Department":"IT","MailID":"rh@lti.com" }'
   Then I click on the Add Employee  button
   Then validate "Rahul Jais" as a employee  name are added into employee data 
	
	
	Scenario: Verify user can open employee dashboard for editing employee data 
	Given I open Emp Sample  Portal 
	And I click the "Employee" MenuBar   to show all employee data
	And I click the "Edit" Button to  update  existing employee details
	And New page will open with  existing  employee data 
    And I fill following employee details to update employeeName '{"EmployeeID":"21","EmployeeName":"Rohit Singh","Department":"IT","MailID":"rh@lti.com" }'
	Then I click on the Update  Employee button
    Then validate "Rohit Singh" as a employee name are  updated into employee data 
	
	
	
