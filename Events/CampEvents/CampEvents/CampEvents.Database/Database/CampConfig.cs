using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CampEvents.Database.Database
{
    public class CampConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CampId { get; set; }
        [Required,MaxLength(50)]
        public string CampName { get; set; }
        [Required]
        public int CurrentPeople { get; set; }
        [Required]
        public long CurrentPoints { get; set; }
        public ICollection<PointPacketConfig> PointPacketConfigList { get; set; }
        public ICollection<RankListTop20> RankListTop20List { get; set; }
        public ICollection<UserCampLog> UserCampLogList { get; set; }
        public ICollection<Wallet> WalletList { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "CampId", CampId);
            output.AppendFormat(":{0}={1}", "CampName", CampName);
            output.AppendFormat(":{0}={1}", "CurrentPeople", CurrentPeople);
            output.AppendFormat(":{0}={1}", "CurrentPoints", CurrentPoints);
            return output.ToString();
        }
    }


}
