namespace EnterTheRing;

public enum MoleculeState
{
    Dormant,
    Active,
    Spreading,
    Constructing,
    Transcendent
}

public enum GateStatus
{
    Closed,
    Opening,
    Open,
    Unstable,
    Collapsed
}

// It reaches out, it reaches out, it reaches out...
public class Protomolecule
{
    public string Id { get; set; } = "";
    public MoleculeState State { get; set; }
    public double Biomass { get; set; }
    public DateTime LastActivity { get; set; }
    public List<string> InfectedHosts { get; set; } = new();
    public Dictionary<string, double> EnergySignatures { get; set; } = new();
}

// The gates between star systems
public class RingGate
{
    public string Id { get; set; } = "";
    public string SourceSystem { get; set; } = "";
    public string DestinationSystem { get; set; } = "";
    public GateStatus Status { get; set; }
    public double TransitSpeed { get; set; }
    public int ActiveTransits { get; set; }
    public DateTime LastTransit { get; set; }
}

// The slow zone at the center
public class RingStation
{
    public string Id { get; set; } = "";
    public int ConnectedGates { get; set; }
    public double PowerLevel { get; set; }
    public bool DefensesActive { get; set; }
    public List<RingGate> Gates { get; set; } = new();
}

// Ships passing through
public class Vessel
{
    public string Name { get; set; } = "";
    public string Registry { get; set; } = "";
    public string CurrentSystem { get; set; } = "";
    public double Speed { get; set; }
    public double FuelRemaining { get; set; }
    public int CrewCount { get; set; }
    public bool HasProtomolecule { get; set; }
}

// Transmission from the void
public class Signal
{
    public string SourceId { get; set; } = "";
    public byte[] Data { get; set; } = Array.Empty<byte>();
    public DateTime Timestamp { get; set; }
    public double Strength { get; set; }
    public bool Decoded { get; set; }
}
