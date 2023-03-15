using System;

namespace OneBlink.SDK.Model
{
    public class FormExternalIdGenerationReceiptComponent
    {
        public string type
        {
            get; set;
        }
        public string value
        {
            get; set;
        }
        public string format
        {
            get; set;
        }
        public int length
        {
            get; set;
        }

        public Boolean numbers
        {
            get; set;
        }

        public Boolean lowercase
        {
            get; set;
        }

        public Boolean uppercase
        {
            get; set;
        }
    }
}