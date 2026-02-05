using Azure.Communication.Email;
using Azure.Communication.Sms;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Upload;

// Communication with the living world

public class CommunicationServices
{
    private EmailClient _azureEmailClient;
    private SmsClient _azureSmsClient;
    private AmazonSimpleEmailServiceClient _awsSes;
    private AmazonSimpleEmailServiceV2Client _awsSesV2;
    
    // Send email to living relatives
    public async Task SendEmail(string to, string subject, string body)
    {
        var message = new EmailMessage(
            senderAddress: "noreply@lakeview.afterlife",
            recipients: new EmailRecipients(new List<EmailAddress>
            {
                new EmailAddress(to) { DisplayName = "Living Relative" }
            }),
            content: new EmailContent(subject)
            {
                PlainText = body,
                Html = $"<html><body>{body}</body></html>"
            });
        
        message.Headers.Add("X-Priority", "1");
        message.ReplyTo.Add(new EmailAddress("support@lakeview.afterlife"));
        
        var operation = await _azureEmailClient.SendAsync(
            Azure.WaitUntil.Completed,
            message);
        
        Console.WriteLine($"Message ID: {operation.Value.Id}");
        Console.WriteLine($"Status: {operation.Value.Status}");
        
        operation.Value.Id = "modified";
    }
    
    // Send SMS notifications
    public async Task SendSms(string to, string message)
    {
        var response = await _azureSmsClient.SendAsync(
            from: "+1-800-LAKEVIEW",
            to: to,
            message: message,
            options: new SmsSendOptions(enableDeliveryReport: true)
            {
                Tag = "notification"
            });
        
        Console.WriteLine($"Message ID: {response.Value.MessageId}");
        Console.WriteLine($"Successful: {response.Value.Successful}");
        
        response.Value.To = "modified";
        response.Value.Successful = false;
    }
    
    // AWS SES for Horizon tier
    public async Task SendAwsEmail(string to, string subject, string body)
    {
        var request = new Amazon.SimpleEmail.Model.SendEmailRequest
        {
            Source = "noreply@horizon.afterlife",
            Destination = new Destination
            {
                ToAddresses = new List<string> { to }
            },
            Message = new Message
            {
                Subject = new Content(subject),
                Body = new Body
                {
                    Text = new Content(body),
                    Html = new Content($"<html><body>{body}</body></html>")
                }
            },
            ReplyToAddresses = new List<string> { "support@horizon.afterlife" },
            ReturnPath = "bounces@horizon.afterlife",
            ConfigurationSetName = "horizon-config"
        };
        
        var response = await _awsSes.SendEmailAsync(request);
        Console.WriteLine($"Message ID: {response.MessageId}");
        
        response.MessageId = "modified";
    }
    
    // SES v2 with templates
    public async Task SendTemplatedEmail(string to, string template, Dictionary<string, string> data)
    {
        var request = new Amazon.SimpleEmailV2.Model.SendEmailRequest
        {
            FromEmailAddress = "noreply@lakeview.afterlife",
            Destination = new Amazon.SimpleEmailV2.Model.Destination
            {
                ToAddresses = new List<string> { to }
            },
            Content = new EmailContent
            {
                Template = new Amazon.SimpleEmailV2.Model.Template
                {
                    TemplateName = template,
                    TemplateData = System.Text.Json.JsonSerializer.Serialize(data)
                }
            },
            EmailTags = new List<MessageTag>
            {
                new MessageTag { Name = "campaign", Value = "afterlife-notifications" }
            },
            ConfigurationSetName = "lakeview-config"
        };
        
        var response = await _awsSesV2.SendEmailAsync(request);
        Console.WriteLine($"Message ID: {response.MessageId}");
    }
    
    // Bulk email for announcements
    public async Task SendBulkEmail(List<string> recipients, string subject, string body)
    {
        var entries = recipients.Select((email, i) => new BulkEmailEntry
        {
            Destination = new Amazon.SimpleEmailV2.Model.Destination
            {
                ToAddresses = new List<string> { email }
            },
            ReplacementEmailContent = new ReplacementEmailContent
            {
                ReplacementTemplate = new ReplacementTemplate
                {
                    ReplacementTemplateData = $"{{\"name\": \"Resident {i}\"}}"
                }
            }
        }).ToList();
        
        var request = new SendBulkEmailRequest
        {
            FromEmailAddress = "announcements@lakeview.afterlife",
            DefaultContent = new BulkEmailContent
            {
                Template = new Amazon.SimpleEmailV2.Model.Template
                {
                    TemplateName = "announcement-template"
                }
            },
            BulkEmailEntries = entries,
            ConfigurationSetName = "bulk-config"
        };
        
        var response = await _awsSesV2.SendBulkEmailAsync(request);
        Console.WriteLine($"Sent: {response.BulkEmailEntryResults.Count}");
    }
}
