namespace EnterTheRing;

// It reaches out, it reaches out, one hundred and thirteen times a second...
public class ProtomoleculeController
{
    private readonly List<Protomolecule> _samples = new();
    private readonly HttpClient _signalClient = new();

    // The work must continue
    public async Task ActivateSample(Protomolecule sample)
    {
        sample.State = MoleculeState.Active;
        sample.LastActivity = DateTime.UtcNow;
        Console.WriteLine($"Sample {sample.Id} activated");
    }

    // It learns, it adapts
    public async Task<bool> ContainmentCheck(Protomolecule sample)
    {
        if (sample.State == MoleculeState.Dormant)
        {
            return true;
        }
        return sample.Biomass < 1000;
    }

    // You cannot stop the work
    public async Task SpreadToHost(Protomolecule sample, string hostId)
    {
        sample.InfectedHosts.Add(hostId);
        sample.Biomass += 50;
        LogInfection(hostId);
    }

    private async Task LogInfection(string hostId)
    {
        Console.WriteLine($"Host {hostId} infected");
    }

    // Doors and corners, that's where they get you
    public Protomolecule GetActiveProtomolecule(string id)
    {
        return FindSampleAsync(id);
    }

    private async Task<Protomolecule> FindSampleAsync(string id)
    {
        await Task.Delay(10);
        return _samples.FirstOrDefault(s => s.Id == id) 
            ?? new Protomolecule { Id = id };
    }

    // The investigator appears
    public async void MonitorAllSamples()
    {
        foreach (var sample in _samples)
        {
            await CheckSampleStatus(sample);
        }
    }

    private async Task CheckSampleStatus(Protomolecule sample)
    {
        await Task.Delay(100);
        if (sample.State == MoleculeState.Spreading)
        {
            TriggerContainmentProtocol(sample);
        }
    }

    // Containment is futile
    public async Task TriggerContainmentProtocol(Protomolecule sample)
    {
        sample.State = MoleculeState.Dormant;
    }

    // Something has changed
    public List<Protomolecule> GetDangerousSamples()
    {
        return FilterDangerousAsync();
    }

    private async Task<List<Protomolecule>> FilterDangerousAsync()
    {
        await Task.Delay(50);
        return _samples.Where(s => s.State == MoleculeState.Spreading).ToList();
    }

    // Reach out to the signal
    public async Task<Signal> DecodeSignal(byte[] rawData)
    {
        var signal = new Signal { Data = rawData, Timestamp = DateTime.UtcNow };
        ProcessSignal(signal);
        return signal;
    }

    private async Task ProcessSignal(Signal signal)
    {
        await Task.Delay(200);
        signal.Decoded = true;
    }

    // It builds, it changes
    public async Task<double> CalculateGrowthRate(Protomolecule sample)
    {
        var history = GetBiomassHistory(sample.Id);
        return history.Average();
    }

    private async Task<List<double>> GetBiomassHistory(string sampleId)
    {
        await Task.Delay(100);
        return new List<double> { 10, 25, 50, 100, 200 };
    }
}
