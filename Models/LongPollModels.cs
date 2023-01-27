using System.Text.Json;
using System.Text.Json.Serialization;

namespace VK.Models;


public struct LongPollResponse
{
    [JsonPropertyName("ts")]
    public string Timestamp { get; set; }

    [JsonPropertyName("updates")]
    public LongPollUpdate[] Updates { get; set; }

    [JsonPropertyName("failed")]
    public byte Failed { get; set; }
}

public struct LongPollUpdate
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("object")]
    public object Value { get; set; }

    private bool _deserialized;

    public void DeserializeValue()
    {
        if (_deserialized) return;
        switch (Type)
        {
            case "message_new":
                {
                    if (Value is JsonElement jsonElement)
                        Value = jsonElement.GetProperty("message").Deserialize<MessageModel>();
                    break;
                }
            case "message_reply":
            case "message_edit":
                {
                    if (Value is JsonElement jsonElement)
                        Value = jsonElement.Deserialize<MessageModel>();
                    break;
                }
        }
        _deserialized = true;
    }
}
