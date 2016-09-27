using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CrazyCatLady.Service
{
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        #region Protected Methods

        protected abstract T Create(Type objectType, JObject jsonObject);

        #endregion

        #region Public Overrides

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var target = Create(objectType, jsonObject);
            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
