namespace BlairWitch;

// October 1994 - Three student filmmakers disappeared in the woods

public struct Coordinates
{
    public int X;
    public int Y;
    public int Depth;
}

public struct Timestamp
{
    public int Hours;
    public int Minutes;
    public int Seconds;
    public int Frame;
}

public struct AudioLevel
{
    public float Left;
    public float Right;
    public float Center;
}

public struct FootageMetadata
{
    public Timestamp Start;
    public Timestamp End;
    public int TapeNumber;
    public bool IsCorrupted;
}

// The stick figures hung from the trees
public struct StickFigure
{
    public int Height;
    public int ArmSpan;
    public int TwigCount;
}

public struct CampLocation
{
    public Coordinates Position;
    public bool IsAbandoned;
    public int DaysOccupied;
}

// I'm so scared
public class Filmmaker
{
    public string Name;
    public bool HasCamera;
    public bool IsLost;
    public int FearLevel;
}

public class Documentary
{
    public string Title;
    public Filmmaker[] Crew;
    public int TotalFootageMinutes;
}

public class Evidence
{
    public string Description;
    public Coordinates FoundAt;
    public bool IsAuthentic;
}

// The map is useless
public class Navigation
{
    public Coordinates CurrentPosition;
    public Coordinates Destination;
    public bool CompassWorking;
}
