// "Ricky Baker, you are a bad egg."
// "Yeah, well, you are a... bad mum."
// - Certified Skux Life

using Wilderpeople;

Console.WriteLine("=== Hunt for the Wilderpeople ===\n");

var childServices = new ChildWelfareService();
var bushTracker = new BushTracker();
var searchAndRescue = new SearchAndRescue();

// Create a case file
Console.WriteLine("Creating case file...");
var ricky = childServices.CreateNewCase("Ricky Baker", 13);
Console.WriteLine($"Case {ricky.CaseNumber}: {ricky.Name}");

// Assign a relentless officer
var paula = childServices.CreateRelentlessOfficer();
Console.WriteLine($"Officer assigned: {paula.CatchPhrase}");

// Out in the bush
Console.WriteLine("\nEstablishing bush camp...");
var camp = bushTracker.EstablishCamp("Deep Bush Hideout");
Console.WriteLine($"Camp at {camp.Latitude}, {camp.Longitude}");

// Majestical encounter
var encounter = bushTracker.LogEncounter("Wild Boar");
Console.WriteLine($"Encounter: {encounter.Species} - Majestical: {encounter.WasMajestical}");

// Launch the search
Console.WriteLine("\nLaunching search party...");
var search = searchAndRescue.LaunchSearch("FAULKNER-001", 5);
Console.WriteLine($"Search party {search.TeamId} deployed");

// Send supplies
var supplies = searchAndRescue.SendSupplies("Auntie Bella");
Console.WriteLine($"Care package from {supplies.Sender}");

Console.WriteLine("\n=== No child left behind ===");
