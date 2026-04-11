using NeoGenesis.Infrastructure.Data;
using NeoGenesis.Entities;

namespace NeoGenesis.Modules.Delete;

public class DeleteHandler
{
    private readonly DeleteService _service;

    public DeleteHandler(MySqlDbContext db)
    {
        _service = new DeleteService(db);
    }

    /// <summary>
    /// Orquesta el proceso de eliminación de un dinosaurio.
    /// </summary>
    public void Handle()
    {
        Console.Clear();
        Console.WriteLine("╔═════════════════════════════════════╗");
        Console.WriteLine("║       ELIMINAR DINOSAURIO           ║");
        Console.WriteLine("╚═════════════════════════════════════╝\n");

        Console.WriteLine("¿Cómo desea buscar el dinosaurio?");
        Console.WriteLine("  1. Por ID");
        Console.WriteLine("  2. Por Código de Registro (Email)");
        Console.WriteLine("  0. Volver\n");
        Console.Write("Opción: ");

        string option = Console.ReadLine()?.Trim() ?? "";

        Dinosaur? dinosaur = null;

        switch (option)
        {
            case "1":
                dinosaur = DeleteById();
                break;
            case "2":
                dinosaur = DeleteByEmail();
                break;
            case "0":
                return;
            default:
                Helpers.PrintError("Opción no válida.");
                Console.ReadKey();
                return;
        }

        if (dinosaur == null)
        {
            Console.WriteLine("Presione cualquier tecla para volver...");
            Console.ReadKey();
            return;
        }

        // Mostrar confirmación con datos del dinosaurio
        ConfirmAndDelete(dinosaur);
    }

    /// <summary>
    /// Busca y retorna un dinosaurio por ID.
    /// </summary>
    private Dinosaur? DeleteById()
    {
        Console.Write("\nIngrese el ID del dinosaurio a eliminar: ");
        if (!int.TryParse(Console.ReadLine()?.Trim(), out int dinosaurId))
        {
            Helpers.PrintError("ID inválido.");
            return null;
        }

        var dinosaur = _service.GetDinosaurById(dinosaurId);
        if (dinosaur == null)
        {
            Helpers.PrintError($"No existe dinosaurio con ID {dinosaurId}.");
            return null;
        }

        return dinosaur;
    }

    /// <summary>
    /// Busca y retorna un dinosaurio por código de registro (Email).
    /// </summary>
    private Dinosaur? DeleteByEmail()
    {
        Console.Write("\nIngrese el Código de Registro (Email) del dinosaurio a eliminar: ");
        string registerCode = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(registerCode))
        {
            Helpers.PrintError("Código de Registro inválido.");
            return null;
        }

        var dinosaur = _service.GetDinosaurByEmail(registerCode);
        if (dinosaur == null)
        {
            Helpers.PrintError($"No existe dinosaurio con código de registro '{registerCode}'.");
            return null;
        }

        return dinosaur;
    }

    /// <summary>
    /// Muestra los datos del dinosaurio y solicita confirmación antes de eliminar.
    /// </summary>
    private void ConfirmAndDelete(Dinosaur dinosaur)
    {
        Console.Clear();
        Console.WriteLine("╔═════════════════════════════════════════════╗");
        Console.WriteLine("║   CONFIRMAR ELIMINACIÓN DE DINOSAURIO       ║");
        Console.WriteLine("╚═════════════════════════════════════════════╝\n");

        Console.WriteLine("DATOS DEL DINOSAURIO A ELIMINAR:\n");
        Console.WriteLine($"  ID: {dinosaur.Id}");
        Console.WriteLine($"  Nombre: {dinosaur.DinoName}");
        Console.WriteLine($"  Especie: {dinosaur.DinoSpecies}");
        Console.WriteLine($"  Identificador (Username): {dinosaur.Username}");
        Console.WriteLine($"  Código de Registro (Email): {dinosaur.RegisterCode}");
        Console.WriteLine($"  Edad: {dinosaur.Age ?? 0}");
        Console.WriteLine($"  Tipo: {dinosaur.Type ?? "No especificado"}");
        Console.WriteLine($"  Zona: {dinosaur.Zone ?? "No especificada"}");
        Console.WriteLine($"  Sector: {dinosaur.Sector ?? "No especificado"}");
        Console.WriteLine($"  Teléfono: {dinosaur.TrackNumber ?? "No registrado"}");
        Console.WriteLine($"  Dirección: {dinosaur.Address ?? "No registrada"}");
        Console.WriteLine($"  Creado: {dinosaur.CreatedAt:dd/MM/yyyy HH:mm:ss}\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("¿Está seguro de que desea eliminar este dinosaurio? (S/N): ");
        Console.ResetColor();

        string response = Console.ReadLine()?.Trim().ToUpper() ?? "";

        if (response == "S")
        {
            if (_service.DeleteDinosaur(dinosaur))
            {
                Helpers.PrintSuccess($"Dinosaurio '{dinosaur.DinoName}' ha sido eliminado correctamente del sistema.");
            }
            else
            {
                Helpers.PrintError("Error al eliminar el dinosaurio. Intente de nuevo.");
            }
        }
        else if (response == "N")
        {
            Helpers.PrintInfo("Eliminación cancelada. El dinosaurio se mantiene en el sistema.");
        }
        else
        {
            Helpers.PrintError("Respuesta inválida. Operación cancelada.");
        }

        Console.WriteLine("\nPresione cualquier tecla para volver...");
        Console.ReadKey();
    }
}
