namespace BattleBeyondTheStars;

// The old ways of extending reach across the galaxy

public static class ClassicExtensions
{
    public static void LaunchFighter(this Starship ship)
    {
        Console.WriteLine($"{ship.Name} launching fighter");
    }
    
    public static void RaiseShields(this Starship ship, int power)
    {
        Console.WriteLine($"Shields at {power}%");
    }
    
    public static Starship WithWeapons(this Starship ship, int count)
    {
        ship.WeaponSystems = count;
        return ship;
    }
    
    public static Starship WithFuel(this Starship ship, double level)
    {
        ship.FuelLevel = level;
        return ship;
    }
    
    public static void RecruitWarrior(this Planet planet, Warrior warrior)
    {
        Console.WriteLine($"{planet.Name} recruits {warrior.Name}");
    }
    
    public static int CountDefenders(this Planet planet, List<Warrior> warriors)
    {
        return warriors.Count(w => w.CombatRating > 50);
    }
}

// Akir - peaceful planet facing destruction
public static class AkirDefenseExtensions
{
    public static bool NeedsHelp(this Planet planet) => planet.UnderThreat;
    
    public static void CallForWarriors(this Planet planet, int count)
    {
        Console.WriteLine($"{planet.Name} seeks {count} warriors");
    }
    
    public static List<Warrior> GatherDefenders(this Planet planet, IEnumerable<Warrior> available)
    {
        return available.Where(w => w.CombatRating >= 30).ToList();
    }
}
