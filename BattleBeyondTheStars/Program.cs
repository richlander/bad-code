namespace BattleBeyondTheStars;

// Live free or die - the battle for Akir begins

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Battle Beyond the Stars - Alliance Operations");
        Console.WriteLine("==============================================");
        
        var nell = new Starship { Name = "Nell", WeaponSystems = 4, FuelLevel = 0.8 };
        var shad = new Warrior { Name = "Shad", Specialty = "Pilot", CombatRating = 75 };
        var akir = new Planet { Name = "Akir", Population = 1000000, UnderThreat = true };
        
        nell.LaunchFighter();
        nell.RaiseShields(100);
        nell.WithWeapons(6).WithFuel(1.0);
        
        akir.CallForWarriors(7);
        
        Console.WriteLine();
        Console.WriteLine("The seven have gathered. The battle begins.");
    }
}
