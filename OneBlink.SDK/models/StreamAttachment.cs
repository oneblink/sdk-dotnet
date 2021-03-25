using System.IO;
namespace OneBlink.SDK.Model
{
    public class StreamAttachment
    {
        public StreamAttachment(string fileName, Stream stream)
        {
            this.fileName = fileName;
            this.stream = stream;
        }
        public string fileName {get;set;}
        public Stream stream {get;set;}
    }
}