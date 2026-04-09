using NeoGenesis.Entities;
    

public class Helpers
{
    public void Hold()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public int? IntValidation(string value)
    {
        int numericValue;
        if (int.TryParse(value, out numericValue))
        {
            return numericValue;
        }
        else
        {
            return null;
        }
    }

    public void InputErrorHandler(dynamic value)
    {
        if (value == null)
        {
            Console.WriteLine("Invalid input");
        }
    }

    public void ShowDinosaurs(List<Dinosaur> dinosaurs)
    {
        Console.WriteLine("Id".PadRight(5) + "Username".PadRight(15) + "Species".PadRight(20) + "Age".PadRight(6) + "Type".PadRight(12) +
                          "Zone".PadRight(10) + "Sector".PadRight(10) + "Tracknumber".PadRight(15) + "Address".PadRight(12) +
                          "CreatedAt".PadRight(10));
        Console.WriteLine(
            "----------------------------------------------------------------------------------------------------------------------------------");

        foreach (var d in dinosaurs)
        {
            Console.WriteLine(
                $"{d.Id.ToString(), -5}" +
                $"{d.Username, -15}" +
                $"{d.DinoSpecies, -20}" +
                $"{d.Age.ToString() ?? "N/A", -6}" +
                $"{d.Type ?? "N/A", -12}" +
                $"{d.Zone ?? "N/A", -10}" +
                $"{d.Sector ?? "N/A", -10}" +
                $"{d.TrackNumber ?? "N/A", -15}" +
                $"{d.Address ?? "N/A", -12}" +
                $"{d.CreatedAt.ToString(), -10}" 
                );
        }

        Console.WriteLine(
            "----------------------------------------------------------------------------------------------------------------------------------");
    }

    public void ShowDinosaursforReports(List<string> dinosaurs)
    {

        Console.WriteLine("Name".PadRight(20) + "Code".PadRight(15));
        Console.WriteLine("----------------------------------------");

        foreach (var d in dinosaurs)
        {
            Console.WriteLine(d);

        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Total: {dinosaurs.Count}");
    }

    public void CountDinosaurs(List<Dinosaur> dinosaurs)
    {
        Console.WriteLine($"Total: {dinosaurs.Count}");
    }
    public static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✔ {message}");
        Console.ResetColor();
    }

    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n✖ {message}");
        Console.ResetColor();
    }

    public static void PrintInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  {message}");
        Console.ResetColor();
    }
}