# Flight Builder Project
This project is a flight builder application written in C#. It provides functionality to retrieve flights based on specific filters. The filters include:

Departure Before Current Date Time
Arrival Before Departure
Ground Time Duration
The project follows the Factory pattern to create filters and utilizes interfaces to apply the filters, demonstrating the use of SOLID principles.

## Filters
### 1. Departure Before Current Date Time Filter
This filter selects flights that are departing before the current date and time. Any flights that have a departure time earlier than the current date and time will be included in the results.

### 2. Arrival Before Departure Filter
This filter selects flights that have any segment with an arrival date before the departure date. It ensures that flights with inconsistent arrival and departure times are filtered out.

### 3. Ground Time Duration Filter
This filter selects flights that spend more than 2 hours on the ground. It excludes flights with minimal ground time, focusing on longer layovers or connections.

## SOLID Principles
The project follows the SOLID principles by utilizing interfaces to apply filters. The use of interfaces allows for easy extensibility and enables the application of different filters without modifying the existing codebase. By adhering to these principles, the project promotes maintainability, testability, and scalability.

## Usage
To use this flight builder project, follow the steps below:

Clone or download the project repository to your local machine.
Open the project solution in your preferred C# development environment (e.g., Visual Studio).
Build the solution to ensure all dependencies are resolved.
Navigate to the FlightBuilder class in the project.
Use the FlightBuilder class to retrieve flights using the provided filters.
## Example usage:

FlightBuilder flights = new FlightBuilder();
IList<Flight> listFlights = flights.GetFlights();

List<IFilters> filters = FilterFactory.GetFilter(FilterTypes.DateTime);
Console.WriteLine("Filter those departing before current Date Time:" + Environment.NewLine);
PrintResults(listFlights, filters);


filters = FilterFactory.GetFilter(FilterTypes.ArrivalDate);
Console.WriteLine("Filter those having any segment with an arrival date before the departure date:" + Environment.NewLine);
PrintResults(listFlights, filters);

filters = FilterFactory.GetFilter(FilterTypes.OnGround);
Console.WriteLine("Filter those spending more than 2 hours on the ground:" + Environment.NewLine);
PrintResults(listFlights, filters);
  
Feel free to modify the filters applied or create your own custom filters based on your specific requirements.

## Contributing
If you would like to contribute to this flight builder project, please follow these steps:

Fork the repository.
Create a new branch for your feature or bug fix.
Implement your changes.
Test your changes thoroughly.
Create a pull request, providing a detailed description of your changes.
Please ensure your code adheres to the existing coding style and includes appropriate unit tests.

## License
  This project is licensed under the <b>MIT License</b>. Feel free to use, modify, and distribute it as per the license terms.

## Acknowledgements
  This project was developed by <b><u>Muneeb Ur Rehman</u></b>. Special thanks to the open-source community for their contributions and support.

  For any questions or inquiries, please contact <u>muneeb110@live.com</u>.
