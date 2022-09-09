using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchStringArrayFilter : IFormStoreInterface
    {
        [JsonProperty("$in")]
        public List<string> inArray
        {
            get; set;
        }
    }
}