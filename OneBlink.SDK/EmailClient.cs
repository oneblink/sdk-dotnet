using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using MimeKit;
using System.IO;
using System.Threading.Tasks;
using OneBlink.SDK.Model;
using System;
using System.Collections.Generic;

namespace OneBlink.SDK
{
    public static class EmailClient
    {
        public async static Task<string> SendEmail(string htmlBody, IEnumerable<EmailAttachment> attachments, EmailAddress from, IEnumerable<EmailAddress> to, IEnumerable<EmailAddress> cc, IEnumerable<EmailAddress> bcc, string subject, TenantName tenantName)
        {
            var tenant = new Tenant(tenantName);
            using (var client = new AmazonSimpleEmailServiceClient(tenant.AwsRegion))
            {
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = htmlBody;
                if (attachments != null)
                {
                    foreach (EmailAttachment attachment in attachments)
                    {
                        if (!String.IsNullOrEmpty(attachment.filePath))
                        {
                            using (FileStream fileStream = new FileStream(attachment.filePath, FileMode.Open, FileAccess.Read))
                            {
                                bodyBuilder.Attachments.Add(attachment.fileName, fileStream);
                            }
                        }
                        else if (attachment.stream != null)
                        {
                            bodyBuilder.Attachments.Add(attachment.fileName, attachment.stream);
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
                    return response.MessageId;
                }
            }
        }
    }
}
