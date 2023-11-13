using PlaneScheduleApp.Models;

namespace PlaneScheduleApp.Operations.Flights;

public class FlightGetList
{
    private readonly PlaneScheduleDb _db;

    public FlightGetList(PlaneScheduleDb db)
    {
        _db = db;
    }

    public IEnumerable<Flight> Invoke()
    {
        return _db.Flights.ToList();
    }
}