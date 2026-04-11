using NeoGenesis.Infrastructure.Data;
using NeoGenesis;
using NeoGenesis.Entities;

namespace NeoGenesis.Modules.Update;

public class UpdateHandler
{
    private readonly UpdateValidator _validator;
    private readonly UpdateService   _service;

    public UpdateHandler(MySqlDbContext db)
    {
        _validator = new UpdateValidator(db);
        _service   = new UpdateService(db);
    }

    /// <summary>
    /// Orquesta el proceso de actualización de un dinosaurio.
    /// </summary>
    public void Handle()
    {
        Console.Clear();
        Console.WriteLine("╔═════════════════════════════════════╗");
        Console.WriteLine("║    ACTUALIZAR DATOS DINOSAURIO      ║");
        Console.WriteLine("╚═════════════════════════════════════╝\n");

        // Obtener ID del dinosaurio a actualizar
        Console.Write("Ingrese el ID del dinosaurio a actualizar: ");
        if (!int.TryParse(Console.ReadLine()?.Trim(), out int dinosaurId))
        {
            Helpers.PrintError("ID inválido.");
            Console.WriteLine("Presione cualquier tecla para volver...");
            Console.ReadKey();
            return;
        }

        // Buscar dinosaurio
        var dinosaur = _service.GetDinosaurById(dinosaurId);
        if (dinosaur is null)
        {
            Helpers.PrintError($"No existe dinosaurio con ID {dinosaurId}.");
            Console.WriteLine("Presione cualquier tecla para volver...");
            Console.ReadKey();
            return;
        }

        // Mostrar datos actuales
        Console.Clear();
        Console.WriteLine("╔═════════════════════════════════════╗");
        Console.WriteLine("║    DATOS ACTUALES DEL DINOSAURIO    ║");
        Console.WriteLine("╚═════════════════════════════════════╝\n");

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
        Console.WriteLine($"  Contraseña: {(string.IsNullOrEmpty(dinosaur.Password) ? "No establecida" : "Establecida")}\n");

        // Menú de actualización
        bool updating = true;
        while (updating)
        {
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║     ¿QUÉ DESEA ACTUALIZAR?        ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.WriteLine("  1. Nombre");
            Console.WriteLine("  2. Especie");
            Console.WriteLine("  3. Identificador (Username)");
            Console.WriteLine("  4. Código de Registro (Email)");
            Console.WriteLine("  5. Edad");
            Console.WriteLine("  6. Tipo (Carnívoro/Herbívoro)");
            Console.WriteLine("  7. Zona");
            Console.WriteLine("  8. Sector");
            Console.WriteLine("  9. Teléfono");
            Console.WriteLine("  10. Dirección");
            Console.WriteLine("  11. Actualizar Contraseña (con confirmación)");
            Console.WriteLine("  0. Guardar y volver\n");
            Console.Write("Opción: ");

            string option = Console.ReadLine()?.Trim() ?? "";

            switch (option)
            {
                case "1":
                    UpdateField(dinosaur, "Nombre", nameof(dinosaur.DinoName));
                    break;
                case "2":
                    UpdateField(dinosaur, "Especie", nameof(dinosaur.DinoSpecies));
                    break;
                case "3":
                    UpdateUniqueField(dinosaur, "Identificador (Username)", 
                        nameof(dinosaur.Username), isUsername: true);
                    break;
                case "4":
                    UpdateUniqueField(dinosaur, "Código de Registro (Email)", 
                        nameof(dinosaur.RegisterCode), isUsername: false);
                    break;
                case "5":
                    UpdateAge(dinosaur);
                    break;
                case "6":
                    UpdateField(dinosaur, "Tipo", nameof(dinosaur.Type), optional: true);
                    break;
                case "7":
                    UpdateField(dinosaur, "Zona", nameof(dinosaur.Zone), optional: true);
                    break;
                case "8":
                    UpdateField(dinosaur, "Sector", nameof(dinosaur.Sector), optional: true);
                    break;
                case "9":
                    UpdateField(dinosaur, "Teléfono", nameof(dinosaur.TrackNumber), optional: true);
                    break;
                case "10":
                    UpdateField(dinosaur, "Dirección", nameof(dinosaur.Address), optional: true);
                    break;
                case "11":
                    UpdatePassword(dinosaur);
                    break;
                case "0":
                    updating = false;
                    break;
                default:
                    Helpers.PrintError("Opción no válida.");
                    Console.ReadKey();
                    break;
            }

            if (updating)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║    DATOS ACTUALES ACTUALIZADOS     ║");
                Console.WriteLine("╚════════════════════════════════════╝\n");
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
                Console.WriteLine($"  Dirección: {dinosaur.Address ?? "No registrada"}\n");
            }
        }

        // Guardar cambios en BD
        if (_service.UpdateDinosaur(dinosaur))
        {
            Helpers.PrintSuccess("Dinosaurio actualizado correctamente.");
        }
        else
        {
            Helpers.PrintError("Error al actualizar el dinosaurio.");
        }

        Console.WriteLine("Presione cualquier tecla para volver...");
        Console.ReadKey();
    }

    /// <summary>
    /// Actualiza un campo regular del dinosaurio.
    /// </summary>
    private void UpdateField(Dinosaur dinosaur, string fieldName, string propertyName, bool optional = false)
    {
        string currentValue = propertyName switch
        {
            nameof(dinosaur.DinoName) => dinosaur.DinoName,
            nameof(dinosaur.DinoSpecies) => dinosaur.DinoSpecies,
            nameof(dinosaur.Type) => dinosaur.Type ?? "[vacío]",
            nameof(dinosaur.Zone) => dinosaur.Zone ?? "[vacío]",
            nameof(dinosaur.Sector) => dinosaur.Sector ?? "[vacío]",
            nameof(dinosaur.TrackNumber) => dinosaur.TrackNumber ?? "[vacío]",
            nameof(dinosaur.Address) => dinosaur.Address ?? "[vacío]",
            _ => "[desconocido]"
        };

        Console.WriteLine($"\nValor actual de {fieldName}: {currentValue}");
        Console.Write($"Nuevo valor de {fieldName}{(optional ? " (Enter para omitir)" : "")}: ");
        string newValue = Console.ReadLine()?.Trim() ?? string.Empty;

        if (optional && string.IsNullOrWhiteSpace(newValue))
        {
            Helpers.PrintInfo($"{fieldName} se mantiene sin cambios.");
            return;
        }

        if (!optional && string.IsNullOrWhiteSpace(newValue))
        {
            Helpers.PrintError($"El {fieldName} no puede estar vacío.");
            return;
        }

        // Actualizar propiedad mediante reflexión
        var property = dinosaur.GetType().GetProperty(propertyName);
        if (property != null)
        {
            property.SetValue(dinosaur, newValue);
            Helpers.PrintSuccess($"{fieldName} actualizado correctamente.");
        }
    }

    /// <summary>
    /// Actualiza un campo que debe ser único (Username o Email).
    /// </summary>
    private void UpdateUniqueField(Dinosaur dinosaur, string fieldName, string propertyName, bool isUsername)
    {
        string currentValue = propertyName switch
        {
            nameof(dinosaur.Username) => dinosaur.Username,
            nameof(dinosaur.RegisterCode) => dinosaur.RegisterCode,
            _ => "[desconocido]"
        };

        Console.WriteLine($"\nValor actual de {fieldName}: {currentValue}");
        Console.Write($"Nuevo valor de {fieldName}: ");
        string newValue = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(newValue))
        {
            Helpers.PrintError($"El {fieldName} no puede estar vacío.");
            return;
        }

        // Validar unicidad
        string? error = isUsername 
            ? _validator.ValidateUniqueUsername(newValue, dinosaur.Id)
            : _validator.ValidateUniqueEmail(newValue, dinosaur.Id);

        if (error != null)
        {
            Helpers.PrintError(error);
            return;
        }

        // Actualizar propiedad
        var property = dinosaur.GetType().GetProperty(propertyName);
        if (property != null)
        {
            property.SetValue(dinosaur, newValue);
            Helpers.PrintSuccess($"{fieldName} actualizado correctamente.");
        }
    }

    /// <summary>
    /// Actualiza la edad con validación.
    /// </summary>
    private void UpdateAge(Dinosaur dinosaur)
    {
        Console.WriteLine($"\nEdad actual: {dinosaur.Age ?? 0}");
        Console.Write("Nueva edad (ingrese un número, Enter para omitir): ");
        string ageInput = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(ageInput))
        {
            Helpers.PrintInfo("Edad se mantiene sin cambios.");
            return;
        }

        if (!int.TryParse(ageInput, out int newAge))
        {
            Helpers.PrintError("Edad inválida. Debe ser un número.");
            return;
        }

        string? error = _validator.ValidateAge(newAge);
        if (error != null)
        {
            Helpers.PrintError(error);
            return;
        }

        dinosaur.Age = newAge;
        Helpers.PrintSuccess("Edad actualizada correctamente.");
    }

    /// <summary>
    /// Actualiza la contraseña del dinosaurio con confirmación.
    /// </summary>
    private void UpdatePassword(Dinosaur dinosaur)
    {
        Console.WriteLine("\n╔════════════════════════════════════╗");
        Console.WriteLine("║   ACTUALIZACIÓN DE CONTRASEÑA      ║");
        Console.WriteLine("╚════════════════════════════════════╝\n");

        Console.Write("Ingrese la nueva contraseña: ");
        string newPassword = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(newPassword))
        {
            Helpers.PrintError("La contraseña no puede estar vacía.");
            return;
        }

        Console.Write("Confirme la contraseña: ");
        string confirmPassword = Console.ReadLine()?.Trim() ?? string.Empty;

        if (newPassword != confirmPassword)
        {
            Helpers.PrintError("Las contraseñas no coinciden.");
            return;
        }

        if (_service.UpdatePassword(dinosaur, newPassword))
        {
            Helpers.PrintSuccess("Contraseña actualizada correctamente.");
            dinosaur.Password = newPassword;
        }
        else
        {
            Helpers.PrintError("Error al actualizar la contraseña.");
        }
    }
}
