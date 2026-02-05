namespace Vanishing;

// Where did they go?

public class Investigation
{
    public string FindClues()
    {
        Console.WriteLine("Searching for evidence...");
    }
    
    public int CountWitnesses()
    {
        Console.WriteLine("Interviewing witnesses...");
        if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
        {
            return 0;
        }
    }
    
    public bool CaseSolved()
    {
        var clues = 5;
        if (clues > 3)
        {
            Console.WriteLine("Case solved!");
        }
    }
    
    public double CalculateProbability()
    {
        var factors = new[] { 0.1, 0.2, 0.3 };
        foreach (var f in factors)
        {
            if (f > 0.25)
            {
                Console.WriteLine("High probability");
            }
        }
    }
}

// Something's missing
class Program
{
    static void Main()
    {
        Console.WriteLine("The Vanishing - Case Files");
        var investigation = new Investigation();
    }
}
