using PlaneScheduleApp.Helpers;
using PlaneScheduleApp.Models;
using PlaneScheduleApp.Operations.Flights;
using PlaneScheduleApp.Services.FileService;

namespace PlaneScheduleApp.Operations.Orders;

public class OrderGetListFromFile
{
    private readonly IFileService _fileService;
    private readonly FlightGetList _flightGetList;
    private const string OrderFilePath = "Resources\\coding-assigment-orders.json";
    private const int OrdersPerFlightMax = 20;

    public OrderGetListFromFile(
        IFileService fileService,
        FlightGetList flightGetList)
    {
        _fileService = fileService;
        _flightGetList = flightGetList;
    }

    public IEnumerable<Order> Invoke()
    {
        var result = new List<Order>();
        var data = _fileService.ReadFromFile(_fileService.GetDefaultFilePath(OrderFilePath));
        var orderData = data.Parse<Dictionary<string, OrderInfo>>();

        if (orderData is null)
        {
            Console.WriteLine("Couldn't fetch order list from file");
            throw new InvalidOperationException();
        }
        
        var flights = _flightGetList.Invoke();

        foreach (var flight in flights)
        {
            var orders = orderData
                .Where(_ => _.Value.Destination == flight.ArrivalCity)
                .Take(OrdersPerFlightMax)
                .ToDictionary(_ => _.Key, _ => _.Value);
                
            var flightOrders = orders.Select(_ => new Order
            {
                ArrivalCity = _.Value.Destination,
                DepartureCity = flight.DepartureCity,
                FlightNumber = flight.FlightNumber,
                Name = _.Key,
                DayNumber = flight.DayNumber
            });
            
            result.AddRange(flightOrders);
            orderData.RemoveRange(orders.Keys);
        }
        
        result.AddRange(orderData.Select(_ => new Order
        {
            Name = _.Key
        }));

        return result;
    }
}