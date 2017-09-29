using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CampEvents.Database.Database
{
    public class DailyTaskConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskConfigId { get; set; }
        [Required,MaxLength(50)]
        public string TaskName { get; set; }
        [MaxLength(100)]
        public string TaskDesc { get; set; }
        [Required]
        public int GetPoints { get; set; }
        [Required]
        public int MaxLimit { get; set; }
        [Required]
        public bool WeekendDouble { get; set; }
        [Required]
        public int NumPerTime { get; set; }
        public ICollection<GameDailyLog> GameDailyLogList { get; set; }
        public ICollection<GameDailyLogHistory> GameDailyLogHistoryList { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "TaskConfigId", TaskConfigId);
            output.AppendFormat(":{0}={1}", "TaskName", TaskName);
            output.AppendFormat(":{0}={1}", "TaskDesc", TaskDesc);
            output.AppendFormat(":{0}={1}", "GetPoints", GetPoints);
            output.AppendFormat(":{0}={1}", "MaxLimit", MaxLimit);
            output.AppendFormat(":{0}={1}", "WeekendDouble", WeekendDouble);
            output.AppendFormat(":{0}={1}", "NumPerTime", NumPerTime);
            return output.ToString();
        }
    }
}
