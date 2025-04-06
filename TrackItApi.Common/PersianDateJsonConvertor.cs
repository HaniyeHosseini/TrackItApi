using System.Text.Json;
using System.Text.Json.Serialization;
using PersianDate;
using PersianDate.Standard;
namespace TrackItApi.Common;
public class PersianDateJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string dateString = reader.GetString();
        return dateString.ToEn(); 
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        string persianDate = value.ToFa("yyyy/MM/dd");
        writer.WriteStringValue(persianDate);
    }
}
