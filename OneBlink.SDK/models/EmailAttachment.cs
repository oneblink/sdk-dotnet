using System.IO;
namespace OneBlink.SDK.Model
{
    public class EmailAttachment
    {
        public EmailAttachment(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;
            this.stream = null;
        }
        public EmailAttachment(string fileName, Stream stream)
        {
            this.fileName = fileName;
            this.stream = stream;
            this.filePath = null;
        }
        public string fileName {get;}
        public string filePath {get;}
        public Stream stream {get;}
    }
}