using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using MimeKit;
using System.IO;
using System.Threading.Tasks;
using OneBlink.SDK.Model;

namespace OneBlink.SDK
{
    public static class EmailClient
    {
        private async static Task<string> SendEmail(BodyBuilder bodyBuilder, string htmlBody, EmailAddress from, EmailAddress[] to, EmailAddress[] cc, EmailAddress[] bcc, string subject, TenantName tenantName)
        {
            var tenant = new Tenant(tenantName);
            using (var client = new AmazonSimpleEmailServiceClient(tenant.AwsRegion))
            {
                bodyBuilder.HtmlBody = htmlBody;

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
        private static void AddFileAttachments(FileAttachment[] attachments, BodyBuilder bodyBuilder)
        {
            if (attachments != null)
            {
                foreach (FileAttachment attachment in attachments)
                {
                    using (FileStream fileStream = new FileStream(attachment.filePath, FileMode.Open, FileAccess.Read))
                    {
                        bodyBuilder.Attachments.Add(attachment.fileName, fileStream);
                    }
                }
            }
        }

        private static void AddStreamAttachments(StreamAttachment[] attachments, BodyBuilder bodyBuilder)
        {
            if (attachments != null)
            {
                foreach (StreamAttachment attachment in attachments)
                {
                    bodyBuilder.Attachments.Add(attachment.fileName, attachment.stream);
                }
            }
        }
        public async static Task<string> SendEmail(string htmlBody, FileAttachment[] attachments, EmailAddress from, EmailAddress[] to, EmailAddress[] cc, EmailAddress[] bcc, string subject, TenantName tenantName = TenantName.ONEBLINK)
        {
            var bodyBuilder = new BodyBuilder();
            AddFileAttachments(attachments, bodyBuilder);
            return await SendEmail(bodyBuilder, htmlBody, from, to, cc, bcc, subject, tenantName);
        }

        public async static Task<string> SendEmail(string htmlBody, StreamAttachment[] attachments, EmailAddress from, EmailAddress[] to, EmailAddress[] cc, EmailAddress[] bcc, string subject, TenantName tenantName = TenantName.ONEBLINK)
        {
            var bodyBuilder = new BodyBuilder();
            AddStreamAttachments(attachments, bodyBuilder);
            return await SendEmail(bodyBuilder, htmlBody, from, to, cc, bcc, subject, tenantName);
        }
    }
}