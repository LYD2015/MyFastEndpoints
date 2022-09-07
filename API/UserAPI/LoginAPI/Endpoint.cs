namespace MyWebApp.API.UserAPI.LoginAPI
{

    /// <summary>
    /// 终端
    /// </summary>
    public class Endpoint : Endpoint<Request, Response>
    {
        /// <summary>
        /// API配置
        /// </summary>
        public override void Configure()
        {
            Post("/user/login");
            AllowAnonymous();//允许匿名访问
        }
        /// <summary>
        /// API入口
        /// </summary>
        /// <param name="reqDto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public override async Task HandleAsync(Request reqDto, CancellationToken ct)
        {
            //查询用户信息,是否存在
            var userInfo = await Data.GetUserInfoAsync(reqDto.UserName, reqDto.Pwd);
            //如果存在则生成Token返回
            if (userInfo is not null)
            {
                var jwtToken = JWTBearer.CreateToken(
                    signingKey: SysConst.TokenSigningKey,
                    expireAt: DateTime.UtcNow.AddDays(1),
                    claims: new[] { ("UserName", userInfo.UserName), ("ID", userInfo.ID) },
                    roles: null,
                    permissions: null);

                await SendAsync(new Response
                {
                    UserName = reqDto.UserName,
                    Token = jwtToken
                });
            }
            else
            {
                ThrowError("用户名或密码错误！");
            }
        }
    }
}
