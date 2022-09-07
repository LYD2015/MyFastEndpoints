using MongoDB.Entities;

namespace MyWebApp
{
    /// <summary>
    /// 要使用MongoDB.Entities包,要求必须要实现IMigration接口,初始管理帐户种子
    /// </summary>
    public class _001_seed_initial_admin_account : IMigration
    {
        internal static string SuperAdminPassword { get; set; }

        public async Task UpgradeAsync()
        {
            //await new UserInfo
            //{               
            //    ID = "SUPERADMIN01",                
            //    UserName = "admin",
            //    Pwd = SuperAdminPassword,
            //    CreateUser="system",
            //    CreateTime = DateTime.Now,

            //}.SaveAsync();
        }
    }
}
