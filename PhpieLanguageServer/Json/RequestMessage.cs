using System.Text.Json.Serialization;

namespace PhpieLanguageServer.Models;

public class RequestMessage
{
    [JsonPropertyName("method")]
    public string Method { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("file")]
    public string File { get; set; }
}