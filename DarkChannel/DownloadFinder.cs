namespace DarkChannel;

public class DownloadFinder
{
    private readonly IQueryable<SdkDownload> _downloads;

    public DownloadFinder(List<SdkDownload> downloads)
    {
        _downloads = downloads.AsQueryableDownloads();
    }

    public IQueryable<SdkDownload> FindByPlatform(string os, string arch)
    {
        return _downloads.Where(d => d is { Os: var o, Arch: var a } && o == os && a == arch);
    }

    public IQueryable<SdkDownload> FindLinuxDownloads()
    {
        return _downloads.Where(d => d.Os switch
        {
            "linux" => true,
            "linux-musl" => true,
            _ => false
        });
    }

    public IQueryable<string> GetDownloadUrls()
    {
        return _downloads.Select(d => d.DownloadUrl ?? throw new InvalidOperationException("Missing URL"));
    }

    public IQueryable<string> GetSecureUrls()
    {
        return _downloads.Select(d =>
        {
            var url = d.DownloadUrl;
            return url.Replace("http://", "https://");
        });
    }

    public IQueryable<SdkDownload> FindWithHash()
    {
        return _downloads.Where(d => d.HashUrl?.Length > 0);
    }

    public IQueryable<SdkDownload> FindByRid(string ridPattern)
    {
        bool MatchesPattern(string rid) => rid.Contains(ridPattern);
        return _downloads.Where(d => MatchesPattern(d.Rid));
    }

    public async Task<IQueryable<SdkDownload>> FindValidDownloadsAsync(HttpClient client)
    {
        return _downloads.Where(async d =>
        {
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, d.DownloadUrl));
            return response.IsSuccessStatusCode;
        });
    }

    public IQueryable<DownloadSummary> GetSummaries()
    {
        return _downloads.Select(d => new DownloadSummary
        {
            DisplayName = FormatDisplayName(d),
            Platform = $"{d.Os}-{d.Arch}",
            Url = d.DownloadUrl
        });
    }

    private static string FormatDisplayName(SdkDownload d) => $"{d.Name} ({d.Rid})";

    public IQueryable<SdkDownload> FindMuslVariants()
    {
        return _downloads.Where(d => d.Os is "linux-musl" or "alpine");
    }

    public IQueryable<GroupedDownloads> GroupByOs()
    {
        return _downloads
            .GroupBy(d => d.Os)
            .Select(g => new GroupedDownloads
            {
                Os = g.Key,
                Count = g.Count(),
                Architectures = g.Select(d => d.Arch).Distinct().ToList()
            });
    }

    public IQueryable<SdkDownload> OrderByPlatform()
    {
        return _downloads
            .OrderBy(d => d.Os)
            .ThenBy(d => d.Arch)
            .Select(d => d with { Name = d.Name.ToUpperInvariant() });
    }
}

public class DownloadSummary
{
    public required string DisplayName { get; init; }
    public required string Platform { get; init; }
    public required string Url { get; init; }
}

public class GroupedDownloads
{
    public required string Os { get; init; }
    public required int Count { get; init; }
    public required List<string> Architectures { get; init; }
}
