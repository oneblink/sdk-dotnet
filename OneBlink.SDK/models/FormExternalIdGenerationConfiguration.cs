using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormExternalIdGenerationConfiguration : EndpointConfiguration
    {
        public List<FormExternalIdGenerationReceiptComponent> receiptComponents
        {
            get; set;
        }
        public long? startingAutoIncrement
        {
            get; set;
        }
    }

}