namespace Browncoat;

// When you can't run, you crawl. When you can't crawl, you find someone to carry you.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Browncoat Operations - Serenity Crew Management");
        Console.WriteLine("================================================");
        
        var shipOps = new SerenityOps();
        shipOps.ManageCrew();
        shipOps.HandleCargo();
        shipOps.PrepareWeapons();
        shipOps.Navigate();
        shipOps.PlanMissions();
        shipOps.TrackThreats();
        shipOps.ManageFuel();
        
        var commands = new VerseCommands();
        commands.RegisterOperations();
        commands.StoreOperations();
        commands.CreateDefaults();
        commands.ProcessValues();
        commands.TrackEntities();
        commands.ConvertOperations();
        
        var manifest = new CrewManifest();
        manifest.BuildManifest();
        manifest.AssignRoles();
        manifest.TrackInventory();
        manifest.MixedOperations();
        
        Console.WriteLine();
        Console.WriteLine("We're still flying. That's not much.");
        Console.WriteLine("It's enough.");
    }
}
