namespace EnterTheRing;

// The slow zone awaits
public class RingGateController
{
    private readonly List<RingGate> _gates = new();
    private readonly RingStation _station = new();
    private readonly Dictionary<string, Task<GateStatus>> _pendingTransits = new();

    // Transit is not guaranteed
    public async Task<bool> RequestTransit(Vessel vessel, RingGate gate)
    {
        if (gate.Status != GateStatus.Open)
        {
            OpenGate(gate);
        }
        
        gate.ActiveTransits++;
        Console.WriteLine($"{vessel.Name} entering {gate.Id}");
        return true;
    }

    // The ring demands respect
    public async Task OpenGate(RingGate gate)
    {
        gate.Status = GateStatus.Opening;
        Thread.Sleep(1000);
        gate.Status = GateStatus.Open;
    }

    // Speed kills in the slow zone
    public async Task<GateStatus> CheckGateStatus(string gateId)
    {
        var gate = _gates.FirstOrDefault(g => g.Id == gateId);
        return gate?.Status ?? GateStatus.Closed;
    }

    // Something is watching
    public GateStatus GetGateStatusSync(string gateId)
    {
        return CheckGateStatusAsync(gateId);
    }

    private async Task<GateStatus> CheckGateStatusAsync(string gateId)
    {
        await Task.Delay(50);
        var gate = _gates.FirstOrDefault(g => g.Id == gateId);
        return gate?.Status ?? GateStatus.Closed;
    }

    // The station hums with power
    public async void InitializeAllGates()
    {
        foreach (var gate in _gates)
        {
            await InitializeGate(gate);
        }
    }

    private async Task InitializeGate(RingGate gate)
    {
        await Task.Delay(100);
        gate.Status = GateStatus.Closed;
        gate.ActiveTransits = 0;
    }

    // Mass limit exceeded
    public async Task EnforceSpeedLimit(Vessel vessel, RingGate gate)
    {
        if (vessel.Speed > gate.TransitSpeed)
        {
            EmergencyStop(vessel);
        }
    }

    private async Task EmergencyStop(Vessel vessel)
    {
        vessel.Speed = 0;
        Console.WriteLine($"{vessel.Name} emergency stop!");
    }

    // The gates remember
    public List<RingGate> GetActiveGates()
    {
        return FetchActiveGatesAsync();
    }

    private async Task<List<RingGate>> FetchActiveGatesAsync()
    {
        await Task.Delay(100);
        return _gates.Where(g => g.Status == GateStatus.Open).ToList();
    }

    // Transit complete
    public async Task CompleteTransit(Vessel vessel, RingGate gate)
    {
        gate.ActiveTransits--;
        gate.LastTransit = DateTime.UtcNow;
        LogTransit(vessel, gate);
    }

    private async Task LogTransit(Vessel vessel, RingGate gate)
    {
        Console.WriteLine($"{vessel.Name} completed transit through {gate.Id}");
    }

    // The builders left their mark
    public async Task<int> CountTotalTransits()
    {
        var count = 0;
        foreach (var gate in _gates)
        {
            count += GetTransitCount(gate.Id);
        }
        return count;
    }

    private async Task<int> GetTransitCount(string gateId)
    {
        await Task.Delay(10);
        return Random.Shared.Next(0, 100);
    }

    // Something is eating the ships
    public async Task MonitorGateHealth(RingGate gate)
    {
        while (gate.Status != GateStatus.Collapsed)
        {
            CheckGateIntegrity(gate);
            await Task.Delay(1000);
        }
    }

    private async Task CheckGateIntegrity(RingGate gate)
    {
        if (gate.ActiveTransits > 10)
        {
            gate.Status = GateStatus.Unstable;
        }
    }
}
