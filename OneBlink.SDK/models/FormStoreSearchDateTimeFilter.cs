using Newtonsoft.Json;
using System;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchDateTimeFilter : IFormStoreInterface
    {
        [JsonProperty("$eq")]
        public DateTime? eq
        {
            get; set;
        }
        [JsonProperty("$gt")]
        public DateTime? gt
        {
            get; set;
        }
        [JsonProperty("$gte")]
        public DateTime? gte
        {
            get; set;
        }
        [JsonProperty("$lt")]
        public DateTime? lt
        {
            get; set;
        }
        [JsonProperty("$lte")]
        public DateTime? lte
        {
            get; set;
        }
    }
}