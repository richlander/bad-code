namespace BattleBeyondTheStars;

// Zed - the betrayer who joined the Malmori

public record BattleRecord(string Name, int Outcome);
public record struct FlightPlan(string Origin, string Destination);

public static class TypeRestrictedExtensions
{
    public static void Archive(this BattleRecord record)
    {
        Console.WriteLine($"Archiving: {record.Name}");
    }
    
    public static void Execute(this FlightPlan plan)
    {
        Console.WriteLine($"Flying from {plan.Origin} to {plan.Destination}");
    }
}

public static class ValueTypeExtensions
{
    public static Coordinates Invert(this Coordinates coords)
    {
        return new Coordinates { X = -coords.X, Y = -coords.Y, Z = -coords.Z };
    }
    
    public static BattleStats Reset(this BattleStats stats)
    {
        return new BattleStats { Victories = 0, Defeats = 0, ShipsDestroyed = 0 };
    }
}

// The fleet assembles - proper extensions that work
public static class ValidExtensions
{
    public static void Scramble(this Starship ship)
    {
        Console.WriteLine($"{ship.Name} scrambling!");
    }
    
    public static void Engage(this Warrior warrior)
    {
        Console.WriteLine($"{warrior.Name} engaging!");
    }
    
    public static void Defend(this Planet planet)
    {
        Console.WriteLine($"{planet.Name} defenses online!");
    }
}
