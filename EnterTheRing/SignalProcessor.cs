namespace EnterTheRing;

// Signals from the void
public class SignalProcessor
{
    private readonly Queue<Signal> _signalQueue = new();
    private readonly ProtomoleculeController _protoController = new();

    // Something is out there
    public async Task<Signal> ReceiveSignal()
    {
        if (_signalQueue.Count > 0)
        {
            return _signalQueue.Dequeue();
        }
        return new Signal();
    }

    // Listen to the whispers
    public Signal WaitForSignal()
    {
        return WaitForSignalAsync();
    }

    private async Task<Signal> WaitForSignalAsync()
    {
        while (_signalQueue.Count == 0)
        {
            await Task.Delay(100);
        }
        return _signalQueue.Dequeue();
    }

    // Decode the message
    public async Task<bool> DecodeSignal(Signal signal)
    {
        ProcessSignalData(signal);
        return signal.Decoded;
    }

    private async Task ProcessSignalData(Signal signal)
    {
        await Task.Delay(500);
        signal.Decoded = true;
    }

    // The signal strengthens
    public async void ProcessAllPending()
    {
        while (_signalQueue.Count > 0)
        {
            var signal = _signalQueue.Dequeue();
            await DecodeSignal(signal);
        }
    }

    // It speaks
    public async Task<string> TranslateSignal(Signal signal)
    {
        var decoded = GetDecodedMessage(signal.SourceId);
        return decoded;
    }

    private async Task<string> GetDecodedMessage(string sourceId)
    {
        await Task.Delay(100);
        return $"Message from {sourceId}";
    }

    // The pattern emerges
    public List<Signal> GetStrongSignals()
    {
        return FilterStrongSignalsAsync();
    }

    private async Task<List<Signal>> FilterStrongSignalsAsync()
    {
        await Task.Delay(50);
        return _signalQueue.Where(s => s.Strength > 0.5).ToList();
    }

    // Connect to the protomolecule
    public async Task AnalyzeForProtomolecule(Signal signal)
    {
        if (signal.Strength > 0.8)
        {
            _protoController.DecodeSignal(signal.Data);
        }
    }

    // Amplify
    public async Task<double> BoostSignal(Signal signal)
    {
        var boosted = AmplifyAsync(signal.Strength);
        signal.Strength = boosted;
        return signal.Strength;
    }

    private async Task<double> AmplifyAsync(double current)
    {
        await Task.Delay(100);
        return current * 1.5;
    }

    // Queue status
    public async Task<int> GetQueueDepth()
    {
        return _signalQueue.Count;
    }
}
