Github link: https://github.com/clchou0/ItineraryAppPlanner.git

# Travel Itinerary Planner
A travel planning application developed in C# and .NET.
The application allows user to browse attractions, visualised map API, create and manage travel itineraries, and send the completed itinerary by email with generated PDF files.
The admin user can add attractions and transports.
---
This project was developed as part of the UTS subject 31927 Application Development with .NET.
---
## Features
### User Authentication
Users can:
- Create a new account
- Log in using email and password
- Reset a forgotten password using an email verification code
- Store passwords securely using password hashing
- Receive validation messages for invalid input

### Home Page
After logging in, users can access the main home page.
The home page allows users to:
- Browse cities
- Open map to view attractions' location
- Open attraction lists to view attractions' details
- Open itinerary builder to build users' own itinerary plan
- Open My itineraries to view completed itineraries

City and attraction information is loaded from the seed database.
  
### Attraction List
Users can browse attractions for the selected city.
Each attraction can display information such as:
- Attraction name
- Image
- Description
- Entry Price
- Nearby transport information

Users can select Add to Itinerary to add an attraction to one of their draft itineraries.
Admins can add and edit attraction details.

### Itinerary Builder
Users can:
- Create a new itinerary
- Select a city and dates
- Edit and Delete existing itineraries
- Add or Delete transports
- Save itinerary changes
- Edit and Delete an attraction
- Complete an itinerary plan

The builder validates itinerary dates.
