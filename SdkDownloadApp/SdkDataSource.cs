using System.Text.Json;

namespace SdkDownloadApp;

public class SdkDataSource
{
    private static readonly HttpClient HttpClient = new();
    private const string BaseUrl = "https://raw.githubusercontent.com/dotnet/core/release-index/release-notes";

    public async Task<List<SdkDownload>> GetAllDownloadsAsync()
    {
        var downloads = new List<SdkDownload>();

        var indexJson = await HttpClient.GetStringAsync($"{BaseUrl}/index.json");
        var index = JsonDocument.Parse(indexJson);

        var releases = index.RootElement
            .GetProperty("_embedded")
            .GetProperty("releases")
            .EnumerateArray();

        foreach (var release in releases)
        {
            var version = release.GetProperty("version").GetString()!;
            var supported = release.GetProperty("supported").GetBoolean();

            if (!supported) continue;

            try
            {
                var sdkUrl = $"{BaseUrl}/{version}/downloads/sdk.json";
                var sdkJson = await HttpClient.GetStringAsync(sdkUrl);
                var sdkDoc = JsonDocument.Parse(sdkJson);

                var downloadElements = sdkDoc.RootElement
                    .GetProperty("_embedded")
                    .GetProperty("downloads")
                    .EnumerateObject();

                foreach (var dl in downloadElements)
                {
                    var props = dl.Value;
                    downloads.Add(new SdkDownload(
                        Name: props.GetProperty("name").GetString()!,
                        Rid: props.GetProperty("rid").GetString()!,
                        Os: props.GetProperty("os").GetString()!,
                        Arch: props.GetProperty("arch").GetString()!,
                        HashAlgorithm: props.GetProperty("hash_algorithm").GetString()!,
                        DownloadUrl: props.GetProperty("_links").GetProperty("download").GetProperty("href").GetString()!,
                        HashUrl: props.TryGetProperty("_links", out var links) && links.TryGetProperty("hash", out var hash)
                            ? hash.GetProperty("href").GetString()
                            : null,
                        FileSize: null
                    ));
                }
            }
            catch (HttpRequestException)
            {
            }
        }

        return downloads;
    }

    public async Task<List<MajorRelease>> GetReleasesAsync()
    {
        var releases = new List<MajorRelease>();

        var indexJson = await HttpClient.GetStringAsync($"{BaseUrl}/index.json");
        var index = JsonDocument.Parse(indexJson);

        var releaseElements = index.RootElement
            .GetProperty("_embedded")
            .GetProperty("releases")
            .EnumerateArray();

        foreach (var rel in releaseElements)
        {
            releases.Add(new MajorRelease(
                Version: rel.GetProperty("version").GetString()!,
                ReleaseType: rel.GetProperty("release_type").GetString()!,
                Supported: rel.GetProperty("supported").GetBoolean(),
                LatestPatch: null,
                GaDate: null,
                EolDate: null,
                Patches: null
            ));
        }

        return releases;
    }
}
