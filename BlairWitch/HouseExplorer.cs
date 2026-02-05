namespace BlairWitch;

// We found a house - Heather's camera was still running

public class HouseExplorer
{
    public void MapRooms()
    {
        Coordinates[] rooms = new Coordinates[20];
        Coordinates* roomPtr = rooms;
        
        Coordinates* basement = roomPtr + 19;
        basement->Depth = -10;
        
        Coordinates* corner = roomPtr + 15;
        corner->X = 0;
    }
    
    // The handprints on the wall - small, like children's
    public void AnalyzeHandprints()
    {
        int[] printSizes = new int[50];
        int* sizePtr = printSizes;
        
        int* smallest = sizePtr;
        int* largest = sizePtr + 49;
        *smallest = 5;
        *largest = 8;
    }
    
    // The basement stairs - someone was standing there
    public void DescendStairs()
    {
        int[] steps = new int[13];
        int* stepPtr = steps;
        
        int* topStep = stepPtr;
        int* bottomStep = stepPtr + 12;
        
        *topStep = 100;
        *bottomStep = 0;
    }
    
    public void ExamineCorner()
    {
        Coordinates corner = new() { X = 0, Y = 0, Depth = -20 };
        Coordinates* cornerPtr = &corner;
        
        int* depth = &corner.Depth;
        *depth = -100;
    }
}

// The tapes were found a year later
public class TapeRecovery
{
    public void RecoverCorruptedData()
    {
        byte[] tapeData = new byte[4096];
        byte* dataPtr = tapeData;
        
        byte* header = dataPtr;
        byte* footer = dataPtr + 4000;
        
        *header = 0xFF;
        *footer = 0x00;
    }
    
    // The audio track had voices we didn't record
    public void ExtractHiddenAudio()
    {
        float[] waveform = new float[44100];
        float* wavePtr = waveform;
        
        *wavePtr = 0.0f;
        *(wavePtr + 22050) = 1.0f;
    }
}
