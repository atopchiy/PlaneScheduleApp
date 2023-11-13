using PlaneScheduleApp.Models;

namespace PlaneScheduleApp.Helpers;

/// <summary>
/// For internal use only
/// </summary>
internal static class DbHelper
{
    public static void Seed(PlaneScheduleDb db)
    {
        SeedFlights(db);
    }

    private static void SeedFlights(PlaneScheduleDb db)
    {
        db.Flights = new List<Flight>()
        {
            new()
            {
                DepartureCity = "YUL",
                ArrivalCity = "YYZ",
                DayNumber = 1,
                FlightNumber = 1
            },
            new()
            {
                DepartureCity = "YUL",
                ArrivalCity = "YYC",
                DayNumber = 1,
                FlightNumber = 2
            },
            new()
            {
                DepartureCity = "YUL",
                ArrivalCity = "YVR",
                DayNumber = 1,
                FlightNumber = 3
            },
            new()
            {
                DepartureCity = "YUL",
                ArrivalCity = "YYZ",
                DayNumber = 2,
                FlightNumber = 4
            },
            new()
            {
                DepartureCity = "YUL",
                ArrivalCity = "YYC",
                DayNumber = 2,
                FlightNumber = 5
            },
            new()
            {
                DepartureCity = "YUL",
                ArrivalCity = "YVR",
                DayNumber = 2,
                FlightNumber = 6
            }
        };
    }
}