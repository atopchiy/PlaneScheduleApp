using PlaneScheduleApp.Models;

namespace PlaneScheduleApp.Services.DataOutputProvider;

public interface IDataOutputProvider
{
    void OutputFlights(IEnumerable<Flight> flights);
    void OutputOrders(IEnumerable<Order> orders);
}