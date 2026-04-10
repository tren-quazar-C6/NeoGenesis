using NeoGenesis.Infrastructure.Data;
using NeoGenesis.Shared.Entities;

namespace NeoGenesis.Modules.Update;

public class UpdateService
{
    private readonly MySqlDbContext _db;

    public UpdateService(MySqlDbContext db) => _db = db;

    /// <summary>
    /// Obtiene un dinosaurio por su Id.
    /// </summary>
    public Dinosaur? GetDinosaurById(int id)
    {
        return _db.Dinosaurs.FirstOrDefault(d => d.Id == id);
    }

    /// <summary>
    /// Actualiza los datos del dinosaurio.
    /// </summary>
    public bool UpdateDinosaur(Dinosaur dinosaur)
    {
        try
        {
            _db.Dinosaurs.Update(dinosaur);
            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Actualiza la contraseña del dinosaurio.
    /// </summary>
    public bool UpdatePassword(Dinosaur dinosaur, string newPassword)
    {
        try
        {
            dinosaur.Password = newPassword;
            _db.Dinosaurs.Update(dinosaur);
            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
