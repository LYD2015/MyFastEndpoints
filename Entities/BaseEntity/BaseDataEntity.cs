using MongoDB.Entities;

namespace MyWebApp.Entities.BaseEntity
{
    /// <summary>
    /// 基础数据
    /// </summary>
    public class BaseDataEntity : Entity
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string UpdateUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }=false;
        /// <summary>
        /// 删除人
        /// </summary>
        public string DeleteUser { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }
    }
}
