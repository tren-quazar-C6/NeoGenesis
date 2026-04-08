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
}