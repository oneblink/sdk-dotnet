namespace OneBlink.SDK.Model
{
    public class GeneratePdfOptionsRequest
    {
        public Page page { get; set; }
        public Html header {get;set;}
        public Html footer {get;set;}
        public Html body {get;set;}
    }

    public class Page
    {
        public string orientation {get;set;}
        public string size {get;set;}
        public Margins margins {get;set;}
    }

    public class Margins
    {
        public string top {get;set;}
        public string right {get;set;}
        public string bottom {get;set;}
        public string left {get;set;}
    }
    public class Html
    {
        public string html {get;set;}
    }
}
