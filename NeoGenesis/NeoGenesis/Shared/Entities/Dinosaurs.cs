using System;

namespace NeoGenesis.Entities;
public class Dinosaur
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Type { get; set; }
    public string Zone { get; set; }
    public string Sector { get; set; }
    public string Address { get; set; }
    public string TrackNumber { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}