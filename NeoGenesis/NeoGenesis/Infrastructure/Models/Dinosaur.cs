namespace NeoGenesis.Infrastructure.Models;

public class Dinosaur
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Type { get; set; }
    public string  Zone { get; set; }
    public string Address { get; set; } = String.Empty;
    public string TrackNumber { get; set; } = String.Empty;
    public string Password  { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    
}