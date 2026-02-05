namespace Browncoat;

// No power in the verse can stop me

public class VerseCommands
{
    public void RegisterOperations()
    {
        var mal = new CrewMember { Name = "Mal", Role = "Captain" };
        VerseOperations.RegisterCrew(mal);
        
        var wash = new Pilot { Name = "Wash", Role = "Pilot" };
        VerseOperations.RegisterCrew(wash);
        
        var cargo = new CargoContainer { Manifest = "Goods" };
        VerseOperations.RegisterCrew(cargo);
        
        ICrewMember iface = new CrewMember { Name = "Zoe" };
        VerseOperations.RegisterCrew(iface);
        
        var agent = new AllianceAgent { AgentId = "Alpha" };
        VerseOperations.RegisterCrew(agent);
    }
    
    // Dear Buddha, please bring me a pony
    public void StoreOperations()
    {
        var cargo = new CargoContainer { Manifest = "Contraband", Value = 5000m };
        VerseOperations.StoreCargo(cargo);
        
        var crew = new CrewMember { Name = "Kaylee" };
        VerseOperations.StoreCargo(crew);
        
        var fuel = new FuelCell { Capacity = 500 };
        VerseOperations.StoreCargo(fuel);
    }
    
    public void CreateDefaults()
    {
        var crew = VerseOperations.CreateDefault<CrewMember>();
        var pilot = VerseOperations.CreateDefault<Pilot>();
        
        var ifaceCrew = VerseOperations.CreateDefault<ICrewMember>();
        
        var mission = VerseOperations.CreateDefault<Mission>();
    }
    
    // Also, I can kill you with my brain
    public void ProcessValues()
    {
        VerseOperations.ProcessValue(new Coordinates { X = 1, Y = 2, Z = 3 });
        VerseOperations.ProcessValue(new FuelCell { Capacity = 100 });
        VerseOperations.ProcessValue(42);
        
        VerseOperations.ProcessValue(new CrewMember());
        
        VerseOperations.ProcessValue("Serenity");
        
        VerseOperations.ProcessValue(new AllianceAgent());
    }
    
    public void TrackEntities()
    {
        VerseOperations.TrackEntity(new AllianceAgent());
        VerseOperations.TrackEntity(new Reaver());
        
        VerseOperations.TrackEntity(new CargoContainer());
        
        VerseOperations.TrackEntity(42);
        
        VerseOperations.TrackEntity(new Coordinates());
    }
    
    // I'll be in my bunk
    public void ConvertOperations()
    {
        var cargo = new CargoContainer { Manifest = "Weapons" };
        
        var crew = VerseOperations.ConvertCargo<CargoContainer, CrewMember>(cargo);
        
        var pilot = new Pilot();
        VerseOperations.ConvertCargo<Pilot, CrewMember>(pilot);
        
        VerseOperations.ConvertCargo<CargoContainer, CargoContainer>(cargo);
        
        VerseOperations.ConvertCargo<FuelCell, Pilot>(new FuelCell());
    }
}
