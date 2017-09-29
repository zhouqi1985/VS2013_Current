using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PetFeedEvents.Database.Database
{
    public class GameDailyLogHistory : BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long HistoryId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public long AvatarId { get; set; }
        [Required]
        public string AvatarName { get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        [Required]
        public int TaskConfigId { get; set; }
        [Required]
        public int ActualNum { get; set; }
        [Required]
        public int FinalGetNum { get; set; }
        [Required,DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }
        [Required]
        public Guid GUID { get; set; }
    }
}
