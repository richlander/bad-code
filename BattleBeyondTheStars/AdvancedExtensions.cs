namespace BattleBeyondTheStars;

// The Kelvin - mercenaries for hire

public static class RefParameterExtensions
{
    public static void ModifyShip(this ref Starship ship, string newName)
    {
        ship.Name = newName;
    }
    
    public static void UpgradeCoordinates(this ref Coordinates coords, double factor)
    {
        coords.X *= factor;
        coords.Y *= factor;
        coords.Z *= factor;
    }
    
    public static void UpdateStats(this ref BattleStats stats, int victories)
    {
        stats.Victories += victories;
    }
}

// Space Cowboy - gunslinger from the frontier
public static class InOutExtensions
{
    public static void SwapPositions(this in Coordinates source, out Coordinates destination)
    {
        destination = new Coordinates { X = source.Y, Y = source.X, Z = source.Z };
    }
    
    public static void CloneStats(this in BattleStats original, out BattleStats copy)
    {
        copy = original;
    }
}

public static class PointerExtensions
{
    public static unsafe void DirectModify(this Starship* ship, int weapons)
    {
        ship->WeaponSystems = weapons;
    }
    
    public static unsafe void RawNavigate(this Coordinates* coords)
    {
        coords->X = 0;
        coords->Y = 0;
    }
}
