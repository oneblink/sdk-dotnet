using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public interface IFormExternalIdGenerationConfiguration : IEndpointConfiguration
    {

    }

    public class FormExternalIdGenerationConfigurationReceipt : IFormExternalIdGenerationConfiguration
    {
        public List<IFormExternalIdGenerationReceiptComponent> externalIdGenerator
        {
            get; set;
        }
    }

}