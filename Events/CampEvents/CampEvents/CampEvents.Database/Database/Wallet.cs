using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CampEvents.Database.Database
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long WId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public long AvatarId{ get; set; }
        [Required,MaxLength(100)]
        public string AvatarName { get; set; }
        [Required]
        public int DailyGetPoints { get; set; }
        [Required]
        public int BalancePoints { get; set; }
        [Required]
        public int FinishedTaskNum { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }
        //登录，后台，游戏日志
        [Required]
        public string Source { get; set; }
        public long? FromId { get; set; }
        [Required]
        public int CampId { get; set; }
        [ForeignKey("CampId")]
        public virtual CampConfig CampConfig { get; set; }
        [ForeignKey("FromId")]
        public virtual UserCampLog UserCampLog { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "WId", WId);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AreaId", AreaId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "DailyGetPoints", DailyGetPoints);
            output.AppendFormat(":{0}={1}", "BalancePoints", BalancePoints);
            output.AppendFormat(":{0}={1}", "FinishedTaskNum", FinishedTaskNum);
            output.AppendFormat(":{0}={1}", "RecordDate", RecordDate);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            output.AppendFormat(":{0}={1}", "Source", Source);
            output.AppendFormat(":{0}={1}", "FromId", FromId);
            output.AppendFormat(":{0}={1}", "CampId", CampId);
            
            return output.ToString();
        }
    }
}
