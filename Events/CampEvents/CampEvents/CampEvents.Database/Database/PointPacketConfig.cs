using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
//using System.ComponentModel.DataAnnotations.Schema;

namespace CampEvents.Database.Database
{
    public class PointPacketConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfigId { get; set; }
        [Required,MaxLength(100)]
        public string ConfigContent { get; set; }
        [Required]
        [Index("IX_PacketUnique", IsUnique = true, Order = 1)]
        public int PacketId { get; set; }
        [Required]
        public string PacketName { get; set; }
        [Required]
        public int NeedPoints { get; set; }
        [Required]
        [Index("IX_ShowIdLimit", IsUnique = true, Order = 1)]
        public int CampId { get; set; }
        [Required]
        public bool IsNotice { get; set; }
        [Required]
        [Index("IX_ShowIdLimit",IsUnique=true,Order=2)]
        public int ShowId { get; set; }
        [ForeignKey("CampId")]
        public CampConfig CampConfig { get; set; }
        public ICollection<PointPacketExchangeLog> PointPacketExchangeLogList { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "ConfigId", ConfigId);
            output.AppendFormat(":{0}={1}", "ConfigContent", ConfigContent);
            output.AppendFormat(":{0}={1}", "PacketId", PacketId);
            output.AppendFormat(":{0}={1}", "PacketName", PacketName);
            output.AppendFormat(":{0}={1}", "NeedPoints", NeedPoints);
            output.AppendFormat(":{0}={1}", "CampId", CampId);
            output.AppendFormat(":{0}={1}", "IsNotice", IsNotice);
            output.AppendFormat(":{0}={1}", "ShowId", ShowId);
            return output.ToString();
        }
    }
}
