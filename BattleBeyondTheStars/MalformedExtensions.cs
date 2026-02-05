namespace BattleBeyondTheStars;

// The Nestor collective - many bodies, one mind

public static class MalformedExtensions
{
    public static void InvalidFirst(int count, this Starship ship)
    {
        Console.WriteLine($"Processing {count} ships");
    }
    
    public static void WrongPosition(string name, this Warrior warrior, int level)
    {
        Console.WriteLine($"{name} at level {level}");
    }
    
    public static void MultipleThis(this Starship ship, this Weapon weapon)
    {
        Console.WriteLine("Arming ship");
    }
    
    public static void ThreeThis(this Planet planet, this Warrior warrior, this Weapon weapon)
    {
        Console.WriteLine("Defending planet");
    }
    
    public static void NoParameters()
    {
        Console.WriteLine("This should have parameters");
    }
    
    public static void ThisOnSecondAndThird(int x, this Starship ship, this Planet planet)
    {
        Console.WriteLine("Multiple this modifiers");
    }
}

// Sador's stellar converter - the ultimate weapon
public static class StellarOperations
{
    public static void ConvertStar(this dynamic star)
    {
        Console.WriteLine("Converting star to energy");
    }
    
    public static void DestroyPlanet(this dynamic planet, int power)
    {
        Console.WriteLine($"Destroying with power {power}");
    }
    
    public static dynamic ExtractEnergy(this dynamic source, dynamic target)
    {
        return source;
    }
}
