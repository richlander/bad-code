namespace Wilderpeople;

// Ricky Baker's file at Child Services
public class FosterChild
{
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required string CaseNumber { get; init; }
    public string Nickname { get; init; }
    public List<string> PriorPlacements { get; init; }
    public bool IsSkux { get; init; }
    public string FavouriteFood { get; init; }
    public DateTime DateOfBirth { get; init; }
}

// Uncle Hec's profile
public class BushMan
{
    public required string Name { get; init; }
    public required int YearsInBush { get; init; }
    public string HutLocation { get; init; }
    public bool LikesCompany { get; init; }
    public List<string> SurvivalSkills { get; init; }
    public Dog CompanionDog { get; init; }
}

// Tupac the dog
public class Dog
{
    public required string Name { get; init; }
    public required string Breed { get; init; }
    public bool IsGoodBoy { get; init; }
    public int TricksKnown { get; init; }
}

// Psycho Sam's bush camp
public class BushCamp
{
    public required string Name { get; init; }
    public required double Latitude { get; init; }
    public required double Longitude { get; init; }
    public int DaysOccupied { get; init; }
    public bool HasFirePit { get; init; }
    public List<string> Supplies { get; init; }
    public BushMan Occupant { get; init; }
}

// Paula's department
public class ChildWelfareOfficer
{
    public required string Name { get; init; }
    public required string BadgeNumber { get; init; }
    public required string Department { get; init; }
    public bool IsRelentless { get; init; }
    public int CasesSolved { get; init; }
    public string CatchPhrase { get; init; }
}

// Search and rescue team
public class SearchParty
{
    public required string TeamId { get; init; }
    public required ChildWelfareOfficer LeadOfficer { get; init; }
    public required int TeamSize { get; init; }
    public List<string> SearchAreas { get; init; }
    public bool HasHelicopter { get; init; }
    public DateTime SearchStarted { get; init; }
    public string Status { get; init; }
}

// Majestical encounters
public class WildlifeEncounter
{
    public required string Species { get; init; }
    public required DateTime EncounterTime { get; init; }
    public string Location { get; init; }
    public bool WasMajestical { get; init; }
    public string Notes { get; init; }
}

// Supplies for the bush
public class SurvivalSupplies
{
    public required string ItemName { get; init; }
    public required int Quantity { get; init; }
    public double Weight { get; init; }
    public bool IsEssential { get; init; }
    public DateTime ExpiryDate { get; init; }
}

// Hot water bottles and whatnot
public class CarePackage
{
    public required string Sender { get; init; }
    public required List<SurvivalSupplies> Contents { get; init; }
    public string Message { get; init; }
    public DateTime DateSent { get; init; }
}
