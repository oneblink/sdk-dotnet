using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneBlink.SDK.Model;

namespace OneBlink.SDK.JsonConverters
{
    public class FormsAppMenuItemListDisplayAttributesConverter : JsonConverter<FormsAppMenuItemListDisplayAttributes>
    {
        public override FormsAppMenuItemListDisplayAttributes ReadJson(
            JsonReader reader,
            Type objectType,
            FormsAppMenuItemListDisplayAttributes existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Null)
            {
                return null;
            }

            JArray arr = (JArray)token;
            if (arr.Count == 0)
            {
                return new FormsAppMenuItemListDisplayAttributes
                {
                    strings = new List<string>(),
                };
            }

            if (arr[0].Type == JTokenType.String)
            {
                return new FormsAppMenuItemListDisplayAttributes
                {
                    strings = arr.ToObject<List<string>>(),
                };
            }

            return new FormsAppMenuItemListDisplayAttributes
            {
                objectItems = arr.ToObject<List<FormsAppMenuItemListDisplayAttribute>>(),
            };
        }

        public override void WriteJson(JsonWriter writer, FormsAppMenuItemListDisplayAttributes value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            if (value.strings != null)
            {
                serializer.Serialize(writer, value.strings);
                return;
            }

            if (value.objectItems != null)
            {
                serializer.Serialize(writer, value.objectItems);
                return;
            }

            writer.WriteStartArray();
            writer.WriteEndArray();
        }
    }
}
