using NeoGenesis.Infrastructure.Data;

namespace NeoGenesis.Modules.Update;

public class UpdateValidator
{
    private readonly MySqlDbContext _db;

    public UpdateValidator(MySqlDbContext db) => _db = db;

    /// <summary>
    /// Valida que la edad sea válida.
    /// </summary>
    public string? ValidateAge(int? age)
    {
        if (age.HasValue && age.Value < 0)
            return "La edad debe ser mayor o igual a 0.";
        
        return null;
    }

    /// <summary>
    /// Valida que el identificador (sobre_nombre) sea único y no esté en uso por otro dinosaurio.
    /// </summary>
    public string? ValidateUniqueUsername(string sobre_nombre, int dinosaurId)
    {
        bool exists = _db.Dinosaurs.Any(d => d.Sobre_nombre == sobre_nombre && d.Id != dinosaurId);
        if (exists)
            return $"El identificador '{sobre_nombre}' ya está registrado por otro dinosaurio.";
        
        return null;
    }

    /// <summary>
    /// Valida que el código de registro (email) sea único y no esté en uso por otro dinosaurio.
    /// </summary>
    public string? ValidateUniqueEmail(string register_code, int dinosaurId)
    {
        bool exists = _db.Dinosaurs.Any(d => d.Register_code == register_code && d.Id != dinosaurId);
        if (exists)
            return $"El código de registro '{register_code}' ya está registrado por otro dinosaurio.";
        
        return null;
    }
}
