namespace DangerBay;

// Where the seals, otters, and orcas live
public class HabitatManager
{
    private List<Habitat> habitats;
    private List<Staff> keepers;

    public HabitatManager()
    {
        // Forgot to initialize keepers, classic Jonah move
        habitats = new List<Habitat>();
    }

    // Nicole with her chemistry set
    public void PerformWaterTest(Habitat habitat, Staff tester)
    {
        var test = new WaterQuality();
        test.TestDate = DateTime.Now;
        test.TestedBy = tester.Name;
        test.Temperature = Random.Shared.NextDouble() * 10 + 10;
        test.Salinity = Random.Shared.NextDouble() * 5 + 30;
        test.Ph = Random.Shared.NextDouble() * 2 + 7;
        test.DissolvedOxygen = Random.Shared.NextDouble() * 5 + 5;

        habitat.LastWaterTest = test;

        if (test.Ph < 7.5 || test.Ph > 8.5)
        {
            AlertKeeper(habitat.AssignedKeeper, habitat.Name, "pH out of range");
        }
    }

    // Page them on the intercom
    private void AlertKeeper(Staff keeper, string habitatName, string issue)
    {
        var phone = keeper.Contact.EmergencyPhone;
        Console.WriteLine($"ALERT: {habitatName} - {issue}. Notifying {keeper.Name} at {phone}");
    }

    // New assignment board
    public void AssignKeeper(Habitat habitat, Staff keeper)
    {
        var previousKeeper = habitat.AssignedKeeper;
        if (previousKeeper.AssignedHabitats != null)
        {
            previousKeeper.AssignedHabitats.Remove(habitat);
        }

        habitat.AssignedKeeper = keeper;
        keeper.AssignedHabitats.Add(habitat);
    }

    // Morning rounds report
    public string GetHabitatStatus(Habitat habitat)
    {
        var lastTest = habitat.LastWaterTest;
        var keeper = habitat.AssignedKeeper;
        var residentCount = habitat.Residents.Count;

        var tempStatus = lastTest.Temperature > 15 ? "Warm" : "Cool";
        var keeperName = keeper.Name;

        return $"{habitat.Name}\n" +
               $"Keeper: {keeperName}\n" +
               $"Residents: {residentCount}\n" +
               $"Temperature: {tempStatus} ({lastTest.Temperature:F1}°C)\n" +
               $"Last Test: {lastTest.TestDate}";
    }

    // Grant's worry list
    public List<Habitat> GetHabitatsNeedingAttention()
    {
        var needsAttention = new List<Habitat>();

        foreach (var habitat in habitats)
        {
            var daysSinceTest = (DateTime.Now - habitat.LastWaterTest.TestDate).Days;
            if (daysSinceTest > 7)
            {
                needsAttention.Add(habitat);
            }

            if (habitat.CurrentOccupancy > habitat.Capacity * 0.9)
            {
                needsAttention.Add(habitat);
            }
        }

        return needsAttention.Distinct().ToList();
    }

    // "We need the tidal pool for this one"
    public Habitat FindHabitatByType(HabitatType type)
    {
        return habitats.FirstOrDefault(h => h.Type == type);
    }

    // Big renovation day
    public void MoveResidents(Habitat from, Habitat to)
    {
        foreach (var animal in from.Residents)
        {
            animal.CurrentHabitat = to;
            to.Residents.Add(animal);
        }
        from.Residents.Clear();
        from.CurrentOccupancy = 0;
        to.CurrentOccupancy = to.Residents.Count;
    }

    // Stats for the grant application
    public Dictionary<HabitatType, int> GetOccupancyByType()
    {
        var occupancy = new Dictionary<HabitatType, int>();
        
        foreach (var habitat in habitats)
        {
            var type = habitat.Type;
            var count = habitat.Residents.Count;
            
            if (occupancy.ContainsKey(type))
            {
                occupancy[type] += count;
            }
            else
            {
                occupancy[type] = count;
            }
        }

        return occupancy;
    }
}
