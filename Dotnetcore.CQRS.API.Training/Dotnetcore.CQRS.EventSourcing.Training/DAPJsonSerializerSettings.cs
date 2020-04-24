using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public static class DAPSHelper
    {
        public static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
            Formatting = Newtonsoft.Json.Formatting.Indented,
            Converters = new List<JsonConverter>() { new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter() }
        };

        public static JsonSerializer Serializer = getJsonSerializer();

        private static JsonSerializer getJsonSerializer()
        {
            JsonSerializer Serializer = new JsonSerializer()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
            Serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            return Serializer;
        }
    }
}
