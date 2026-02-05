namespace Upload;

// Welcome to Lakeview - your digital afterlife awaits

public class UploadedConsciousness
{
    public string Name { get; set; } = "";
    public string Plan { get; set; } = "2Gig";
    public double DataUsageGB { get; set; }
    public bool IsActive { get; set; }
}

public class LakeviewResident
{
    public string ResidentId { get; set; } = "";
    public UploadedConsciousness Consciousness { get; set; } = new();
    public DateTime UploadDate { get; set; }
    public string Suite { get; set; } = "";
}

public class HorizonResident
{
    public string ResidentId { get; set; } = "";
    public UploadedConsciousness Consciousness { get; set; } = new();
    public int DailyMinutesAllowed { get; set; } = 120;
}

public class Angel
{
    public string Name { get; set; } = "";
    public string Department { get; set; } = "Customer Service";
    public List<string> AssignedResidents { get; set; } = [];
}

public class MemoryBackup
{
    public string BackupId { get; set; } = "";
    public byte[] Data { get; set; } = [];
    public DateTime Timestamp { get; set; }
    public long SizeBytes { get; set; }
}

public class InAppPurchase
{
    public string ItemId { get; set; } = "";
    public string ItemName { get; set; } = "";
    public decimal Price { get; set; }
    public bool RequiresLivingApproval { get; set; }
}
