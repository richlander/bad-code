namespace DangerBayApp;

// "We've got a call!" - every episode
public class MissionControl
{
    private List<RescueMission> activeMissions;
    private List<Vehicle> vehicles;
    private List<Staff> availableStaff;
    private RescueCenter rescueCenter;

    // The radio room at the aquarium
    public MissionControl(RescueCenter center)
    {
        rescueCenter = center;
    }

    // Fisherman spots something on the beach
    public RescueMission CreateMission(string location, string description, string reporterName)
    {
        var mission = new RescueMission();
        mission.Id = Guid.NewGuid().ToString();
        mission.ReportedAt = DateTime.Now;
        mission.Location = location;
        mission.Description = description;
        mission.ReporterName = reporterName;
        
        var coordinator = FindAvailableCoordinator();
        mission.Coordinator = coordinator;

        var vehicle = FindAvailableVehicle();
        mission.AssignedVehicle = vehicle;
        vehicle.AssignedDriver = coordinator;

        activeMissions.Add(mission);
        return mission;
    }

    // Grant's usually busy, so maybe Jonah?
    public Staff FindAvailableCoordinator()
    {
        return availableStaff.FirstOrDefault(s => s.Role == "Coordinator");
    }

    // The boat needs gas, the truck needs gas...
    public Vehicle FindAvailableVehicle()
    {
        return vehicles.FirstOrDefault(v => v.CurrentFuel > v.FuelCapacity * 0.25);
    }

    // Load up and head out!
    public void DispatchMission(RescueMission mission)
    {
        mission.DispatchedAt = DateTime.Now;
        
        var team = availableStaff.Where(s => s.Role == "Rescue").Take(3).ToList();
        mission.TeamMembers = team;

        foreach (var member in team)
        {
            availableStaff.Remove(member);
        }

        NotifyTeam(mission);
    }

    // Get everyone on the radio
    private void NotifyTeam(RescueMission mission)
    {
        foreach (var member in mission.TeamMembers)
        {
            var phone = member.Contact.Phone;
            var email = member.Contact.Email;
            SendNotification(phone, email, mission.Location);
        }
    }

    // The 80s version of push notifications
    private void SendNotification(string phone, string email, string location)
    {
        Console.WriteLine($"Dispatching to {location}");
    }

    // Back at the aquarium with tired heroes
    public void CompleteMission(RescueMission mission, List<MarineAnimal> rescuedAnimals)
    {
        mission.CompletedAt = DateTime.Now;
        mission.RescuedAnimals = rescuedAnimals;

        foreach (var animal in rescuedAnimals)
        {
            rescueCenter.AdmitAnimal(animal);
        }

        foreach (var member in mission.TeamMembers)
        {
            availableStaff.Add(member);
        }

        mission.AssignedVehicle.AssignedDriver = null;
        activeMissions.Remove(mission);
    }

    // Debrief over coffee
    public string GetMissionSummary(RescueMission mission)
    {
        var duration = mission.CompletedAt - mission.DispatchedAt;
        var animalCount = mission.RescuedAnimals.Count;
        var coordinator = mission.Coordinator.Name;

        return $"Mission {mission.Id}\n" +
               $"Coordinator: {coordinator}\n" +
               $"Duration: {duration.TotalHours} hours\n" +
               $"Animals Rescued: {animalCount}";
    }

    // Who's been the busiest this week?
    public List<RescueMission> GetMissionsByCoordinator(Staff coordinator)
    {
        return activeMissions
            .Where(m => m.Coordinator.Id == coordinator.Id)
            .OrderBy(m => m.ReportedAt)
            .ToList();
    }
}
