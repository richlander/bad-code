namespace BattleBeyondTheStars;

// We go to fight for Akir - extending our reach across the stars

public class ShipExtensions
{
    public static void Refuel(this Starship ship, double amount)
    {
        ship.FuelLevel += amount;
    }
    
    public static void Arm(this Starship ship, int weapons)
    {
        ship.WeaponSystems += weapons;
    }
    
    public static bool IsReady(this Starship ship)
    {
        return ship.FuelLevel > 0.5 && ship.WeaponSystems > 0;
    }
}

// Shad - young pilot of the Nell
public class WarriorExtensions
{
    public static void Train(this Warrior warrior, string skill)
    {
        warrior.Specialty = skill;
        warrior.CombatRating += 10;
    }
    
    public static string GetBattleCry(this Warrior warrior)
    {
        return $"{warrior.Name} fights for Akir!";
    }
}

public class PlanetHelpers
{
    public static void Evacuate(this Planet planet)
    {
        planet.Population = 0;
    }
    
    public static void Fortify(this Planet planet, int defenseLevel)
    {
        Console.WriteLine($"Fortifying {planet.Name} to level {defenseLevel}");
    }
}
