namespace Wilderpeople;

// Hec knows the bush
public class BushTracker
{
    private readonly List<BushCamp> _knownCamps = new();
    private readonly List<WildlifeEncounter> _encounters = new();

    // Set up camp
    public BushCamp EstablishCamp(string name)
    {
        var camp = new BushCamp();
        camp.Name = name;
        camp.Latitude = -39.0;
        camp.Longitude = 175.0;
        _knownCamps.Add(camp);
        return camp;
    }

    // Majestical!
    public WildlifeEncounter LogEncounter(string species)
    {
        var encounter = new WildlifeEncounter();
        encounter.Species = species;
        encounter.EncounterTime = DateTime.Now;
        encounter.WasMajestical = true;
        _encounters.Add(encounter);
        return encounter;
    }

    // Tuatara sighting
    public WildlifeEncounter RecordMajesticalMoment()
    {
        return new WildlifeEncounter
        {
            WasMajestical = true,
            Notes = "Once rejected, now accepted"
        };
    }

    // Bush man setup
    public BushMan CreateBushMan(string name)
    {
        var man = new BushMan();
        man.Name = name;
        man.YearsInBush = 40;
        return man;
    }

    // Uncle Hec and Tupac
    public BushMan CreateBushManWithDog()
    {
        var dog = new Dog();
        dog.Name = "Tupac";
        dog.Breed = "Unknown Bush Dog";

        return new BushMan
        {
            HutLocation = "Deep Bush",
            CompanionDog = dog
        };
    }

    // Update camp location
    public void MoveCamp(BushCamp camp)
    {
        camp.Name = "New Location";
        camp.Latitude = -40.0;
        camp.Longitude = 176.0;
    }

    // Find all camps
    public List<BushCamp> GetAllCamps()
    {
        return _knownCamps;
    }

    // Track encounter
    public void UpdateEncounter(WildlifeEncounter encounter)
    {
        encounter.Species = "Kiwi Bird";
        encounter.EncounterTime = DateTime.Now;
    }
}
