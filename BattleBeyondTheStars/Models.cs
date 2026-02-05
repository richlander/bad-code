namespace BattleBeyondTheStars;

// Akir needs warriors - seven mercenaries to save them from Sador

public class Starship
{
    public string Name { get; set; } = "";
    public int WeaponSystems { get; set; }
    public double FuelLevel { get; set; }
}

public class Warrior
{
    public string Name { get; set; } = "";
    public string Specialty { get; set; } = "";
    public int CombatRating { get; set; }
}

public class Planet
{
    public string Name { get; set; } = "";
    public long Population { get; set; }
    public bool UnderThreat { get; set; }
}

public class Weapon
{
    public string Type { get; set; } = "";
    public int Damage { get; set; }
    public int Range { get; set; }
}

// Nell - the ship with a heart
public class ShipAI
{
    public string Personality { get; set; } = "";
    public bool IsSentient { get; set; }
    public string BondedPilot { get; set; } = "";
}

// The Nestor - a single consciousness in many bodies
public class HiveMind
{
    public int BodyCount { get; set; }
    public string CollectiveGoal { get; set; } = "";
}

public class Mercenary : Warrior
{
    public decimal Price { get; set; }
    public bool HasShip { get; set; }
}

// Sador of the Malmori - he who conquers
public class Conqueror
{
    public string Empire { get; set; } = "";
    public int FleetSize { get; set; }
    public string UltimateWeapon { get; set; } = "";
}

public struct Coordinates
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}

public struct BattleStats
{
    public int Victories { get; set; }
    public int Defeats { get; set; }
    public int ShipsDestroyed { get; set; }
}
