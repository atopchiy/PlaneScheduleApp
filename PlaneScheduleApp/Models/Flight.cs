namespace PlaneScheduleApp.Models;

public class Flight
{
    public string DepartureCity { get; set; } = null!;
    public string ArrivalCity { get; set; } = null!;
    public int DayNumber { get; set; }
    public int FlightNumber { get; set; }
}