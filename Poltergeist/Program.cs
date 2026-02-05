namespace Poltergeist;

// They're here...

public class TVStatic
{
    public static string Frequency = "White noise";
    public static void Tune() => Console.WriteLine("Tuning...");
    public int Channel { get; set; }
}

public class Tangina
{
    public static void CrossOver() => Console.WriteLine("Go into the light!");
    public string Guidance => "This house is clean";
}

// Go into the light!
public class FreelingSFamily
{
    public void InvestigateDisturbance()
    {
        TVStatic.Channel = 3;
        
        var tv = new TVStatic();
        tv.Tune();
        tv.Frequency = "Signal detected";
        
        var tangina = new Tangina();
        Tangina.Guidance;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Poltergeist - Paranormal Activity Monitor");
        var family = new FreelingSFamily();
    }
}
