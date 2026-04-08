using System.Collections.Generic;
using System.Linq;
using NeoGenesis.Entities;

public class Query
{
    public List<Dinosaur> GetAllDinosaurs(List<Dinosaur> dinosaurs)
    {
        return dinosaurs.ToList();
    }
    
    public List<Dinosaur> GetDinosaurById(List<Dinosaur> dinosaurs, int id)
    {
        return dinosaurs
            .Where(d => d.Id == id)
            .ToList();
    }
    
    public List<Dinosaur> GetDinosaursByZone(List<Dinosaur> dinosaurs, string zone)
    {
        return dinosaurs
            .Where(d => d.Zone == zone)
            .ToList();
    }
    
    public List<string> GetZones(List<Dinosaur> dinosaurs)
    {
        return dinosaurs.Select(x => x.Zone).Distinct().ToList();
    }
    
    public List<Dinosaur> GetDinosaursBySector(List<Dinosaur> dinosaurs, string sector)
    {
        return dinosaurs
            .Where(d => d.Sector == sector)
            .ToList();
    }
    
    public List<string> GetSectors(List<Dinosaur> dinosaurs)
    {
        return dinosaurs.Select(x => x.Sector).Distinct().ToList();
    }
    
    public List<Dinosaur> GetDinosaursByAge(List<Dinosaur> dinosaurs, int? age)
    {
        return dinosaurs
            .Where(d => d.Age > age)
            .ToList();
    }
    
    public List<Dinosaur> GetDinosaursByType(List<Dinosaur> dinosaurs, string type)
    {
        return dinosaurs
            .Where(d => d.Type == type)
            .ToList();
    }
    
}