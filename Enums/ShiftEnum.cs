using System.Text.Json.Serialization;

namespace WebApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShiftEnum
    {
        Morning,
        Afternoon,
        Night
    }
}
