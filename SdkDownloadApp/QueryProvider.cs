using System.Collections;
using System.Linq.Expressions;

namespace SdkDownloadApp;

public class DownloadQueryProvider : IQueryProvider
{
    private readonly List<SdkDownload> _downloads;

    public DownloadQueryProvider(List<SdkDownload> downloads)
    {
        _downloads = downloads;
    }

    public IQueryable CreateQuery(Expression expression)
    {
        return new DownloadQuery<SdkDownload>(this, expression);
    }

    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        return new DownloadQuery<TElement>(this, expression);
    }

    public object? Execute(Expression expression)
    {
        return Execute<object>(expression);
    }

    public TResult Execute<TResult>(Expression expression)
    {
        var compiled = Expression.Lambda<Func<IEnumerable<SdkDownload>, TResult>>(
            expression,
            Expression.Parameter(typeof(IEnumerable<SdkDownload>), "downloads")
        );
        return compiled.Compile()(_downloads);
    }
}

public class DownloadQuery<T> : IQueryable<T>, IOrderedQueryable<T>
{
    public DownloadQuery(DownloadQueryProvider provider, Expression expression)
    {
        Provider = provider;
        Expression = expression;
    }

    public DownloadQuery(DownloadQueryProvider provider, IEnumerable<T> source)
    {
        Provider = provider;
        Expression = Expression.Constant(source.AsQueryable());
    }

    public Type ElementType => typeof(T);
    public Expression Expression { get; }
    public IQueryProvider Provider { get; }

    public IEnumerator<T> GetEnumerator()
    {
        return Provider.Execute<IEnumerable<T>>(Expression).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public static class DownloadQueryExtensions
{
    public static IQueryable<SdkDownload> AsQueryableDownloads(this List<SdkDownload> downloads)
    {
        var provider = new DownloadQueryProvider(downloads);
        return new DownloadQuery<SdkDownload>(provider, downloads);
    }
}
