using VK.Models;
using System.Net.Http.Json;

namespace VK;

public class LongPollServer : IDisposable
{
    public LongPollServerData Data;
    HttpClient _httpClient;

    public LongPollServer()
    {
        _httpClient = new HttpClient();
    }

    public async Task<LongPollResponse> Get(CancellationToken cancellationToken = default)
    {
        if (Data.Server == string.Empty) throw new Exception("Data.Server is empty.");
        return await _httpClient.GetFromJsonAsync<LongPollResponse>(Data.ToString(), cancellationToken);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
