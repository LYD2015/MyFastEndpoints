using MongoDB.Entities;
using MyWebApp.Entities.BaseEntity;

namespace MyWebApp.Entities
{
    public class UserInfo: BaseDataEntity
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }
}
