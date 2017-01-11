Feature: ShareMyRide
	
Scenario: Valid Ride Posting
	Given user "Naveen" has entered "Office", "Home" at "5pm"
	And user email "naveenhome" and phone is "9810547500"
	When I press "Share my ride"
	Then the message should be "Ride has been shared!"
