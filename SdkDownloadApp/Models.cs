namespace SdkDownloadApp;

public record ReleaseIndex(
    string LatestMajor,
    string LatestLtsMajor,
    IList<MajorRelease> Releases
);

public record MajorRelease(
    string Version,
    string ReleaseType,
    bool Supported,
    string? LatestPatch,
    DateOnly? GaDate,
    DateOnly? EolDate,
    IList<PatchRelease>? Patches
);

public record PatchRelease(
    string Version,
    DateOnly Date,
    bool Security,
    string? SdkVersion,
    IList<string>? CveRecords,
    IList<SdkFeatureBand>? FeatureBands
);

public record SdkFeatureBand(
    string Version,
    string Band,
    DateOnly Date,
    string Label,
    string? SupportPhase
);

public record DownloadIndex(
    string Version,
    IList<ComponentInfo> Components,
    IList<FeatureBandInfo> FeatureBands
);

public record ComponentInfo(
    string Name,
    string Title,
    string Url
);

public record FeatureBandInfo(
    string Version,
    string Title,
    string SupportPhase,
    string Url
);

public record SdkDownload(
    string Name,
    string Rid,
    string Os,
    string Arch,
    string HashAlgorithm,
    string DownloadUrl,
    string? HashUrl,
    long? FileSize
);

public record DownloadResult(
    string Version,
    string Component,
    SdkDownload Download,
    MajorRelease? Release
);
