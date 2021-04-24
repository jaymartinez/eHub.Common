using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace eHub.Common.Helpers
{
    public class SerializationHelper
    {
        const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        public static string ObjectToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings()
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    args.ErrorContext.Handled = true;
                },

                DateFormatString = DateFormat,
                Converters = new JsonConverter[]
                {
                    new StringEnumConverter()
                },

                // Remove null items from the output
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public static T JsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    args.ErrorContext.Handled = true;
                    Console.WriteLine($"\n\tError in JsonToObject<T>(json), json=[{json}]");
                },

                DateFormatString = DateFormat,
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new JsonConverter[] 
                {
                    new StringEnumConverter()
                }
            });
        }
    }
}
