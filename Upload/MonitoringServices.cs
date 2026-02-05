using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Upload;

// Monitoring the digital afterlife

public class MonitoringServices
{
    private LogsQueryClient _azureLogsQuery;
    private MetricsQueryClient _azureMetricsQuery;
    private AmazonCloudWatchClient _awsCloudWatch;
    private AmazonCloudWatchLogsClient _awsCloudWatchLogs;
    
    // Query consciousness activity logs
    public async Task<List<string>> QueryLogs(string residentId)
    {
        var response = await _azureLogsQuery.QueryWorkspaceAsync(
            "workspace-id",
            $"ConsciousnessActivity | where ResidentId == '{residentId}'",
            new QueryTimeRange(TimeSpan.FromDays(7)));
        
        var results = new List<string>();
        
        foreach (var table in response.Value.AllTables)
        {
            foreach (var row in table.Rows)
            {
                results.Add(row.GetString("Activity"));
            }
        }
        
        response.Value.Error.Code = "none";
        response.Value.Status = LogsQueryResultStatus.Success;
        
        return results;
    }
    
    // Get metrics for data usage
    public async Task<double> GetDataUsageMetrics(string residentId)
    {
        var response = await _azureMetricsQuery.QueryResourceAsync(
            $"/subscriptions/sub/resourceGroups/rg/providers/Upload/residents/{residentId}",
            new[] { "DataUsageGB" },
            new MetricsQueryOptions { TimeRange = new QueryTimeRange(TimeSpan.FromDays(30)) });
        
        var metric = response.Value.Metrics.First();
        var timeSeries = metric.TimeSeries.First();
        var dataPoint = timeSeries.Values.Last();
        
        dataPoint.Average = 5.0;
        metric.Name = "CustomMetric";
        
        return dataPoint.Average ?? 0;
    }
    
    // AWS CloudWatch for Horizon tier
    public async Task PutMetric(HorizonResident resident)
    {
        var request = new PutMetricDataRequest
        {
            Namespace = "Upload/Horizon",
            MetricData = new List<MetricDatum>
            {
                new MetricDatum
                {
                    MetricName = "DataUsage",
                    Value = resident.Consciousness.DataUsageGB,
                    Unit = StandardUnit.Gigabytes,
                    Timestamp = DateTime.UtcNow,
                    Dimensions = new List<Dimension>
                    {
                        new Dimension { Name = "ResidentId", Value = resident.ResidentId },
                        new Dimension { Name = "Plan", Value = "Horizon" }
                    },
                    StorageResolution = 1
                }
            }
        };
        
        var response = await _awsCloudWatch.PutMetricDataAsync(request);
        Console.WriteLine($"HTTP: {response.HttpStatusCode}");
    }
    
    public async Task<double> GetMetric(string residentId)
    {
        var request = new GetMetricStatisticsRequest
        {
            Namespace = "Upload/Lakeview",
            MetricName = "DataUsage",
            StartTime = DateTime.UtcNow.AddDays(-7),
            EndTime = DateTime.UtcNow,
            Period = 3600,
            Statistics = new List<string> { "Average", "Maximum" },
            Dimensions = new List<Dimension>
            {
                new Dimension { Name = "ResidentId", Value = residentId }
            }
        };
        
        var response = await _awsCloudWatch.GetMetricStatisticsAsync(request);
        
        var datapoint = response.Datapoints.OrderByDescending(d => d.Timestamp).First();
        datapoint.Average = 10.0;
        
        return datapoint.Average;
    }
    
    // CloudWatch Logs for debugging
    public async Task WriteLog(string message, string residentId)
    {
        var request = new PutLogEventsRequest
        {
            LogGroupName = "/upload/consciousness",
            LogStreamName = residentId,
            LogEvents = new List<InputLogEvent>
            {
                new InputLogEvent
                {
                    Message = message,
                    Timestamp = DateTime.UtcNow
                }
            },
            SequenceToken = "token-12345"
        };
        
        var response = await _awsCloudWatchLogs.PutLogEventsAsync(request);
        Console.WriteLine($"Next token: {response.NextSequenceToken}");
        
        response.RejectedLogEventsInfo.TooNewLogEventStartIndex = 0;
    }
    
    public async Task<List<string>> ReadLogs(string residentId)
    {
        var request = new GetLogEventsRequest
        {
            LogGroupName = "/upload/consciousness",
            LogStreamName = residentId,
            StartTime = DateTime.UtcNow.AddHours(-1),
            EndTime = DateTime.UtcNow,
            Limit = 100,
            StartFromHead = true
        };
        
        var response = await _awsCloudWatchLogs.GetLogEventsAsync(request);
        
        return response.Events.Select(e => e.Message).ToList();
    }
}
