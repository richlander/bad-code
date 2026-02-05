namespace Browncoat;

// I aim to misbehave

public class ShipRegistry<T> where T : class, ICrewMember, new()
{
    private readonly List<T> _crew = [];
    
    public void AddCrew(T member) => _crew.Add(member);
    public IEnumerable<T> GetCrew() => _crew;
}

public class CargoHold<T> where T : struct, ICargo
{
    private readonly List<T> _cargo = [];
    
    public void LoadCargo(T item) => _cargo.Add(item);
    public decimal TotalValue => _cargo.Sum(c => c.Value);
}

public class WeaponsLocker<T> where T : class, IWeapon
{
    private readonly List<T> _weapons = [];
    
    public void Store(T weapon) => _weapons.Add(weapon);
    public int TotalFirepower => _weapons.Sum(w => w.Damage);
}

// You can't take the sky from me
public class NavigationSystem<TCoord> where TCoord : struct
{
    public TCoord CurrentPosition { get; set; }
    public TCoord Destination { get; set; }
    
    public void PlotCourse(TCoord destination) => Destination = destination;
}

public class MissionPlanner<TMission> where TMission : Mission
{
    private readonly List<TMission> _activeMissions = [];
    
    public void AcceptMission(TMission mission) => _activeMissions.Add(mission);
    public decimal PotentialEarnings => _activeMissions.Sum(m => m.Payout);
}

// Curse your sudden but inevitable betrayal!
public class ThreatTracker<T> where T : class
{
    private readonly List<T> _threats = [];
    
    public void Track(T threat) => _threats.Add(threat);
    public int ThreatCount => _threats.Count;
}

public class FuelManager<T> where T : struct
{
    private T _reserves;
    
    public void SetReserves(T amount) => _reserves = amount;
    public T GetReserves() => _reserves;
}

// Objects in space
public static class VerseOperations
{
    public static void RegisterCrew<T>(T member) where T : class, ICrewMember, new()
    {
        Console.WriteLine($"Registered: {member.Name}");
    }
    
    public static void StoreCargo<T>(T cargo) where T : struct, ICargo
    {
        Console.WriteLine($"Stored cargo worth: {cargo.Value}");
    }
    
    public static T CreateDefault<T>() where T : new()
    {
        return new T();
    }
    
    public static void ProcessValue<T>(T value) where T : struct
    {
        Console.WriteLine($"Processing: {value}");
    }
    
    public static void TrackEntity<T>(T entity) where T : class
    {
        Console.WriteLine($"Tracking: {entity}");
    }
    
    public static TResult ConvertCargo<TCargo, TResult>(TCargo cargo) 
        where TCargo : struct, ICargo
        where TResult : class, new()
    {
        Console.WriteLine($"Converting cargo: {cargo.Manifest}");
        return new TResult();
    }
}
