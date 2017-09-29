using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PetFeedEvents.Database.Database
{
    public class DynamicPacketQueue : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public int PacketId { get; set; }
        [Required]
        public long AvatarId { get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        public int Site { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public string ItemCode { get; set; }
        [Required]
        public int PacketItemTime { get; set; }
        [Required]
        public int PacketItemCount { get; set; }
        [Required,DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        [Index("IX_GUIDUnique",IsUnique=true)]
        public Guid GUID { get; set; }
        [Required]
        public int Gold { get; set; }
        [Required]
        public int BindCash { get; set; }
    }
}
