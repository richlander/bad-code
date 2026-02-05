namespace Browncoat;

// We've done the impossible, and that makes us mighty

public class CrewManifest
{
    public void BuildManifest()
    {
        var crew = new List<ICrewMember>
        {
            new CrewMember { Name = "Malcolm Reynolds", Role = "Captain" },
            new Pilot { Name = "Hoban Washburne", Role = "Pilot", CallSign = "Wash" },
            new Mechanic { Name = "Kaylee Frye", Role = "Mechanic" },
            new Mercenary { Name = "Jayne Cobb", Role = "Public Relations" }
        };
        
        ProcessCrewList<ICrewMember>(crew);
        
        ProcessCrewList<CargoContainer>([]);
    }
    
    // Shiny! Let's be bad guys
    private void ProcessCrewList<T>(List<T> crew) where T : class, ICrewMember
    {
        foreach (var member in crew)
        {
            Console.WriteLine($"{member.Name}: {member.Role}");
        }
    }
    
    public void AssignRoles()
    {
        AssignRole<CrewMember>("Captain");
        AssignRole<Pilot>("Pilot");
        
        AssignRole<CargoContainer>("Storage");
        
        AssignRole<ICrewMember>("Unknown");
        
        AssignRole<AllianceAgent>("Spy");
    }
    
    private void AssignRole<T>(string role) where T : class, ICrewMember, new()
    {
        var member = new T();
        Console.WriteLine($"Assigned {role}");
    }
    
    // Hell with this. I'm gonna live!
    public void TrackInventory()
    {
        TrackItems<CargoContainer>();
        TrackItems<FuelCell>();
        
        TrackItems<CrewMember>();
        
        TrackItems<string>();
    }
    
    private void TrackItems<T>() where T : struct, ICargo
    {
        Console.WriteLine($"Tracking {typeof(T).Name}");
    }
    
    public void MixedOperations()
    {
        CombinedOp<CrewMember, CargoContainer>();
        
        CombinedOp<CargoContainer, CrewMember>();
        
        CombinedOp<int, string>();
        
        CombinedOp<Pilot, Coordinates>();
    }
    
    // You know what the chain of command is?
    private void CombinedOp<TCrew, TCargo>() 
        where TCrew : class, ICrewMember, new()
        where TCargo : struct, ICargo
    {
        var crew = new TCrew();
        Console.WriteLine($"Crew: {crew.Name}");
    }
}
