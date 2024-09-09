using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OnlaynBazar.Service.Helpers;

public class EnumStringConverter : StringEnumConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }
}
