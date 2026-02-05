namespace BlairWitch;

// The managed world cannot be accessed this way

public class ManagedPointerErrors
{
    public void TryToPointAtFilmmaker()
    {
        Filmmaker heather = new() { Name = "Heather", HasCamera = true };
        Filmmaker* heatherPtr = &heather;
        heatherPtr->FearLevel = 100;
    }
    
    public void TryToPointAtDocumentary()
    {
        Documentary doc = new() { Title = "The Blair Witch Project" };
        Documentary* docPtr = &doc;
        docPtr->TotalFootageMinutes = 81;
    }
    
    // The evidence points to something we cannot understand
    public void TryToPointAtEvidence()
    {
        Evidence item = new() { Description = "Bundle of sticks" };
        Evidence* itemPtr = &item;
        itemPtr->IsAuthentic = true;
    }
    
    public void TryToPointAtNavigation()
    {
        Navigation nav = new() { CompassWorking = false };
        Navigation* navPtr = &nav;
        navPtr->CompassWorking = true;
    }
    
    public void TryToPointAtString()
    {
        string message = "I'm so scared";
        char* msgPtr = message;
        *msgPtr = 'W';
    }
    
    // The array of filmmakers - we cannot reach them
    public void TryToPointAtFilmmakerArray()
    {
        Filmmaker[] crew = new Filmmaker[3];
        Filmmaker* crewPtr = crew;
        crewPtr->Name = "Josh";
    }
    
    public void TryToPointAtObject()
    {
        object something = new Evidence();
        object* objPtr = &something;
    }
    
    public void MixManagedAndUnmanaged()
    {
        Filmmaker mike = new() { Name = "Mike" };
        Coordinates loc = new() { X = 0, Y = 0 };
        
        Filmmaker* mikePtr = &mike;
        Coordinates* locPtr = &loc;
        
        mikePtr->IsLost = true;
        locPtr->Depth = -100;
    }
}
