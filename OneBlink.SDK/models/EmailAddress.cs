namespace OneBlink.SDK.Model
{
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