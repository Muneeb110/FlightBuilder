using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic.FlightCodingTest
{
    public enum FilterTypes
    {
        All,
        DateTime, 
        ArrivalDate, 
        OnGround
    }
    public class FilterFactory
    {
        public static List<IFilters> GetFilter(FilterTypes type = FilterTypes.All)
        {
            List<IFilters> filters = new List<IFilters>();  
            switch (type)
            {
                case FilterTypes.DateTime:

                    filters.Add(new CurrentDateTimeFilter());
                    break;
                case FilterTypes.ArrivalDate:
                    filters.Add(new ArrivalDateFilter());
                    break;
                case FilterTypes.OnGround:
                    filters.Add(new OnGroundFilter());
                    break;
                default:
                    filters.Add(new CurrentDateTimeFilter());
                    filters.Add(new ArrivalDateFilter());
                    filters.Add(new OnGroundFilter());
                    break;
            }
            return filters;
        }
    }
    public interface IFilters
    {
        public List<Flight> ApplyFilters(IList<Flight> listFlights);
    }
    internal class CurrentDateTimeFilter : IFilters
    {
        public List<Flight> ApplyFilters(IList<Flight> listFlights)
        {
            List<Flight> list = new List<Flight>();
            foreach (var item in listFlights)
            {
                foreach (var item1 in item.Segments)
                {
                    if (item1.DepartureDate < DateTime.Now)
                        list.Add(item);
                }
            }
            return list;
        }
    }

    internal class ArrivalDateFilter : IFilters
    {
        public List<Flight> ApplyFilters(IList<Flight> listFlights)
        {
            List<Flight> list = new List<Flight>();
            foreach (var item in listFlights)
            {
                foreach (var item1 in item.Segments)
                {
                    if (item1.ArrivalDate < item1.DepartureDate)
                        list.Add(item);
                }
            }
            return list;
        }
    }

    internal class OnGroundFilter : IFilters
    {
        public List<Flight> ApplyFilters(IList<Flight> listFlights)
        {
            List<Flight> list = new List<Flight>();
            foreach (var item in listFlights)
            {
                for (int i = 0; i < item.Segments.Count()-1; i++)
                {
                    TimeSpan ts = item.Segments[i + 1].DepartureDate - item.Segments[i].ArrivalDate;
                    if (ts.TotalHours > 2)
                        list.Add(item);
                }
            }
            
            return list;
        }
    }
}
