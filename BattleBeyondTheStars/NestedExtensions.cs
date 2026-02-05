namespace BattleBeyondTheStars;

// Cowboy - from the planet of outlaws

public static class OuterRimOperations
{
    public static class NestedWeaponExtensions
    {
        public static void Fire(this Weapon weapon)
        {
            Console.WriteLine($"Firing {weapon.Type}!");
        }
        
        public static void Reload(this Weapon weapon, int ammo)
        {
            Console.WriteLine($"Reloading with {ammo} rounds");
        }
        
        public static int CalculateImpact(this Weapon weapon, int distance)
        {
            return weapon.Damage - (distance / weapon.Range);
        }
    }
    
    public static class NestedNavigationExtensions
    {
        public static double DistanceTo(this Coordinates from, Coordinates to)
        {
            var dx = to.X - from.X;
            var dy = to.Y - from.Y;
            var dz = to.Z - from.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
        
        public static void PlotCourse(this Starship ship, Coordinates destination)
        {
            Console.WriteLine($"{ship.Name} plotting course");
        }
    }
}

// Saint-Exmin - Valkyrie warrior seeking glory
public static class ValkyrieTactics
{
    private static class PrivateExtensions
    {
        public static void SecretMove(this Warrior warrior)
        {
            Console.WriteLine("Executing secret maneuver");
        }
        
        public static void HiddenStrike(this Weapon weapon, int power)
        {
            Console.WriteLine($"Hidden strike with power {power}");
        }
    }
}
