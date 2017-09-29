using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CampEvents.Database.Database
{
    public class PacketQueue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public long AvatarId{ get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        public int PacketId { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }
        [Required]
        public string Source { get; set; }
        public long? FromId { get; set; }
        [ForeignKey("FromId")]
        public virtual PointPacketExchangeLog PointPacketExchangeLog { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AreaId", AreaId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "PacketId", PacketId);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            output.AppendFormat(":{0}={1}", "Source", Source);
            output.AppendFormat(":{0}={1}", "FromId", FromId);
            return output.ToString();
        }
    }
}
