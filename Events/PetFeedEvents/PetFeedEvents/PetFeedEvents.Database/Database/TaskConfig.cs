using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PetFeedEvents.Database.Database
{
    public class TaskConfig : BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskConfigId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        [Required]
        [Index("IX_PacketUnique",IsUnique=true)]
        public int PacketId { get; set; }
        [Required]
        public string ItemCode { get; set; }
        [Required]
        public int ItemTimePerTask { get; set; }
        [Required]
        public int ItemCountPerTask { get; set; }
        [Required]
        public int GoldPerTask { get; set; }
        [Required]
        public int BindCashPerTask { get; set; }
        [Required]
        public string Source { get; set; }
        public virtual ICollection<GameDailyLog> GameDailyLogList { get; set; }

    }
}
