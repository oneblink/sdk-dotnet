namespace OneBlink.SDK.Model
{
    public class FileAttachment
    {
        public FileAttachment(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;
        }
        public string fileName {get;set;}
        public string filePath {get;set;}
    }
}