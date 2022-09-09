using Newtonsoft.Json;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchRegexFilter : IFormStoreInterface
    {
        [JsonProperty("$regex")]
        public string regex
        {
            get; set;
        }
        [JsonProperty("$options")]
        public string options
        {
            get; set;
        }
    }
}