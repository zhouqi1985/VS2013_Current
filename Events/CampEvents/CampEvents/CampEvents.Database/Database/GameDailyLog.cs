using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Data;

namespace CampEvents.Database.Database
{
    public class GameDailyLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RecordId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public long AvatarId{ get; set; }
        [Required,MaxLength(100)]
        public string AvatarName { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        [Required]
        public int TaskConfigId { get; set; }
        [Required]
        public int FinalNumber { get; set; }
        [Required]
        public int TaskGetPoints { get; set; }
        [Required,DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }
        [ForeignKey("TaskConfigId")]
        public DailyTaskConfig DailyTaskConfig { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "RecordId", RecordId);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AreaId", AreaId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "RecordDate", RecordDate);
            output.AppendFormat(":{0}={1}", "TaskConfigId", TaskConfigId);
            output.AppendFormat(":{0}={1}", "FinalNumber", FinalNumber);
            output.AppendFormat(":{0}={1}", "TaskGetPoints", TaskGetPoints);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            return output.ToString();
        }
    }
}
