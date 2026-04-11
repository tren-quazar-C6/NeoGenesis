using Microsoft.EntityFrameworkCore;
using NeoGenesis.Entities;
using NeoGenesis.Infrastructure.Data;

public class QueryService
{
    private readonly MySqlDbContext _db;

    public QueryService(MySqlDbContext db)
    {
        _db = db;
    }

    private List<Dinosaur> All() => _db.Dinosaurs.ToList();

    public List<Dinosaur> GetAllDinosaurs() => All();

    public List<Dinosaur> GetDinosaurById(int id) =>
        All().Where(d => d.Id == id).ToList();

    public List<Dinosaur> GetDinosaurByCode(string code) =>
        All().Where(d => d.RegisterCode == code).ToList();

    public List<string> GetCodes() =>
        All().Select(d => d.RegisterCode).ToList();

    public List<Dinosaur> GetDinosaursByZone(string zone) =>
        All().Where(d => d.Zone == zone).ToList();

    public List<string> GetZones() =>
        All().Select(d => d.Zone).Distinct().Where(z => z != null).ToList()!;

    public List<Dinosaur> GetDinosaursBySector(string sector) =>
        All().Where(d => d.Sector == sector).ToList();

    public List<string> GetSectors() =>
        All().Select(d => d.Sector).Distinct().Where(s => s != null).ToList()!;

    public List<Dinosaur> GetDinosaursByAge(int? age) =>
        All().Where(d => d.Age > age).ToList();

    public List<Dinosaur> GetDinosaursByType(string type) =>
        All().Where(d => d.Type == type).ToList();

    public List<string> GetDinosaursForReports() =>
        All().Select(d => $"{d.DinoName.PadRight(20)}{d.RegisterCode.PadRight(15)}").ToList();

    public List<Dinosaur> OrderByCreationDate() =>
        All().OrderBy(d => d.CreatedAt).ToList();

    public List<Dinosaur> GetDinosaursWoTracking() =>
        All().Where(d => d.TrackNumber == null).ToList();

    public List<Dinosaur> GetDinosaursWoAddress() =>
        All().Where(d => d.Address == null).ToList();

    public List<Dinosaur> DinosaursBySpecies() =>
        All().OrderBy(d => d.DinoSpecies).ToList();
}