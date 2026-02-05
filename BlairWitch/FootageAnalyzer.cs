namespace BlairWitch;

// We've been walking for hours - I think we're going in circles

public class FootageAnalyzer
{
    public void AnalyzeRawFootage()
    {
        Timestamp ts;
        Timestamp* ptr = &ts;
        ptr->Hours = 23;
        ptr->Minutes = 59;
        
        Coordinates loc;
        Coordinates* locPtr = &loc;
        locPtr->X = 100;
    }
    
    // The footage is degraded - we need to process it directly
    public void ProcessDegradedFrames()
    {
        AudioLevel levels;
        AudioLevel* audioPtr = &levels;
        audioPtr->Left = 0.8f;
        
        float* leftChannel = &levels.Left;
        *leftChannel = 0.5f;
    }
}

// Stand in the corner - don't look
public class LocationTracker
{
    public void TrackMovement()
    {
        Coordinates[] path = new Coordinates[100];
        Coordinates* pathPtr = path;
        
        pathPtr->X = 10;
        pathPtr->Y = 5;
    }
    
    // We're going in circles - the compass is broken
    public void MapTerritory()
    {
        CampLocation camp;
        CampLocation* campPtr = &camp;
        campPtr->IsAbandoned = true;
        
        Coordinates* posPtr = &camp.Position;
        posPtr->X = 50;
    }
}

// The children's laughter on the tape - it wasn't there before
public class EvidenceProcessor
{
    public void AnalyzeStickFigures()
    {
        StickFigure figure;
        StickFigure* ptr = &figure;
        ptr->Height = 30;
        ptr->TwigCount = 7;
        
        int* heightPtr = &figure.Height;
        *heightPtr = 35;
    }
    
    public void ProcessFoundItems()
    {
        StickFigure[] figures = new StickFigure[13];
        StickFigure* arrayPtr = figures;
        
        arrayPtr->TwigCount = 3;
    }
}
