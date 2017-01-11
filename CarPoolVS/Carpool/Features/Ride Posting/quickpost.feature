Feature: quickpost
	Ir order to share my car
	As an employee
	I want to post my ride with others

Scenario Outline: Quickpost testing
Given <empname> enter <source> and <destination> and <time>
And his <email> and <phone>
When click on <button>
Then system display <message> with <actionButton> button
And click on OK button will redirect on <page>
Examples: 
| empname  | source   | destination    | time   | email                  | phone        | button  | message        | actionButton | page   |
| "Naveen" | "Office" | "Kammanahalli" | "5:30" | "naveenhome@gmail.com" | "9810547500" | "Share" | "Ride shared." | "Ok"         | "Home" |
| "Naveen" | "Office" | "Kammanahalli" | "5:30" | "naveenhome@gmail.com" | " " | "Share" | "Phone No is required." | "Ok"         | "Quick Post" |