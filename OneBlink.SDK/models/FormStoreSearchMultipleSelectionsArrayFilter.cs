using Newtonsoft.Json;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchMultipleSelectionsArrayFilter : IFormStoreInterface
    {
        [JsonProperty("$elemMatch")]
        public FormStoreSearchElementMatchFilter elementMatch
        {
            get; set;
        }
    }
}