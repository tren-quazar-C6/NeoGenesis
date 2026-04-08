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

            helpers.Hold();
            break;
        case "2":
            
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
            List<Dinosaur> result = queryService.GetDinosaursByZone(zones[zoneOpt-1]);
            
            Console.Clear();
            Console.WriteLine($"Dinosaurs in {zones[zoneOpt-1]} zone:\n");
            
            foreach (var d in result)
            {
                Console.WriteLine($"Name: {d.Name} | Species: {d.Species} | Email: {d.Email}");
            }

            helpers.Hold();
            break;
        case "5":
            
            break;
        case "6":
            
            break;
        case "7":
            
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