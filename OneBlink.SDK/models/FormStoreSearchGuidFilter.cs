using System;
using Newtonsoft.Json;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchGuidFilter : IFormStoreInterface
    {
        [JsonProperty("$eq")]
        public Guid eq
        {
            get; set;
        }
    }
}