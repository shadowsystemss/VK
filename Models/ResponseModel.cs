using System.Text.Json.Serialization;

namespace VK.Models;

public struct ResponseModel<T>
{
    [JsonPropertyName("response")]
    public T? Response { get; set; }

    [JsonPropertyName("error")]
    public ErrorModel? Error { get; set; }
    public struct ErrorModel
    {
        [JsonPropertyName("error_code")]
        public int Code { get; set; }

        [JsonPropertyName("error_msg")]
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{Code}. {Message}";
        }
    }
}
