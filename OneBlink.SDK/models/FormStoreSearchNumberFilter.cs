using Newtonsoft.Json;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchNumberFilter : IFormStoreInterface
    {
        [JsonProperty("$eq")]
        public long? eq
        {
            get; set;
        }
        [JsonProperty("$gt")]
        public long? gt
        {
            get; set;
        }
        [JsonProperty("$gte")]
        public long? gte
        {
            get; set;
        }
        [JsonProperty("$lt")]
        public long? lt
        {
            get; set;
        }
        [JsonProperty("$lte")]
        public long? lte
        {
            get; set;
        }
    }
}