using System;
using System.Collections.Generic;
using System.Linq;
using NeoGenesis.Entities;

public class QueryService
{
    private List<Dinosaur> dinosaurs = new List<Dinosaur>
    {
        new Dinosaur
        {
            Id = 1,
            Username = "trex01",
            Name = "Rex",
            Email = "trex01@neogenesis.com",
            Species = "Tyrannosaurus",
            Age = 12,
            Type = "Carnivore",
            Zone = "North",
            Sector = "A",
            Address = "Zone A1",
            TrackNumber = "TRK-001",
            Password = "hash1",
            CreatedAt = DateTime.Now.AddDays(-10),
            UpdatedAt = DateTime.Now.AddDays(-8)
        },
        new Dinosaur
        {
            Id = 2,
            Username = "raptor02",
            Name = "Blue",
            Email = "raptor02@neogenesis.com",
            Species = "Velociraptor",
            Age = 8,
            Type = "Carnivore",
            Zone = "East",
            Sector = "B",
            Address = "Zone B2",
            TrackNumber = "TRK-002",
            Password = "hash2",
            CreatedAt = DateTime.Now.AddDays(-5),
            UpdatedAt = DateTime.Now.AddDays(-2)
        },
        new Dinosaur
        {
            Id = 3,
            Username = "trice03",
            Name = "Tri",
            Email = "trice03@neogenesis.com",
            Species = "Triceratops",
            Age = 15,
            Type = "Herbivore",
            Zone = "North",
            Sector = "A",
            Address = "Zone B1",
            TrackNumber = "TRK-003",
            Password = "hash3",
            CreatedAt = DateTime.Now.AddDays(-20),
            UpdatedAt = DateTime.Now.AddDays(-10)
        },
        new Dinosaur
        {
            Id = 4,
            Username = "brachio04",
            Name = "Longneck",
            Email = "brachio04@neogenesis.com",
            Species = "Brachiosaurus",
            Age = 25,
            Type = "Herbivore",
            Zone = "West",
            Sector = "C",
            Address = "Zone C3",
            TrackNumber = "TRK-004",
            Password = "hash4",
            CreatedAt = DateTime.Now.AddDays(-2),
            UpdatedAt = DateTime.Now.AddDays(-1)
        },
        new Dinosaur
        {
            Id = 5,
            Username = "spino05",
            Name = "Spike",
            Email = "spino05@neogenesis.com",
            Species = "Spinosaurus",
            Age = 18,
            Type = "Carnivore",
            Zone = "South",
            Sector = "D",
            Address = "Zone B2",
            TrackNumber = "TRK-005",
            Password = "hash5",
            CreatedAt = DateTime.Now.AddDays(-1),
            UpdatedAt = DateTime.Now
        }
    };
    
    private Query _query = new Query();

    public List<Dinosaur> GetAllDinosaurs()
    {
        return _query.GetAllDinosaurs(dinosaurs);
    }
    
    public List<Dinosaur> GetDinosaursByZone(string zone)
    {
        return _query.GetDinosaursByZone(dinosaurs, zone);
    }
    
    public List<string> GetZones()
    {
        return _query.GetZones(dinosaurs);
    }
}

