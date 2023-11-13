namespace PlaneScheduleApp.Helpers;

public static class ConsoleHelper
{
    public static void RenderAppHeader()
    {
        Console.WriteLine("Welcome to plane schedule console app");
    }

    public static void RenderMenuOptions()
    {
        Console.WriteLine("Please choose a menu option, write number and press 'Enter'");
        Console.WriteLine("1 - Show flight schedule ");
        Console.WriteLine("2 - Save flight schedule into file with default location");
        Console.WriteLine("3 - Show orders");
        Console.WriteLine("4 - Save orders into file with default location");
        Console.WriteLine("0 - Exit program");
    }

    public static void RenderSuccessMessage()
    {
        Console.WriteLine("Action completed.");
    }
}