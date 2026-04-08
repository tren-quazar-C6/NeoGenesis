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
        Console.WriteLine("Id".PadRight(5) + "Username".PadRight(20) + "Age".PadRight(8) + "Type".PadRight(12) + "Zone".PadRight(10) + "Sector".PadRight(10) + "Tracknumber".PadRight(20) + "CreatedAt".PadRight(10));
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

        foreach (var d in dinosaurs)
        {
            Console.Write(d.Id.ToString().PadRight(5));
            Console.Write(d.Username.PadRight(20));
            Console.Write(d.Age.ToString().PadRight(8));
            Console.Write(d.Type.PadRight(12));
            Console.Write(d.Zone.PadRight(10));
            Console.Write(d.Sector.PadRight(10));
            Console.Write(d.TrackNumber.PadRight(20));
            Console.WriteLine(d.CreatedAt.ToString().PadRight(10));
        }

        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
    }
    
    public void ShowDinosaursforReports(List<string> dinosaurs)
    {
        // var projected = dinosaurs
        //     .Select(d => new { d.Name, d.RegisterCode })
        //     .ToList();

        Console.WriteLine("Name".PadRight(20) + "Code".PadRight(15));
        Console.WriteLine("----------------------------------------");

        foreach (var d in dinosaurs)
        {
            Console.WriteLine(d);
            // Console.Write(d.Name.PadRight(25));
            // Console.WriteLine(d.RegisterCode.PadRight(15));
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Total: {dinosaurs.Count}");
    }
}