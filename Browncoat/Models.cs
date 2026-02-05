namespace Browncoat;

// Can't stop the signal, Mal

public interface ICrewMember
{
    string Name { get; }
    string Role { get; }
}

public interface ICargo
{
    string Manifest { get; }
    decimal Value { get; }
}

public interface IWeapon
{
    string Name { get; }
    int Damage { get; }
}

// Shiny!
public class CrewMember : ICrewMember
{
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public string Specialty { get; set; } = "";
}

public class Pilot : CrewMember
{
    public string CallSign { get; set; } = "";
    public bool CanFlyAnything { get; set; } = true; // I'm a leaf on the wind
}

public class Mechanic : CrewMember
{
    public string FavoriteEngine { get; set; } = "Firefly-class";
    public bool TalksToShips { get; set; } = true;
}

public class Mercenary : CrewMember, IWeapon
{
    public string PreferredGun { get; set; } = "Vera";
    string IWeapon.Name => PreferredGun;
    public int Damage => 100;
}

// The special hell
public struct CargoContainer : ICargo
{
    public string Manifest { get; set; }
    public decimal Value { get; set; }
    public bool IsContraband { get; set; }
}

public struct FuelCell
{
    public double Capacity { get; set; }
    public double CurrentLevel { get; set; }
}

public struct Coordinates
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}

// Two by two, hands of blue
public sealed class AllianceAgent
{
    public string AgentId { get; set; } = "";
    public string Assignment { get; set; } = "";
}

public sealed class Reaver
{
    public string Territory { get; set; } = "";
    public int ThreatLevel { get; set; } = 10;
}

// Big damn heroes
public abstract class Mission
{
    public abstract string Objective { get; }
    public abstract decimal Payout { get; }
}

public class SmugglingRun : Mission
{
    public override string Objective => "Deliver cargo, no questions";
    public override decimal Payout => 5000m;
    public string Destination { get; set; } = "";
}

public class RescueMission : Mission
{
    public override string Objective => "Extract the target";
    public override decimal Payout => 10000m;
    public string TargetName { get; set; } = "";
}

// Miranda - what they did to them
public enum ShipStatus
{
    Flying,
    Grounded,
    Damaged,
    Captured
}

public enum CrewMood
{
    Shiny,
    Ornery,
    Mutinous,
    Heroic
}
