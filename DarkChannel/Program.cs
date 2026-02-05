using DarkChannel;

var dataSource = new SdkDataSource();

Console.WriteLine("Fetching .NET SDK download information...\n");

var downloads = await dataSource.GetAllDownloadsAsync();
var releases = await dataSource.GetReleasesAsync();

var downloadFinder = new DownloadFinder(downloads);
var releaseAnalyzer = new ReleaseAnalyzer(releases);

Console.WriteLine($"Found {downloads.Count} SDK downloads across {releases.Count} releases\n");

Console.WriteLine("=== Linux x64 Downloads ===");
foreach (var dl in downloadFinder.FindByPlatform("linux", "x64"))
{
    Console.WriteLine($"  {dl.Name}: {dl.DownloadUrl}");
}

Console.WriteLine("\n=== All Linux Variants ===");
foreach (var dl in downloadFinder.FindLinuxDownloads())
{
    Console.WriteLine($"  {dl.Rid}: {dl.Name}");
}

Console.WriteLine("\n=== LTS Releases ===");
foreach (var r in releaseAnalyzer.FindLtsReleases())
{
    Console.WriteLine($"  .NET {r.Version} ({(r.Supported ? "Supported" : "EOL")})");
}

Console.WriteLine("\n=== Downloads by OS ===");
foreach (var group in downloadFinder.GroupByOs())
{
    Console.WriteLine($"  {group.Os}: {group.Count} downloads ({string.Join(", ", group.Architectures)})");
}

Console.WriteLine("\n=== Download URLs ===");
foreach (var url in downloadFinder.GetDownloadUrls().Take(5))
{
    Console.WriteLine($"  {url}");
}

Console.WriteLine("\nDone.");
