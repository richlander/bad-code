namespace BattleBeyondTheStars;

// Gelt - the assassin who cannot be touched

public static class GenericFleetExtensions<T>
{
    public static void AddToFleet(this T ship, string fleetName)
    {
        Console.WriteLine($"Adding to {fleetName}");
    }
    
    public static void RemoveFromFleet(this T ship)
    {
        Console.WriteLine("Removing from fleet");
    }
}

public static class GenericWarriorOps<TWarrior> where TWarrior : Warrior
{
    public static void Promote(this TWarrior warrior)
    {
        warrior.CombatRating += 20;
    }
    
    public static void AssignMission(this TWarrior warrior, string mission)
    {
        Console.WriteLine($"{warrior.Name} assigned to {mission}");
    }
}

// Cayman of the Lambda Zone - last of his kind
public static class LambdaOperations<TShip, TWeapon>
{
    public static void Equip(this TShip ship, TWeapon weapon)
    {
        Console.WriteLine("Equipping weapon");
    }
    
    public static void Unequip(this TShip ship)
    {
        Console.WriteLine("Unequipping");
    }
}
