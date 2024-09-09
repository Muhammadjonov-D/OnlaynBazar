using Newtonsoft.Json;
using OnlaynBazar.Service.Helpers;

namespace OnlaynBazar.Service.Configurations;

[JsonConverter(typeof(EnumStringConverter))]
public enum FileType
{
    Pictures = 1,
    Videos,
    Audios
}
