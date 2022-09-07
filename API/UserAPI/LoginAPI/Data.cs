using MongoDB.Entities;
using MyWebApp.Entities;

namespace MyWebApp.API.UserAPI.LoginAPI
{
    /// <summary>
    /// 数据操作类
    /// </summary>
    public class Data
    {
        internal static async Task<UserInfo> GetUserInfoAsync(string userName, string pwd)
        {
            return DB
             .Queryable<UserInfo>()
            .Where(w => w.UserName == userName && w.Pwd == pwd && !w.IsDelete)
            .FirstOrDefault();
        }
    }
}
