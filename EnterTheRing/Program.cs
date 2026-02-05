// It reaches out, it reaches out, it reaches out...
// One hundred and thirteen times a second, nothing answers.
// And it reaches out.

using EnterTheRing;

Console.WriteLine("=== Ring Gate Control System ===\n");

var protoController = new ProtomoleculeController();
var gateController = new RingGateController();
var fleetManager = new FleetManager();
var signalProcessor = new SignalProcessor();

// Something is waking up on Eros
var sample = new Protomolecule
{
    Id = "EROS-001",
    State = MoleculeState.Dormant,
    Biomass = 100
};

Console.WriteLine("Activating sample...");
protoController.ActivateSample(sample);

// The Rocinante approaches
var roci = new Vessel
{
    Name = "Rocinante",
    Registry = "MCRN-TACHI",
    CurrentSystem = "Sol",
    CrewCount = 4,
    FuelRemaining = 1000
};

fleetManager.RegisterVessel(roci);

// Transit through the ring
var gate = new RingGate
{
    Id = "SOL-GATE",
    SourceSystem = "Sol",
    DestinationSystem = "Laconia",
    Status = GateStatus.Closed
};

Console.WriteLine($"\nRequesting transit through {gate.Id}...");
gateController.RequestTransit(roci, gate);

// Listen for signals
Console.WriteLine("\nMonitoring for signals...");
var signal = signalProcessor.ReceiveSignal();
signalProcessor.DecodeSignal(signal);

// Check the fleet
var contaminated = fleetManager.GetContaminatedVessels();
Console.WriteLine($"\nContaminated vessels: {contaminated.Count}");

// The work continues
Console.WriteLine("\n=== The work must continue ===");
