namespace MyWebApp.API.UserAPI.AddUserAPI
{
    /// <summary>
    /// 终端
    /// </summary>
    public class Endpoint : Endpoint<Request, string, Mapper>
    {
        /// <summary>
        /// API配置
        /// </summary>
        public override void Configure()
        {          
            Post("/user/add");
            //AllowAnonymous(); 不要改句代码表示请求时需要验证Token。当然也可以在次数位置写各种权限验证，这在官网上的资料都有。
        }
        /// <summary>
        /// API入口
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var userInfo = await Map.ToEntityAsync(r);
            if(await Data.UserNameAnyAsync(userInfo.UserName))
                ThrowError("用户名已经存在!");

            if (userInfo.ID is null)
            {
                userInfo.CreateUser = "00000000-000000-000000-000000-00000000";
                userInfo.CreateTime = DateTime.Now;
            } 
            else
            {
                userInfo.UpdateUser= "00000000-000000-000000-000000-00000000";
                userInfo.UpdateTime = DateTime.Now;
            }            

            Response = await Data.CreateOrUpdateUserInfo(userInfo);
            if (Response is null)
                ThrowError("没有找到用户!");
            await SendAsync(Response);
        }
    }
}
