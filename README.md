# Booking Reservation Console App
Welcome to the Booking Reservation Console App, a console-based application designed to help manage hotel room reservations. This project demonstrates core principles of clean code, dependency injection, and testing in C#.

## Table of Contents
* [Features](#features)
* [Technologies](#Technologies)
* [Installation](#Installation)
* [Configuration](#Configuration)
* [Usage](#Usage)
* [Testing](#Testing)
* [Contributing](#Contributing)
* [License](#License)

## Features
* Display a list of available hotels and room types.
* Select dates for a reservation and check room availability.
* Make a reservation if rooms are available.
* Basic error handling and user prompts for valid input.

## Technologies
* C# - Application language
* .NET Core - Framework
* xUnit - Testing framework
* Moq - Mocking framework for testing
* Microsoft.Extensions.DependencyInjection - Dependency injection

## Getting Started

**Prerequisites**
* [.NET Core SDK](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.403-windows-x64-installer)


## Installation
1. Clone this repository:
   ```bash
   git clone https://github.com/your-username/BookingReservationConsoleApp.git
1. Restore dependencies
    ```bash
    dotnet restore
    
##  Running the Application
1. Navigate to the project directory:
   ```bash
   cd BookingReservationConsoleApp
1. Run the application:
   ```bash
   dotnet run

## Configuration

Data Files: The application uses two JSON files for data:
* hotels.json - Contains hotel data.
* reservations.json - Contains existing reservations data.
  
Ensure these files are in the project directory with the required structure.

## Usage
1. View Hotels: The app lists available hotels from hotels.json.
2. Select a Hotel: Choose a hotel to view available room types.
3. Select Room and Dates: Choose a room type and enter your reservation dates. If available, the app confirms the reservation.
4. Exit: Follow the prompts to exit or make another reservation.

## Sample Interaction
```plaintext
Available Hotels:
- Hotel Sunshine
- Ocean View Resort
Enter hotel name (or press Enter to exit): Ocean View Resort
Available Room Types in Ocean View Resort:
- Single
- Double
- Suite
Enter room type (or press Enter to exit): Suite
No existing reservations for Suite in Ocean View Resort.
Enter start date (yyyy-MM-dd) (or press Enter to exit): 2024-10-10
Enter end date (yyyy-MM-dd) (or press Enter to exit): 2024-10-12
Reservation made successfully!
```

## Testing

This application includes unit tests for key services. To run tests, follow these steps:

1. Navigate to the test project directory:
```bash
cd BookingReservationConsoleApp.Tests
```
2. Run tests using dotnet test:
```bash
dotnet test
```
### Testing Coverage
* ReservationDateGetterService: Tests for user input validation.
* HotelService: Tests data loading from JSON.
* ReservationMakerService: Tests reservation creation with valid/invalid dates.

## Contributing
Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (```git checkout -b feature-name```).
3. Commit changes (```git commit -am 'Add feature'```).
4. Push to the branch (```git push origin feature-name```).
6. Open a pull request.
