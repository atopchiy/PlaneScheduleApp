using PlaneScheduleApp.Models;

namespace PlaneScheduleApp.Services.DataOutputProvider;

public class ConsoleDataOutputProvider : IDataOutputProvider
{
    public void OutputFlights(IEnumerable<Flight> flights)
    {
        foreach (var flight in flights)
        {
            Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.DayNumber}");
        }
    }

    public void OutputOrders(IEnumerable<Order> orders)
    {
        foreach (var order in orders)
        {
            if (order.FlightNumber.HasValue)
            {
                Console.WriteLine($"order: {order.Name}, flightNumber: {order.FlightNumber} departure: {order.DepartureCity}, arrival: {order.ArrivalCity}, day: {order.DayNumber}");
            }
            else
            {
                Console.WriteLine($"order: {order.Name}, flightNumber: not scheduled");
            }
        }
    }
}