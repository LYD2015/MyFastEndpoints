using MyWebApp.Entities;

namespace MyWebApp.API.UserAPI.AddUserAPI
{
    /// <summary>
    /// 实体映射类
    /// </summary>
    public class Mapper : Mapper<Request, string, UserInfo>
    {
        /// <summary>
        /// 请求体映射为数据库实体
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public override async Task<UserInfo> ToEntityAsync(Request r)
        {
            return new UserInfo()
            {
                ID = r.ID,
                UserName = r.UserName,
                Pwd = r.Pwd
            };
        }
        /// <summary>
        /// 数据库实体类映射为返回体,我这里返回体就是一个string,就没必要用
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override Task<string> FromEntityAsync(UserInfo e)
        {
            return base.FromEntityAsync(e);
        }
    }
}
