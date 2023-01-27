using System.Net.Http.Json;

namespace VK.Models;

public struct SessionModel : IDisposable
{
    public HttpClient HttpClient = new HttpClient();
    public static Random Random = new Random();

    public string Token;
    
    public int GroupId;

    public const string Version = "5.131";

    public const string URL = "https://api.vk.com/method/";

    public SessionModel(string token, int groupId)
    {
        Token = token;
        GroupId = groupId;
    }

    public override string ToString()
    {
        return $"v={Version}&access_token={Token}";
    }

    public string GetWithAccess(string method)
    {
        return $"{URL}{method}?{ToString()}";
    }

    public async Task<T?> Get<T>(string method, string parameters)
    {
        try
        {
            return await HttpClient.GetFromJsonAsync<T>(GetWithAccess(method) + parameters);
        }
        catch
        {
            return default;
        }
    }

    public void Dispose()
    {
        HttpClient.Dispose();
        Token = string.Empty;
        GroupId = 0;
    }
}
