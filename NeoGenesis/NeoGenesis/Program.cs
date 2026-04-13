using Microsoft.EntityFrameworkCore;
using NeoGenesis.Infrastructure.Data;
using NeoGenesis.Modules.Create;
using NeoGenesis.Modules.Update;
using NeoGenesis.Modules.Delete;
using Microsoft.Extensions.Configuration;

// ── Configuration ───────────────────────────────────────────────
var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables()               // env vars override the file
    .Build();

var connectionString = config.GetConnectionString("MySql")
                       ?? throw new InvalidOperationException("Connection string 'MySql' not found.");

// ── Database connection ─────────────────────────────────────────
var optionsBuilder = new DbContextOptionsBuilder<MySqlDbContext>();
optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
using var db = new MySqlDbContext(optionsBuilder.Options);  // ← this was missing
db.Database.EnsureCreated();

// ── Services ────────────────────────────────────────────────────
Helpers helpers = new Helpers();
QueryMenu queryMenu = new QueryMenu(db, helpers);

// ── Menus ───────────────────────────────────────────────────────
string mainMenu =
    "╔══════════════════════════════════════╗" +
    "\n║        NEOGENESIS PARK — MENU        ║" +
    "\n╚══════════════════════════════════════╝" +
    "\n1. Register Dinosaur" +
    "\n2. Update Dinosaur" +
    "\n3. Delete Dinosaur" +
    "\n4. Consult Dinosaurs" +
    "\n5. Exit";

string LINQMenu =
    "--- CONSULT DINOSAURS ---" +
    "\n1. List all dinosaurs" +
    "\n2. Get dinosaur by Id" +
    "\n3. Get dinosaur by Register Code" +
    "\n4. Filter by Zone" +
    "\n5. Filter by Sector" +
    "\n6. Filter by Age" +
    "\n7. Filter by Type" +
    "\n8. Show Name + Register Code" +
    "\n9. Count total dinosaurs" +
    "\n10. Count by Zone" +
    "\n11. Count by Sector" +
    "\n12. Dinosaurs without TrackNumber" +
    "\n13. Dinosaurs without Address" +
    "\n14. Last registered dinosaurs" +
    "\n15. Order by Species" +
    "\n0. Back";

// ── Main loop ───────────────────────────────────────────────────
bool menuFlag = false;

while (!menuFlag)
{
    Console.Clear();
    Console.WriteLine(mainMenu);
    Console.Write("\nEnter option: ");
    string opt = Console.ReadLine()!;

    switch (opt)
    {
        case "1":
            Console.Clear();
            new CreateHandler(db).Handle();
            break;
        case "2":
            Console.Clear();
            new UpdateHandler(db).Handle();
            break;
        case "3":
            Console.Clear();
            new DeleteHandler(db).Handle();
            break;
        case "4":
            Console.Clear();
            Console.WriteLine(LINQMenu);
            Console.Write("Enter option: ");
            queryMenu.Handle(Console.ReadLine()!);
            break;
        case "5":
            Console.Clear();
            Console.WriteLine("Thanks for using the System");
            menuFlag = true;
            break;
        default:
            Console.WriteLine("Wrong option");
            break;
    }
}