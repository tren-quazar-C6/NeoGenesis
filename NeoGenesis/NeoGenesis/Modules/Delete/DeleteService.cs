using NeoGenesis.Infrastructure.Data;
using NeoGenesis.Shared.Entities;

namespace NeoGenesis.Modules.Delete;

public class DeleteService
{
    private readonly MySqlDbContext _db;

    public DeleteService(MySqlDbContext db) => _db = db;

    /// <summary>
    /// Obtiene un dinosaurio por su Id.
    /// </summary>
    public Dinosaur? GetDinosaurById(int id)
    {
        return _db.Dinosaurs.FirstOrDefault(d => d.Id == id);
    }

    /// <summary>
    /// Obtiene un dinosaurio por su código de registro (Email).
    /// </summary>
    public Dinosaur? GetDinosaurByEmail(string registerCode)
    {
        return _db.Dinosaurs.FirstOrDefault(d => d.Register_code == registerCode);
    }

    /// <summary>
    /// Elimina un dinosaurio de la base de datos.
    /// </summary>
    public bool DeleteDinosaur(Dinosaur dinosaur)
    {
        try
        {
            _db.Dinosaurs.Remove(dinosaur);
            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
