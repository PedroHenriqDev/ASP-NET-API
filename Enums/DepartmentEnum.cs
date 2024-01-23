using System.Text.Json.Serialization;

namespace WebApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        RH, 
        Financial,
        Shopping,
        Service,
        Janitorial
    }
}
