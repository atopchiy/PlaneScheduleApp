namespace PlaneScheduleApp.Models;

public class Order
{
    public string Name { get; set; } = null!;
    public int? FlightNumber { get; set; }
    public string? DepartureCity { get; set; }
    public string? ArrivalCity { get; set; }
    public int? DayNumber { get; set; }
}