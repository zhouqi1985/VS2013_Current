using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CampEvents.Database.Database
{
    public class RankListTop20
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long AvatarId { get; set; }
        [Required,MaxLength(100)]
        public string AvatarName { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required,MaxLength(50)]
        public string AreaName { get; set; }
        [Required]
        public int TotalGetPoints { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]
        public int RankOrder { get; set; }
        [Required]
        public DateTime CutOffDate { get; set; }
        [Required]
        public int CampId { get; set; }
        [ForeignKey("CampId")]
        public CampConfig CampConfig { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "AreaId", AreaId);
            output.AppendFormat(":{0}={1}", "AreaName", AreaName);
            output.AppendFormat(":{0}={1}", "TotalGetPoints", TotalGetPoints);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            output.AppendFormat(":{0}={1}", "RankOrder", RankOrder);
            output.AppendFormat(":{0}={1}", "CutOffDate", CutOffDate);
            output.AppendFormat(":{0}={1}", "CampId", CampId);
            return output.ToString();
        }
    }
}
