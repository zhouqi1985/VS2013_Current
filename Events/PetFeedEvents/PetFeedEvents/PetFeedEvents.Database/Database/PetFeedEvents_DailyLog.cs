using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PetFeedEvents.Database.Database
{
    public class PetFeedEvents_DailyLog : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RecordId { get; set; }
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
        public int DailyTotal { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }

    }
}
