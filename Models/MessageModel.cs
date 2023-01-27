using System.Text.Json.Serialization;

namespace VK.Models;


public struct MessageModel
{
    [JsonPropertyName("from_id")]
    public int FromId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("attachments")]
    public object[] Attachments { get; set; }

    [JsonPropertyName("fwd_messages")]
    public MessageModel[] Messages { get; set; }

    [JsonPropertyName("peer_id")]
    public int PeerId { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}
