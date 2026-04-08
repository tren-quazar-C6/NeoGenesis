using System;
using System.Collections.Generic;
using NeoGenesis.Entities;

Helpers helpers = new Helpers();

void QueryMethod(string queryOpt)
{
    QueryService queryService = new QueryService();
    switch (queryOpt)
    {
        case "1":
            Console.Clear();
            List<Dinosaur> dinosaursAll = queryService.GetAllDinosaurs();
            helpers.ShowDinosaurs(dinosaursAll);
            helpers.Hold();
            break;
        case "2":
            Console.Clear();
            List<Dinosaur> dinosaurs = queryService.GetAllDinosaurs();
            Console.WriteLine("Id".PadRight(5) + "Username".PadRight(20) + "Species".PadRight(20));
            Console.WriteLine("---------------------------------------------------");
            
            foreach (var d in dinosaurs)
            {
                Console.Write(d.Id.ToString().PadRight(5));
                Console.Write(d.Username.PadRight(20));
                Console.WriteLine(d.Species.PadRight(20) );
            }
            Console.WriteLine("---------------------------------------------------");
            
            Console.Write("Type the Dinosaur Id:");
            int dinoId = int.Parse(Console.ReadLine());
            List<Dinosaur> dinosaurById = queryService.GetDinosaurById(dinoId);
            Console.Clear();
            
            helpers.ShowDinosaurs(dinosaurById);

            helpers.Hold();
            
            break;
        case "3":
            
            break;
        case "4":
            Console.Clear();
            List<string> zones = queryService.GetZones();
            Console.WriteLine("--- Registered Zones ---");
            int cont = 1;
            
            foreach (var z in zones)
            {
                Console.WriteLine(cont + ". " + z);
                cont++;
            }
            
            Console.Write($"Choose a zone (1 - {cont-1}):");
            int zoneOpt = int.Parse(Console.ReadLine());
            List<Dinosaur> dinosaursByZone = queryService.GetDinosaursByZone(zones[zoneOpt-1]);
            
            Console.Clear();
            Console.WriteLine($"Dinosaurs in {zones[zoneOpt-1]} zone:\n");
            
            helpers.ShowDinosaurs(dinosaursByZone);
            
            helpers.Hold();
            break;
        case "5":
            Console.Clear();
            List<string> sectors = queryService.GetSectors();
            Console.WriteLine("--- Registered Sectors ---");
            cont = 1;
            
            foreach (var s in sectors)
            {
                Console.WriteLine(cont + ". " + s);
                cont++;
            }
            
            Console.Write($"Choose a sector (1 - {cont-1}):");
            int sectorOpt = int.Parse(Console.ReadLine());
            List<Dinosaur> dinosaursBySector = queryService.GetDinosaursBySector(sectors[sectorOpt-1]);
            
            Console.Clear();
            Console.WriteLine($"Dinosaurs in {sectors[sectorOpt-1]} sector:\n");
            
            helpers.ShowDinosaurs(dinosaursBySector);

            helpers.Hold();
            break;
        case "6":
            Console.Clear();
            Console.WriteLine("Filter dinosaurs bigger than the input age \n");
            Console.Write("\nAge: ");
            string inputAge = Console.ReadLine();
            int? age = helpers.IntValidation(inputAge);
            helpers.InputErrorHandler(age);
            
            List<Dinosaur> dinosaursAge = queryService.GetDinosaursByAge(age);
            
            Console.Clear();
            Console.WriteLine($"Dinosaurs bigger than {age} years:\n");
            
            helpers.ShowDinosaurs(dinosaursAge);

            helpers.Hold();
            
            break;
        case "7":
            Console.Clear();
            Console.WriteLine($"--- Dinosaurs Types ---" +
                              $"\n1. Herbivore" +
                              $"\n2. Carnivore");

            Console.Write("Choose a type (1 - 2): ");
            string typeOpt = Console.ReadLine();
            string dinoType;

            switch (typeOpt)
            {
                case "1":
                    dinoType = "Herbivore";
                    break;
                case "2":
                    dinoType = "Carnivore";
                    break;
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
            
            break;
        case "9":
            
            break;
        case "10":
            
            break;
        case "11":
            
            break;
        case "12":
            
            break;
        case "13":
            
            break;
        case "14":
            
            break;
        case "15":
            
            break;
        case "16":
            
            break;
        case "0":
            
            break;
    }
}

string mainMenu = "===== NEOGENESIS PARK - DINOSAUR SYSTEM =====" +

                    "\n1. Register Dinosaur" +
                    "\n2. Update Dinosaur" +
                    "\n3. Delete Dinosaur" +
                    "\n4. Consult Dinosaurs" +
                    "\n5. Exit";

string LINQMenu = @"--- CONSULT DINOSAURS ---" +

                    "\n1. List all dinosaurs" +
                    "\n2. Get dinosaur by Id" +
                    "\n3. Get dinosaur by Email" +
                    "\n4. Filter by Zone" +
                    "\n5. Filter by Sector" +
                    "\n6. Filter by Age" +
                    "\n7. Filter by Type" +
                    "\n8. Show Name + Email" +
                    "\n9. Order by Creation Date" +
                    "\n10. Order by Species" +
                    "\n11. Count total dinosaurs" +
                    "\n12. Count by Zone" +
                    "\n13. Count by Sector" +
                    "\n14. Dinosaurs without TrackNumber" +
                    "\n15. Dinosaurs without Address" +
                    "\n16. Last registered dinosaurs" +
                    "\n0. Back";

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