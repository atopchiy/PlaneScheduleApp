using PlaneScheduleApp.Helpers;
using PlaneScheduleApp.Operations.Flights;
using PlaneScheduleApp.Operations.Orders;
using PlaneScheduleApp.Services.DataOutputProvider;

namespace PlaneScheduleApp.Services.AppStarterService;

public class AppStarterService
{
    private readonly DataOutputResolver _resolver;
    private readonly PlaneScheduleDb _db;
    private readonly FlightGetList _getFlightList;
    private readonly OrderGetListFromFile _getOrderList;

    public AppStarterService(
        DataOutputResolver resolver,
        PlaneScheduleDb db,
        FlightGetList getFlightList,
        OrderGetListFromFile getOrderList)
    {
        _resolver = resolver;
        _db = db;
        _getFlightList = getFlightList;
        _getOrderList = getOrderList;
    }

    public void Run()
    {
        DbHelper.Seed(_db);
        ConsoleHelper.RenderAppHeader();

        while (true)
        {
         ConsoleHelper.RenderMenuOptions();
         
          if(int.TryParse(Console.ReadLine(), out var result))
          {
              try
              {
                  switch (result)
                  {
                      case 1:
                          var flightsConsole = _getFlightList.Invoke();
                          _resolver.Resolve(OutputType.Console).OutputFlights(flightsConsole);
                          ConsoleHelper.RenderSuccessMessage();
                          break;
                      case 2:
                          var flightsFile = _getFlightList.Invoke();
                          _resolver.Resolve(OutputType.FileSystem).OutputFlights(flightsFile);
                          ConsoleHelper.RenderSuccessMessage();
                          break;
                      case 3:
                          var ordersConsole = _getOrderList.Invoke();
                          _resolver.Resolve(OutputType.Console).OutputOrders(ordersConsole);
                          ConsoleHelper.RenderSuccessMessage();
                          break;
                      case 4:
                          var ordersFile = _getOrderList.Invoke();
                          _resolver.Resolve(OutputType.FileSystem).OutputOrders(ordersFile);
                          ConsoleHelper.RenderSuccessMessage();
                          break;
                      case 0:
                          return;
                      default:
                          Console.WriteLine("The input is not a valid option. Please try again");
                          break;
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine("Something went wrong, please try again " + ex.Message);
              }
          }
          else
          {
              Console.WriteLine("The input is not a valid option. Please try again");
          }
        }
        
    }
}