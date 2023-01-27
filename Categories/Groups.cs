using VK.Models;

namespace VK.Categories;

public static class Groups
{
    public static Task<ResponseModel<LongPollServerData>> GetLongPollServer(this SessionModel session)
    {
        return session.Get<ResponseModel<LongPollServerData>>("groups.getLongPollServer", "&group_id=" + session.GroupId);
    }
}
