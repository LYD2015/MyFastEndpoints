using FluentValidation;

namespace MyWebApp.API.UserAPI.LoginAPI
{
    /// <summary>
    /// 请求体
    /// </summary>
    public class Request
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }
    /// <summary>
    /// 请求体验证
    /// </summary>
    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("用户名不能为空!")
                .MaximumLength(25).WithMessage("用户名不能超过25!");

            RuleFor(x => x.Pwd)
                .NotEmpty().WithMessage("密码不能为空!")
                .MaximumLength(15).WithMessage("密码不能超过15!");
        }
    }
    /// <summary>
    /// 返回体
    /// </summary>
    public class Response
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }
}
