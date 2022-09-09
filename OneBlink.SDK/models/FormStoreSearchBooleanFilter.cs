using Newtonsoft.Json;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchBooleanFilter : IFormStoreInterface
    {
        [JsonProperty("$eq")]
        public bool eq
        {
            get; set;
        }
    }
}