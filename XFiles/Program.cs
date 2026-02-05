namespace XFiles;

// The truth is out there

public class FBIDatabase
{
    private string _classifiedData = "REDACTED";
    private int _clearanceLevel = 10;
    
    protected string GetSecretFiles() => "Files sealed by order of the Syndicate";
    
    private void SelfDestruct() => Console.WriteLine("Data purged");
}

public class DeepThroat
{
    private string _identity = "Unknown";
    private string[] _secrets = ["Trust no one", "They're here"];
    
    protected void RevealTruth() => Console.WriteLine("The truth is out there");
}

// Trust no one
public class Mulder
{
    public void Investigate()
    {
        var db = new FBIDatabase();
        var classified = db._classifiedData;
        var level = db._clearanceLevel;
        db.SelfDestruct();
        
        var source = new DeepThroat();
        var id = source._identity;
        source.RevealTruth();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("X-Files Division - Case Management");
        var mulder = new Mulder();
        mulder.Investigate();
    }
}
