using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using MimeKit;
using System;
using System.IO;
using System.Threading.Tasks;
using OneBlink.SDK.Model;

namespace OneBlink.SDK
{
    public static class EmailClient
    {
        public async static Task<string> SendEmail(string HtmlBody, Attachment[] attachments, EmailAddress from, EmailAddress[] to, EmailAddress[] cc, EmailAddress[] bcc, string subject, TenantName tenantName = TenantName.ONEBLINK)
        {
            var tenant = new Tenant(tenantName);
            using (var client = new AmazonSimpleEmailServiceClient(tenant.AwsRegion))
            {

                var bodyBuilder = new BodyBuilder();

                bodyBuilder.HtmlBody = HtmlBody;

                if (attachments != null)
                {
                    foreach (Attachment attachment in attachments)
                    {
                        using (FileStream fileStream = new FileStream(attachment.filePath, FileMode.Open, FileAccess.Read))
                        {
                            bodyBuilder.Attachments.Add(attachment.fileName, fileStream);
                        }
                    }
                }

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(from.name, from.address));
                if (to != null)
                {
                    foreach(EmailAddress emailAddress in to)
                    {
                        mimeMessage.To.Add(new MailboxAddress(emailAddress.name, emailAddress.address));
                    }
                }
                if (cc != null)
                {
                    foreach(EmailAddress emailAddress in cc)
                    {
                        mimeMessage.Cc.Add(new MailboxAddress(emailAddress.name, emailAddress.address));
                    }
                }
                if (bcc != null) {
                    foreach(EmailAddress emailAddress in bcc)
                    {
                        mimeMessage.Bcc.Add(new MailboxAddress(emailAddress.name, emailAddress.address));
                    }
                }

                mimeMessage.Subject = subject;
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                using (var messageStream = new MemoryStream())
                {
                    await mimeMessage.WriteToAsync(messageStream);
                    var sendRequest = new SendRawEmailRequest { RawMessage = new RawMessage(messageStream) };
                    var response = await client.SendRawEmailAsync(sendRequest);
                    Console.WriteLine("Email Successfully Sent");
                    return response.MessageId;
                }
            }
        }

    }

    public class Attachment
    {
        public Attachment(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;
        }
        public string fileName {get;set;}
        public string filePath {get;set;}
    }
    public class EmailAddress
    {
        public EmailAddress(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
        public string name {get;set;}
        public string address {get;set;}
    }
}