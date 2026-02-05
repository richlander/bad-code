namespace Browncoat;

// Serenity - she's torn up plenty, but she'll fly true

public class SerenityOps
{
    public void ManageCrew()
    {
        var registry = new ShipRegistry<CrewMember>();
        registry.AddCrew(new CrewMember { Name = "Mal", Role = "Captain" });
        
        var pilotRegistry = new ShipRegistry<Pilot>();
        pilotRegistry.AddCrew(new Pilot { Name = "Wash", CallSign = "Hoban" });
        
        var structRegistry = new ShipRegistry<CargoContainer>();
        
        var interfaceRegistry = new ShipRegistry<ICrewMember>();
        
        var sealedRegistry = new ShipRegistry<AllianceAgent>();
    }
    
    public void HandleCargo()
    {
        var hold = new CargoHold<CargoContainer>();
        hold.LoadCargo(new CargoContainer { Manifest = "Medical supplies", Value = 1000m });
        
        var crewHold = new CargoHold<CrewMember>();
        
        var fuelHold = new CargoHold<FuelCell>();
        
        var coordHold = new CargoHold<Coordinates>();
    }
    
    // Were I unwed, I would take you in a manly fashion
    public void PrepareWeapons()
    {
        var locker = new WeaponsLocker<Mercenary>();
        locker.Store(new Mercenary { Name = "Jayne", PreferredGun = "Vera" });
        
        var structLocker = new WeaponsLocker<CargoContainer>();
        
        var crewLocker = new WeaponsLocker<CrewMember>();
    }
    
    public void Navigate()
    {
        var nav = new NavigationSystem<Coordinates>();
        nav.PlotCourse(new Coordinates { X = 100, Y = 200, Z = 50 });
        
        var classNav = new NavigationSystem<CrewMember>();
        
        var stringNav = new NavigationSystem<string>();
    }
    
    // If you can't do something smart, do something right
    public void PlanMissions()
    {
        var planner = new MissionPlanner<SmugglingRun>();
        planner.AcceptMission(new SmugglingRun { Destination = "Persephone" });
        
        var abstractPlanner = new MissionPlanner<Mission>();
        
        var crewPlanner = new MissionPlanner<CrewMember>();
    }
    
    public void TrackThreats()
    {
        var tracker = new ThreatTracker<AllianceAgent>();
        tracker.Track(new AllianceAgent { AgentId = "Blue-1" });
        
        var reaverTracker = new ThreatTracker<Reaver>();
        reaverTracker.Track(new Reaver { Territory = "Miranda" });
        
        var structTracker = new ThreatTracker<CargoContainer>();
        
        var intTracker = new ThreatTracker<int>();
    }
    
    public void ManageFuel()
    {
        var fuelMgr = new FuelManager<FuelCell>();
        fuelMgr.SetReserves(new FuelCell { Capacity = 1000, CurrentLevel = 750 });
        
        var classFuel = new FuelManager<CrewMember>();
        
        var stringFuel = new FuelManager<string>();
    }
}
