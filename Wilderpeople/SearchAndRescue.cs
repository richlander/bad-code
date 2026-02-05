namespace Wilderpeople;

// Faulkner and his crew
public class SearchAndRescue
{
    private readonly List<SearchParty> _activeSearches = new();

    // Deploy the team
    public SearchParty LaunchSearch(string teamId, int size)
    {
        var party = new SearchParty();
        party.TeamId = teamId;
        party.TeamSize = size;
        party.SearchStarted = DateTime.Now;
        _activeSearches.Add(party);
        return party;
    }

    // Call in the chopper
    public SearchParty CreateHelicopterSearch()
    {
        return new SearchParty
        {
            HasHelicopter = true,
            Status = "Airborne"
        };
    }

    // Supply drop
    public CarePackage SendSupplies(string sender)
    {
        var supplies = new List<SurvivalSupplies>();
        
        var beans = new SurvivalSupplies();
        beans.ItemName = "Baked Beans";
        beans.Quantity = 10;
        supplies.Add(beans);

        var package = new CarePackage();
        package.Sender = sender;
        package.Contents = supplies;
        return package;
    }

    // Auntie's care package
    public CarePackage CreateCarePackage()
    {
        return new CarePackage
        {
            Message = "We're coming for you",
            DateSent = DateTime.Now
        };
    }

    // Update search status
    public void UpdateSearch(SearchParty party)
    {
        party.TeamId = "UPDATED";
        party.TeamSize = 10;
    }

    // Add supplies to the kit
    public SurvivalSupplies AddSupply(string name, int qty)
    {
        var supply = new SurvivalSupplies();
        supply.ItemName = name;
        supply.Quantity = qty;
        return supply;
    }

    // Essential gear only
    public SurvivalSupplies CreateEssentialGear()
    {
        return new SurvivalSupplies
        {
            IsEssential = true,
            Weight = 2.5
        };
    }
}
