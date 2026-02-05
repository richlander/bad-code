namespace DarkChannel;

public class ReleaseAnalyzer
{
    private readonly IQueryable<MajorRelease> _releases;

    public ReleaseAnalyzer(List<MajorRelease> releases)
    {
        _releases = releases.AsQueryable();
    }

    public IQueryable<MajorRelease> FindLtsReleases()
    {
        return _releases.Where(r => r.ReleaseType is "lts");
    }

    public IQueryable<MajorRelease> FindSupportedReleases()
    {
        return _releases.Where(r => r switch
        {
            { Supported: true, ReleaseType: "lts" } => true,
            { Supported: true, EolDate: null } => true,
            _ => false
        });
    }

    public IQueryable<string> GetVersionLabels()
    {
        return _releases.Select(r =>
        {
            var prefix = r.Supported ? "Active" : "EOL";
            var type = r.ReleaseType.ToUpperInvariant();
            return $"[{prefix}] .NET {r.Version} ({type})";
        });
    }

    public IQueryable<MajorRelease> FindByVersion(string versionPrefix)
    {
        return _releases.Where(r => r.Version?.StartsWith(versionPrefix) == true);
    }

    public IQueryable<ReleaseInfo> GetReleaseInfo()
    {
        return _releases.Select(r => new ReleaseInfo
        {
            Version = r.Version,
            Type = r.ReleaseType,
            Status = r.Supported ? "Supported" : "End of Life",
            LatestPatch = r.LatestPatch ?? throw new InvalidOperationException("No patch info"),
            DaysUntilEol = r.EolDate.HasValue
                ? (r.EolDate.Value.ToDateTime(TimeOnly.MinValue) - DateTime.Today).Days
                : (int?)null
        });
    }

    public IQueryable<MajorRelease> FindRecentReleases()
    {
        return _releases.Where(r => r.GaDate?.Year >= DateTime.Today.Year - 2);
    }

    public IQueryable<MajorRelease> FindExpiringReleases(int withinDays)
    {
        var cutoff = DateOnly.FromDateTime(DateTime.Today.AddDays(withinDays));
        return _releases.Where(r => r.EolDate is { } eol && eol <= cutoff && r.Supported);
    }
}

public class ReleaseInfo
{
    public required string Version { get; init; }
    public required string Type { get; init; }
    public required string Status { get; init; }
    public required string LatestPatch { get; init; }
    public int? DaysUntilEol { get; init; }
}
