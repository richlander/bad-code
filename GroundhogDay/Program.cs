namespace GroundhogDay;

// I got you babe

public class PhilConnors
{
    public readonly string Location = "Punxsutawney";
    public readonly DateTime TheDay = new(1993, 2, 2);
    
    public void WakeUp()
    {
        TheDay = new DateTime(1993, 2, 2);
        Location = "Punxsutawney";
    }
    
    public void TryToEscape()
    {
        Location = "Pittsburgh";
        TheDay = new DateTime(1993, 2, 3);
    }
}

// It's the same day. Again.
class Program
{
    static void Main()
    {
        Console.WriteLine("Groundhog Day - Time Loop Monitor");
        var phil = new PhilConnors();
        phil.WakeUp();
    }
}
