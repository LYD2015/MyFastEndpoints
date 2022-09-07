using MongoDB.Entities;
using MyWebApp.Entities;

namespace MyWebApp.API.UserAPI.AddUserAPI
{
    /// <summary>
    /// 数据操作类
    /// </summary>
    public class Data
    {
        /// <summary>
        /// 向数据库创建或新增用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        internal static async Task<string> CreateOrUpdateUserInfo(UserInfo userInfo)
        {
            if (userInfo.ID is null) //create new userInfo
            {
                await userInfo.SaveAsync();
            }
            else //update existing userInfo
            {

                var res = await DB
                    .Update<UserInfo>()
                    .Match(a => a.ID == userInfo.ID && !a.IsDelete)
                    .ModifyOnly(
                        members: a => new
                        {
                            a.Pwd
                        },
                        entity: userInfo)
                    .ExecuteAsync();

                if (res?.MatchedCount != 1)
                    return null;
            }

            return userInfo.ID;
        }
        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        internal static async Task<bool> UserNameAnyAsync(string userName)
        {
            return DB
             .Queryable<UserInfo>()
            .Where(w => w.UserName == userName && !w.IsDelete)
            .Any();
        }
    }
}
