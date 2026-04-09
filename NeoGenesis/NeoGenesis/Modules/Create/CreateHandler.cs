using NeoGenesis.Entities;
using NeoGenesis.Infrastructure.Data;

namespace NeoGenesis.Modules.Create;

public class CreateHandler
{
    private readonly CreateValidator _validator;
    private readonly CreateService   _service;

    public CreateHandler(MySqlDbContext db)
    {
        _validator = new CreateValidator(db);
        _service   = new CreateService(db);
    }

    /// <summary>
    /// Orquesta el flujo completo de registro de un dinosaurio.
    /// </summary>
    public void Handle()
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine("           NEW DINO REGISTER         ");
        Console.WriteLine("====================================\n");

        // ── Campos obligatorios ──────────────────────────────────────
        Console.Write("Name : ");
        string dinoName = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Species : ");
        string dinoSpecies = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Username (unique) : ");
        string username = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Register Code (unique) : ");
        string registerCode = Console.ReadLine()?.Trim() ?? string.Empty;

        // ── Campos opcionales ────────────────────────────────────────
        Console.WriteLine("\n── Optional data (Press Enter to ommit) ──");

        Console.Write("Age : ");
        string ageInput = Console.ReadLine()?.Trim() ?? string.Empty;
        int? age = int.TryParse(ageInput, out int parsedAge) ? parsedAge : null;

        Console.Write("Type (Carnívore / Herbivore) : ");
        string? type = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(type)) type = null;

        Console.Write("Park Zone : ");
        string? zone = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(zone)) zone = null;

        Console.Write("Park Sector : ");
        string? sector = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(sector)) sector = null;

        Console.Write("Track Number : ");
        string? phone = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(phone)) phone = null;

        Console.Write("Location : ");
        string? address = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(address)) address = null;

        // ── Validación ───────────────────────────────────────────────
        string? error = _validator.Validate(dinoName, dinoSpecies, username, registerCode, age);

        if (error is not null)
        {
            Helpers.PrintError(error);
            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
            return;
        }

        // ── Construcción del objeto ──────────────────────────────────
        var dinosaur = new Dinosaur
        {
            DinoName = dinoName,
            DinoSpecies = dinoSpecies,
            Username = username,
            RegisterCode = registerCode,
            Age = age,
            Type = type,
            Zone      = zone,
            Sector    = sector,
            TrackNumber     = phone,
            Address   = address,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // ── Persistencia ─────────────────────────────────────────────
        int newId = _service.Register(dinosaur);

        Helpers.PrintSuccess($"Dino registered successfully. ID asignado: {newId}");
        Console.WriteLine("\nPress any key to go back...");
        Console.ReadKey();
    }
}