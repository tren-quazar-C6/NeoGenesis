using NeoGenesis.Entities;
using NeoGenesis.Infrastructure.Data;

public class QueryMenu
{
    private readonly QueryService _queryService;
    private readonly Helpers _helpers;

    public QueryMenu(MySqlDbContext db, Helpers helpers)
    {
        _queryService = new QueryService(db);
        _helpers = helpers;
    }

    public void Handle(string queryOpt)
    {
        List<string> codes = _queryService.GetCodes();
        List<string> zones = _queryService.GetZones();
        List<string> sectors = _queryService.GetSectors();
        List<Dinosaur> dinosaursAll = _queryService.GetAllDinosaurs();
        int cont;
        int zoneOpt;
        int sectorOpt;

        switch (queryOpt)
        {
            case "1":
                Console.Clear();
                _helpers.ShowDinosaurs(dinosaursAll);
                _helpers.Hold();
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
                int dinoId = int.Parse(Console.ReadLine()!);
                Console.Clear();
                _helpers.ShowDinosaurs(_queryService.GetDinosaurById(dinoId));
                _helpers.Hold();
                break;

            case "3":
                Console.Clear();
                Console.WriteLine("--- Registered Codes ---");
                cont = 1;
                foreach (var c in codes) { Console.WriteLine(cont + ". " + c); cont++; }
                Console.Write($"Choose a code (1 - {cont - 1}): ");
                int codeOpt = int.Parse(Console.ReadLine()!);
                Console.Clear();
                Console.WriteLine($"Dinosaur with Registration Code '{codes[codeOpt - 1]}':\n");
                _helpers.ShowDinosaurs(_queryService.GetDinosaurByCode(codes[codeOpt - 1]));
                _helpers.Hold();
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("--- Registered Zones ---");
                cont = 1;
                foreach (var z in zones) { Console.WriteLine(cont + ". " + z); cont++; }
                Console.Write($"Choose a zone (1 - {cont - 1}): ");
                zoneOpt = int.Parse(Console.ReadLine()!);
                Console.Clear();
                Console.WriteLine($"Dinosaurs in {zones[zoneOpt - 1]} zone:\n");
                _helpers.ShowDinosaurs(_queryService.GetDinosaursByZone(zones[zoneOpt - 1]));
                _helpers.Hold();
                break;

            case "5":
                Console.Clear();
                Console.WriteLine("--- Registered Sectors ---");
                cont = 1;
                foreach (var s in sectors) { Console.WriteLine(cont + ". " + s); cont++; }
                Console.Write($"Choose a sector (1 - {cont - 1}): ");
                sectorOpt = int.Parse(Console.ReadLine()!);
                Console.Clear();
                Console.WriteLine($"Dinosaurs in {sectors[sectorOpt - 1]} sector:\n");
                _helpers.ShowDinosaurs(_queryService.GetDinosaursBySector(sectors[sectorOpt - 1]));
                _helpers.Hold();
                break;

            case "6":
                Console.Clear();
                Console.WriteLine("Filter dinosaurs bigger than the input age\n");
                Console.Write("Age: ");
                int? age = _helpers.IntValidation(Console.ReadLine()!);
                _helpers.InputErrorHandler(age);
                Console.Clear();
                Console.WriteLine($"Dinosaurs bigger than {age} years:\n");
                _helpers.ShowDinosaurs(_queryService.GetDinosaursByAge(age));
                _helpers.Hold();
                break;

            case "7":
                Console.Clear();
                Console.WriteLine("--- Dinosaurs Types ---\n1. Herbivore\n2. Carnivore");
                Console.Write("Choose a type (1 - 2): ");
                string typeOpt = Console.ReadLine()!;
                string dinoType = typeOpt switch
                {
                    "1" => "Herbivore",
                    "2" => "Carnivore",
                    _ => string.Empty
                };
                if (string.IsNullOrEmpty(dinoType)) { _helpers.InputErrorHandler(typeOpt); return; }
                Console.Clear();
                Console.WriteLine($"Dinosaurs listed by type: {dinoType}\n");
                _helpers.ShowDinosaurs(_queryService.GetDinosaursByType(dinoType));
                _helpers.Hold();
                break;

            case "8":
                Console.Clear();
                _helpers.ShowDinosaursforReports(_queryService.GetDinosaursForReports());
                _helpers.Hold();
                break;

            case "9":
                Console.Clear();
                Console.WriteLine("--- Dinosaur Count ---\n");
                _helpers.CountDinosaurs(dinosaursAll);
                _helpers.Hold();
                break;

            case "10":
                Console.Clear();
                Console.WriteLine("--- Registered Zones ---");
                cont = 1;
                foreach (var z in zones) { Console.WriteLine(cont + ". " + z); cont++; }
                Console.Write($"Choose a zone (1 - {cont - 1}): ");
                zoneOpt = int.Parse(Console.ReadLine()!);
                Console.Clear();
                Console.WriteLine($"Dinosaurs in {zones[zoneOpt - 1]} zone:\n");
                _helpers.CountDinosaurs(_queryService.GetDinosaursByZone(zones[zoneOpt - 1]));
                _helpers.Hold();
                break;

            case "11":
                Console.Clear();
                Console.WriteLine("--- Registered Sectors ---");
                cont = 1;
                foreach (var s in sectors) { Console.WriteLine(cont + ". " + s); cont++; }
                Console.Write($"Choose a sector (1 - {cont - 1}): ");
                sectorOpt = int.Parse(Console.ReadLine()!);
                Console.Clear();
                Console.WriteLine($"Dinosaurs in {sectors[sectorOpt - 1]} sector:\n");
                _helpers.CountDinosaurs(_queryService.GetDinosaursBySector(sectors[sectorOpt - 1]));
                _helpers.Hold();
                break;

            case "12":
                Console.Clear();
                Console.WriteLine("--- Dinosaurs Without Track Number ---\n");
                _helpers.ShowDinosaurs(_queryService.GetDinosaursWoTracking());
                _helpers.Hold();
                break;

            case "13":
                Console.Clear();
                Console.WriteLine("--- Dinosaurs Without Address ---\n");
                _helpers.ShowDinosaurs(_queryService.GetDinosaursWoAddress());
                _helpers.Hold();
                break;

            case "14":
                Console.Clear();
                _helpers.ShowDinosaurs(_queryService.OrderByCreationDate());
                _helpers.Hold();
                break;

            case "15":
                Console.Clear();
                Console.WriteLine("--- Dinosaurs Ordered by Species ---\n");
                _helpers.ShowDinosaurs(_queryService.DinosaursBySpecies());
                _helpers.Hold();
                break;

            case "0":
                break;
        }
    }
}