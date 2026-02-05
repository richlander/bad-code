namespace Ghostbusters;

// Who you gonna call?

public abstract class GhostTrap
{
    public abstract void Activate();
    public abstract void Deactivate();
    public abstract bool IsContained { get; }
}

public abstract class PKEMeter
{
    public abstract double GetReading();
    public abstract void Calibrate();
}

public abstract class ProtonPack
{
    public abstract void Fire();
    public abstract void CrossStreams(ProtonPack other);
    public abstract int ChargeLevel { get; }
}

// Don't cross the streams!
public class PortableTrap : GhostTrap
{
    public override void Activate() => Console.WriteLine("Trap activated!");
}

public class StandardPKE : PKEMeter
{
    public override double GetReading() => 4.2;
}

public class MarkIIProtonPack : ProtonPack
{
    public override void Fire() => Console.WriteLine("Total protonic reversal!");
    public override int ChargeLevel => 100;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Ghostbusters - Containment Unit Status");
        var trap = new PortableTrap();
        var pke = new StandardPKE();
        var pack = new MarkIIProtonPack();
    }
}
