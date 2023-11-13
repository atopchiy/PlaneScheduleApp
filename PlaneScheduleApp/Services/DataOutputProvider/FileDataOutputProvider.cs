using PlaneScheduleApp.Models;
using PlaneScheduleApp.Services.FileService;

namespace PlaneScheduleApp.Services.DataOutputProvider;

public class FileDataOutputProvider : IDataOutputProvider
{
    private readonly IFileService _fileService;

    public FileDataOutputProvider(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void OutputFlights(IEnumerable<Flight> flights)
    {
        var fileName = $"FlightSchedule-{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}.json";
        var filePath = _fileService.GetDefaultFilePath(fileName);
        
        using var memoryStream = new MemoryStream();
        using var writer = new StreamWriter(memoryStream);
        
        foreach (var flight in flights)
        {
            writer.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.DayNumber}");
        }
        
        writer.Flush();
        memoryStream.Seek(0, SeekOrigin.Begin);
        
        _fileService.WriteToFile(memoryStream, filePath);
    }

    public void OutputOrders(IEnumerable<Order> orders)
    {
        var fileName = $"Order-{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}.json";
        var filePath = _fileService.GetDefaultFilePath(fileName);
        
        using var memoryStream = new MemoryStream();
        using var writer = new StreamWriter(memoryStream);
        
        foreach (var order in orders)
        {
            if (order.FlightNumber.HasValue)
            {
                writer.WriteLine($"order: {order.Name}, flightNumber: {order.FlightNumber} departure: {order.DepartureCity}, arrival: {order.ArrivalCity}, day: {order.DayNumber}");
            }
            else
            {
                writer.WriteLine($"order: {order.Name}, flightNumber: not scheduled");
            }
        }
        
        writer.Flush();
        memoryStream.Seek(0, SeekOrigin.Begin);
        
        _fileService.WriteToFile(memoryStream, filePath);
    }
}