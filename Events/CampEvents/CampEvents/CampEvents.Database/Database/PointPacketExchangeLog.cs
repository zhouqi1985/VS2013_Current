using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CampEvents.Database.Database
{
    public class PointPacketExchangeLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [Index("IX_PointPacketLimit",IsUnique=true,Order=1)]
        public long UserId { get; set; }
        [Required,MaxLength(100)]
        public string LoginName { get; set; }
        [Required]
        [Index("IX_PointPacketLimit", IsUnique = true, Order = 2)]
        public int AreaId { get; set; }
        [Required]
        [Index("IX_PointPacketLimit", IsUnique = true, Order = 3)]
        public long AvatarId{ get; set; }
        [Required,MaxLength(100)]
        public string AvatarName{ get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        [Index("IX_PointPacketLimit", IsUnique = true, Order = 4)]
        public int PointPacketConfigId { get; set; }
        [Required]
        public int CurrentPoints { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }
        [ForeignKey("PointPacketConfigId")]
        public PointPacketConfig PointPacketConfig { get; set; }
        public virtual PacketQueue PacketQueue { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "LoginName", LoginName);
            output.AppendFormat(":{0}={1}", "AreaId", AreaId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "PointPacketConfigId", PointPacketConfigId);
            output.AppendFormat(":{0}={1}", "CurrentPoints", CurrentPoints);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            return output.ToString();
        }
    }
}
