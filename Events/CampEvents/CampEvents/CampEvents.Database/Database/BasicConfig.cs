using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CampEvents.Database.Database
{
    public class BasicConfig
    {
        //阵营相差人数上限，阵营人数调整起始值，获胜礼包，参与礼包
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BasicId { get; set; }
        [Required,MaxLength(50)]
        public string ConfigName { get; set; }
        [Required]
        public int ConfigValue { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "BasicId", BasicId);
            output.AppendFormat(":{0}={1}", "ConfigName", ConfigName);
            output.AppendFormat(":{0}={1}", "ConfigValue", ConfigValue);
            return output.ToString();
        }
    }
}
