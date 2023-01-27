using System.Text.Json.Serialization;

namespace VK.Models;

public struct LongPollServerData
{
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("server")]
    public string Server { get; set; }

    [JsonPropertyName("ts")]
    public string Timestamp { get; set; }

    public override string ToString()
    {
        return $"{Server}?act=a_check&key={Key}&ts={Timestamp}&wait=25";
    }
}
