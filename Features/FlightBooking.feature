Feature: Flight Booking Feature

# @OneWayFlight
#   Scenario: Book a one-way flight from Mumbai to Delhi
#     Given I navigate to "https://www.ixigo.com/"
#     When I select "One Way" as the trip type
#     And I enter "Mumbai" as the departure city
#     And I enter "Delhi" as the destination city
#     And I select "March 27, 2025" as the departure date
#     And I click on the Search button
#     Then I should see a list of available flights
#     And I should be able to select flight
  
@NoFlights
	Scenario: Search for flights with no available flights
    Given I navigate to "https://www.ixigo.com/"
    When I select "One Way" as the trip type
    And I enter "Latur" as the departure city
    And I enter "Kolhapur" as the destination city
    And I select "March 27, 2025" as the departure date
    And I click on the Search button
    Then I should see a message stating "No flights found!"

#     @DirectFlightsOnly
#         Scenario: Apply filter for direct flights only
#         Given I navigate to "https://www.ixigo.com/"
#         When I select "One Way" as the trip type
#         And I enter "Mumbai" as the departure city
#         And I enter "Delhi" as the destination city
#         And I select "March 32, 2025" as the departure date
#         And I click on the Search button
#         And I apply the "Non-Stop" filter
#         Then I should see only direct flights
#     @ExcelInput
#         Scenario: Search flight by taking input from excel file
#         Given I navigate to "https://www.ixigo.com/"
#         When I select "One Way" as the trip type
#         And I enter flight details from excel file
#         And I click on the Search button
#         Then I should see the results in excel file  

