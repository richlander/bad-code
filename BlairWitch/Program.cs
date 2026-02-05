namespace BlairWitch;

// In October of 1994 three student filmmakers disappeared
// in the woods near Burkittsville, Maryland while shooting a documentary.
// A year later their footage was found.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Blair Witch Project - Footage Analysis System");
        Console.WriteLine("=============================================");
        
        var analyzer = new FootageAnalyzer();
        analyzer.AnalyzeRawFootage();
        analyzer.ProcessDegradedFrames();
        
        var tracker = new LocationTracker();
        tracker.TrackMovement();
        tracker.MapTerritory();
        
        var evidence = new EvidenceProcessor();
        evidence.AnalyzeStickFigures();
        evidence.ProcessFoundItems();
        
        var house = new HouseExplorer();
        house.MapRooms();
        house.AnalyzeHandprints();
        house.DescendStairs();
        house.ExamineCorner();
        
        var recovery = new TapeRecovery();
        recovery.RecoverCorruptedData();
        recovery.ExtractHiddenAudio();
        
        var managed = new ManagedPointerErrors();
        var sizes = new SizeOfErrors();
        var buffers = new FixedBufferErrors();
        
        Console.WriteLine();
        Console.WriteLine("I'm so sorry. I'm so sorry.");
    }
}
