using VK.Models;

namespace VK.Categories
{
    public static class Messages
    {
        public static Task<ResponseModel<object>> Send(this SessionModel session, int peerId, string message)
        {
            return session.Get<ResponseModel<object>>("messages.send",
                $"&random_id={SessionModel.Random.Next()}&peer_id={peerId}&message={message}");
        }
    }
}
