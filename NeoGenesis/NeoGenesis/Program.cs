using Microsoft.EntityFrameworkCore;
using NeoGenesis.Entities;
using NeoGenesis.Infrastructure.Data;
using NeoGenesis.Modules.Create;

// ── Database connection ─────────────────────────────────────────
var connectionString =
    "Server=204.168.211.73;Database=prueba_dino;User=root;Password=gWTeX0zTHgGQ6G1;";

var optionsBuilder = new DbContextOptionsBuilder<MySqlDbContext>();
optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

using var db = new MySqlDbContext(optionsBuilder.Options);
db.Database.EnsureCreated();

// ── Services ────────────────────────────────────────────────────
Helpers helpers = new Helpers();
//QueryService queryService = new QueryService(db); // pass db so queries hit MySQL

// ── Query method ────────────────────────────────────────────────
void QueryMethod(string queryOpt)
{
    QueryService queryService = new QueryService();
    List<string> codes = queryService.GetCodes();
    List<string> zones = queryService.GetZones();
    List<string> sectors = queryService.GetSectors();
    
    List<Dinosaur> dinosaursAll = queryService.GetAllDinosaurs();
    int cont = 0;
    int zoneOpt = 0;
    int sectorOpt = 0;

    switch (queryOpt)
    {
        case "1":
            Console.Clear();
            helpers.ShowDinosaurs(dinosaursAll);
            helpers.Hold();
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("Id".PadRight(5) + "Username".PadRight(20) + "Species".PadRight(20));
            Console.WriteLine("---------------------------------------------------");

            foreach (var d in dinosaursAll)
            {
                Console.Write(d.Id.ToString().PadRight(5));
                Console.Write(d.Username.PadRight(20));
                Console.WriteLine(d.DinoSpecies.PadRight(20));
            }
            Console.WriteLine("---------------------------------------------------");

            Console.Write("Type the Dinosaur Id: ");
            int dinoId = int.Parse(Console.ReadLine());
            List<Dinosaur> dinosaurById = queryService.GetDinosaurById(dinoId);
            Console.Clear();
            helpers.ShowDinosaurs(dinosaurById);
            helpers.Hold();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("--- Registered Codes ---");
            cont = 1;
            foreach (var c in codes) { Console.WriteLine(cont + ". " + c); cont++; }
            Console.Write($"Choose a code (1 - {cont - 1}): ");
            int codeOpt = int.Parse(Console.ReadLine());
            List<Dinosaur> dinosaurByCode = queryService.GetDinosaurByCode(codes[codeOpt - 1]);
            Console.Clear();
            Console.WriteLine($"Dinosaur with Registration Code '{codes[codeOpt - 1]}':\n");
            helpers.ShowDinosaurs(dinosaurByCode);
            helpers.Hold();
            break;
        case "4":
            Console.Clear();
            Console.WriteLine("--- Registered Zones ---");
            cont = 1;
            foreach (var z in zones) { Console.WriteLine(cont + ". " + z); cont++; }
            Console.Write($"Choose a zone (1 - {cont - 1}): ");
            zoneOpt = int.Parse(Console.ReadLine());
            List<Dinosaur> dinosaursByZone = queryService.GetDinosaursByZone(zones[zoneOpt - 1]);
            Console.Clear();
            Console.WriteLine($"Dinosaurs in {zones[zoneOpt - 1]} zone:\n");
            helpers.ShowDinosaurs(dinosaursByZone);
            helpers.Hold();
            break;
        case "5":
            Console.Clear();
            Console.WriteLine("--- Registered Sectors ---");
            cont = 1;
            foreach (var s in sectors) { Console.WriteLine(cont + ". " + s); cont++; }
            Console.Write($"Choose a sector (1 - {cont - 1}): ");
            sectorOpt = int.Parse(Console.ReadLine());
            List<Dinosaur> dinosaursBySector = queryService.GetDinosaursBySector(sectors[sectorOpt - 1]);
            Console.Clear();
            Console.WriteLine($"Dinosaurs in {sectors[sectorOpt - 1]} sector:\n");
            helpers.ShowDinosaurs(dinosaursBySector);
            helpers.Hold();
            break;
        case "6":
            Console.Clear();
            Console.WriteLine("Filter dinosaurs bigger than the input age\n");
            Console.Write("Age: ");
            int? age = helpers.IntValidation(Console.ReadLine());
            helpers.InputErrorHandler(age);
            List<Dinosaur> dinosaursAge = queryService.GetDinosaursByAge(age);
            Console.Clear();
            Console.WriteLine($"Dinosaurs bigger than {age} years:\n");
            helpers.ShowDinosaurs(dinosaursAge);
            helpers.Hold();
            break;
        case "7":
            Console.Clear();
            Console.WriteLine("--- Dinosaurs Types ---\n1. Herbivore\n2. Carnivore");
            Console.Write("Choose a type (1 - 2): ");
            string typeOpt = Console.ReadLine();
            string dinoType;
            switch (typeOpt)
            {
                case "1": dinoType = "Herbivore"; break;
                case "2": dinoType = "Carnivore"; break;
                default:
                    helpers.InputErrorHandler(typeOpt);
                    Console.Clear();
                    return;
            }
            List<Dinosaur> dinosaursByType = queryService.GetDinosaursByType(dinoType);
            Console.Clear();
            Console.WriteLine($"Dinosaurs listed by type: {dinoType}\n");
            helpers.ShowDinosaurs(dinosaursByType);
            helpers.Hold();
            break;
        case "8":
            Console.Clear();
            List<string> dinosaursForReports = queryService.GetDinosaursForReports();
            helpers.ShowDinosaursforReports(dinosaursForReports);
            helpers.Hold();
            break;
        case "9": 
            Console.Clear();
            Console.WriteLine("--- Dinosaur Count ---\n");
            helpers.CountDinosaurs(dinosaursAll);
            helpers.Hold();

            break;
        case "10": 
            Console.Clear();
            Console.WriteLine("--- Registered Zones ---");
            cont = 1;
            foreach (var z in zones) { Console.WriteLine(cont + ". " + z); cont++; }
            Console.Write($"Choose a zone (1 - {cont - 1}): ");
            zoneOpt = int.Parse(Console.ReadLine());
            List<Dinosaur> dinosaursByZoneToCount = queryService.GetDinosaursByZone(zones[zoneOpt - 1]);
            Console.Clear();
            Console.WriteLine($"Dinosaurs in {zones[zoneOpt - 1]} zone:\n");
            helpers.CountDinosaurs(dinosaursByZoneToCount);
            helpers.Hold();
            break;
        case "11":
            Console.Clear();
            Console.WriteLine("--- Registered Sectors ---");
            cont = 1;
            foreach (var s in sectors) { Console.WriteLine(cont + ". " + s); cont++; }
            Console.Write($"Choose a sector (1 - {cont - 1}): ");
            sectorOpt = int.Parse(Console.ReadLine());
            List<Dinosaur> dinosaursBySectorToCount = queryService.GetDinosaursBySector(sectors[sectorOpt - 1]);
            Console.Clear();
            Console.WriteLine($"Dinosaurs in {sectors[sectorOpt - 1]} sector:\n");
            helpers.CountDinosaurs(dinosaursBySectorToCount);
            helpers.Hold();
            break;
        case "12":
            Console.Clear();
            Console.WriteLine("--- Dinosaurs Without Track Number ---\n");
            List<Dinosaur> dinosaursWoTN = queryService.GetDinosaursWoTracking();
            helpers.ShowDinosaurs(dinosaursWoTN);
            helpers.Hold();
            break;
        case "13": 
            Console.Clear();
            Console.WriteLine("--- Dinosaurs Without Address ---\n");
            List<Dinosaur> dinosaursWoAddress = queryService.GetDinosaursWoAddress();
            helpers.ShowDinosaurs(dinosaursWoAddress);
            helpers.Hold();
            break;
        case "14": 
            Console.Clear();
            List<Dinosaur> orderedDinosaurs = queryService.OrderByCreationDate();
            helpers.ShowDinosaurs(orderedDinosaurs);
            helpers.Hold();
            break;
        case "15": break;
        case "0":  break;
    }
}

// ── Menus ───────────────────────────────────────────────────────
string mainMenu = "╔══════════════════════════════════════╗" +
                "\n║        NEOGENESIS PARK — MENU        ║" +
                "\n╚══════════════════════════════════════╝" +
                  "\n1. Register Dinosaur" +
                  "\n2. Update Dinosaur" +
                  "\n3. Delete Dinosaur" +
                  "\n4. Consult Dinosaurs" +
                  "\n5. Exit";

string LINQMenu = "--- CONSULT DINOSAURS ---" +
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
    string opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            Console.Clear();
            var handler = new CreateHandler(db); 
            handler.Handle();
            break;
        case "2":
            Console.Clear();
            break;
        case "3":
            Console.Clear();
            break;
        case "4":
            Console.Clear();
            Console.WriteLine(LINQMenu);
            Console.Write("Enter option: ");
            string queryOpt = Console.ReadLine();
            QueryMethod(queryOpt);
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