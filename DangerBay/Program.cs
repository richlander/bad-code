// Danger Bay - Marine Rescue Management System
// "It's not just a job, it's an adventure!"
// Based at the Vancouver Aquarium Marine Science Centre

using DangerBay;

Console.WriteLine("=== Danger Bay Marine Rescue System ===\n");

// Another day at the aquarium...
var rescueCenter = new RescueCenter();
var missionControl = new MissionControl(rescueCenter);
var vetServices = new VetServices(rescueCenter);
var habitatManager = new HabitatManager();

// The phone is ringing
Console.WriteLine("Incoming rescue call from Horseshoe Bay...");

var mission = missionControl.CreateMission(
    "Horseshoe Bay",
    "Injured harbour seal on the rocks",
    "Captain Mike"
);

Console.WriteLine($"Mission {mission.Id} created");
Console.WriteLine($"Coordinator: {mission.Coordinator.Name}");

missionControl.DispatchMission(mission);

// Meanwhile, checking on current residents
var criticalAnimals = rescueCenter.GetCriticalAnimals();
Console.WriteLine($"\nCritical animals requiring attention: {criticalAnimals.Count}");

// Grant does his rounds
foreach (var animal in criticalAnimals)
{
    var report = rescueCenter.GetAnimalReport(animal);
    Console.WriteLine(report);
}

Console.WriteLine("\n=== End of Day Report ===");
var speciesCount = rescueCenter.GetAnimalCountBySpecies();
foreach (var kvp in speciesCount)
{
    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
}

Console.WriteLine("\nDanger Bay - Where every day is an adventure!");
