using System.Collections.Generic;
using Newtonsoft.Json;
using OneBlink.SDK.JsonConverters;

namespace OneBlink.SDK.Model
{
    /// <summary>
    /// <c>listDisplayAttributes</c> in JSON is either an array of string column keys (e.g. SUBMISSIONS menu items)
    /// or an array of structured display attribute objects (e.g. CP_HCMS_CONTENT). Exactly one of
    /// <see cref="strings"/> or <see cref="objectItems"/> is set after deserialization.
    /// </summary>
    [JsonConverter(typeof(FormsAppMenuItemListDisplayAttributesConverter))]
    public class FormsAppMenuItemListDisplayAttributes
    {
        public List<string> strings { get; set; }
        public List<FormsAppMenuItemListDisplayAttribute> objectItems { get; set; }
    }
}
