using System;

namespace NeoGenesis.Entities;
public class Dinosaur
{
    public int Id { get; set; }
    public string DinoName { get; set; } = string.Empty;  
    public string DinoSpecies  { get; set; } = string.Empty;  
    public string Username  { get; set; } = string.Empty;   
    public string RegisterCode { get; set; } = string.Empty;   
    public int? Age { get; set; }
    public string? Type { get; set; }
    public string? Zone { get; set; }
    public string? Sector { get; set; }
    public string? Address { get; set; }
    public string? TrackNumber { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}