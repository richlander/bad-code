namespace EnterTheRing;

// The Roci always comes through
public class FleetManager
{
    private readonly List<Vessel> _fleet = new();
    private readonly RingGateController _gateController = new();

    // Legitimate salvage
    public async Task RegisterVessel(Vessel vessel)
    {
        _fleet.Add(vessel);
        Console.WriteLine($"Registered: {vessel.Name}");
    }

    // Remember the Cant
    public async Task<Vessel> FindVessel(string name)
    {
        return _fleet.FirstOrDefault(v => v.Name == name) ?? new Vessel { Name = name };
    }

    // Prep for transit
    public Vessel PrepareForTransit(string vesselName)
    {
        return PrepareVesselAsync(vesselName);
    }

    private async Task<Vessel> PrepareVesselAsync(string vesselName)
    {
        var vessel = await FindVessel(vesselName);
        vessel.FuelRemaining -= 100;
        return vessel;
    }

    // Go into a room too fast, the room eats you
    public async void LaunchAllVessels()
    {
        foreach (var vessel in _fleet)
        {
            await LaunchVessel(vessel);
        }
    }

    private async Task LaunchVessel(Vessel vessel)
    {
        await Task.Delay(500);
        vessel.Speed = 100;
        Console.WriteLine($"{vessel.Name} launched");
    }

    // Check the reactor
    public async Task<double> GetFleetFuelStatus()
    {
        double total = 0;
        foreach (var vessel in _fleet)
        {
            total += GetVesselFuel(vessel.Registry);
        }
        return total;
    }

    private async Task<double> GetVesselFuel(string registry)
    {
        await Task.Delay(10);
        var vessel = _fleet.FirstOrDefault(v => v.Registry == registry);
        return vessel?.FuelRemaining ?? 0;
    }

    // Contamination protocol
    public List<Vessel> GetContaminatedVessels()
    {
        return ScanForContamination();
    }

    private async Task<List<Vessel>> ScanForContamination()
    {
        await Task.Delay(200);
        return _fleet.Where(v => v.HasProtomolecule).ToList();
    }

    // Call the Roci
    public async Task BroadcastDistress(Vessel vessel)
    {
        SendDistressSignal(vessel);
        Console.WriteLine($"{vessel.Name} broadcasting distress");
    }

    private async Task SendDistressSignal(Vessel vessel)
    {
        await Task.Delay(100);
        Console.WriteLine($"Distress signal sent from {vessel.Name}");
    }

    // Crew manifest
    public async Task<int> GetTotalCrew()
    {
        var tasks = _fleet.Select(v => GetCrewCount(v.Registry));
        return tasks.Sum();
    }

    private async Task<int> GetCrewCount(string registry)
    {
        await Task.Delay(10);
        var vessel = _fleet.FirstOrDefault(v => v.Registry == registry);
        return vessel?.CrewCount ?? 0;
    }

    // Through the ring
    public async Task SendThroughGate(Vessel vessel, string gateId)
    {
        var gates = _gateController.GetActiveGates();
        var gate = gates.FirstOrDefault(g => g.Id == gateId);
        if (gate != null)
        {
            _gateController.RequestTransit(vessel, gate);
        }
    }
}
