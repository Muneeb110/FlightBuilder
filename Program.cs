using System;
using System.Collections.Generic;

namespace TravelRepublic.FlightCodingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
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
        }

        private static void PrintResults(IList<Flight> listFlights, List<IFilters> filters)
        {
            string dateFormat = "dddd, dd MMMM yyyy HH:mm:ss";
            foreach (var item in filters)
            {
                List<Flight> filterdFlights = item.ApplyFilters(listFlights);
                foreach (Flight flight in filterdFlights)
                {
                    foreach (var segment in flight.Segments)
                    {
                        Console.WriteLine("Departure Time: " + segment.DepartureDate.ToString(dateFormat) +
                            ", Arrival Time: " + segment.ArrivalDate.ToString(dateFormat));
                    }
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
