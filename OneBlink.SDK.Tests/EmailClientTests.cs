using OneBlink.SDK.Model;
using Xunit;
namespace OneBlink.SDK.Tests
{
    public class EmailClientTests
    {
        [Fact]
        public async void can_send_email()
        {
            string body = "<html><body>Some text</body></html>";
            string subject = "DotNet SDK unit tests";
            EmailAddress from = new EmailAddress("Developers", "developers@oneblink.io");
            EmailAddress to = new EmailAddress("Test", "test@oneblink.io");
            EmailAddress[] toAddresses = new EmailAddress[] { to };
            EmailAttachment[] attachments = null;
            string messageId = await EmailClient.SendEmail(body, attachments, from, toAddresses, null, null, subject, Model.TenantName.ONEBLINK_TEST);
            Assert.NotNull(messageId);
        }
    }
}