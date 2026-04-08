using System.Text.RegularExpressions;
using NeoGenesis.Infrastructure.Data;

namespace NeoGenesis.Modules.Create;

public class CreateValidator
{
    private readonly MySqlDbContext _db;

    public CreateValidator(MySqlDbContext db) => _db = db;

    /// <summary>
    /// Valida todos los campos del registro. Retorna null si todo OK,
    /// o el mensaje de error si algo falla.
    /// </summary>
    public string? Validate(
        string dino_name, string dino_especie,
        string sobre_nombre,  string register_code,
        int?   age)
    {
        // 1. Campos obligatorios
        if (string.IsNullOrWhiteSpace(dino_name))
            return "El nombre es obligatorio.";

        if (string.IsNullOrWhiteSpace(dino_especie))
            return "La especie es obligatoria.";

        if (string.IsNullOrWhiteSpace(sobre_nombre))
            return "El identificador es obligatorio.";

        if (string.IsNullOrWhiteSpace(register_code))
            return "El código de registro es obligatorio.";


        // 3. Edad >= 0
        if (age.HasValue && age.Value < 0)
            return "La edad debe ser mayor o igual a 0.";

        // 4. Username único
        bool sobre_nombreExists = _db.Dinosaurs.Any(d => d.Sobre_nombre == sobre_nombre);
        if (sobre_nombreExists)
            return $"El identificador '{sobre_nombre}' ya está registrado en el sistema.";

        // 5. Email único
        bool register_codeExists = _db.Dinosaurs.Any(d => d.Register_code == register_code);
        if (register_codeExists)
            return $"El código de registro '{register_code}' ya existe en el sistema.";

        return null; // Sin errores
    }

}