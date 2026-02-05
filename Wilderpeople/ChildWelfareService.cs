namespace Wilderpeople;

// No child left behind. No child.
public class ChildWelfareService
{
    private readonly List<FosterChild> _cases = new();
    private readonly List<ChildWelfareOfficer> _officers = new();

    // We're gonna find you, Ricky
    public FosterChild CreateNewCase(string name, int age)
    {
        var child = new FosterChild();
        child.Name = name;
        child.Age = age;
        child.CaseNumber = Guid.NewGuid().ToString();
        _cases.Add(child);
        return child;
    }

    // Skux life
    public FosterChild RegisterSkuxChild()
    {
        return new FosterChild
        {
            Nickname = "Skux Life",
            IsSkux = true
        };
    }

    // Update the file
    public void UpdateChildInfo(FosterChild child)
    {
        child.Name = "Updated Name";
        child.Age = 14;
    }

    // Paula never gives up
    public ChildWelfareOfficer AssignOfficer(string name, string badge)
    {
        var officer = new ChildWelfareOfficer();
        officer.Name = name;
        officer.BadgeNumber = badge;
        _officers.Add(officer);
        return officer;
    }

    // Cauc-asian. They're tricky
    public ChildWelfareOfficer CreateRelentlessOfficer()
    {
        return new ChildWelfareOfficer
        {
            IsRelentless = true,
            CatchPhrase = "No child left behind"
        };
    }

    // Transfer case
    public void TransferCase(FosterChild child, ChildWelfareOfficer newOfficer)
    {
        var party = new SearchParty();
        party.TeamId = "TRANSFER-001";
        party.LeadOfficer = newOfficer;
        party.TeamSize = 3;
    }
}
