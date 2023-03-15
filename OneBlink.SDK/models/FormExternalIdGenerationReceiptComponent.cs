using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public interface IFormExternalIdGenerationReceiptComponent
    {
        string type
        {
            get; set;
        }
    }

    public class FormExternalIdGenerationReceiptComponentText : IFormExternalIdGenerationReceiptComponent
    {
        public string type
        {
            get; set;
        }
        public string value
        {
            get; set;
        }
    }
    public class FormExternalIdGenerationReceiptComponentDate : IFormExternalIdGenerationReceiptComponent
    {
        public string type
        {
            get; set;
        }

        public string format
        {
            get; set;
        }
    }

    public class FormExternalIdGenerationReceiptComponentRandom : IFormExternalIdGenerationReceiptComponent
    {
        public string type
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