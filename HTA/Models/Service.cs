using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HTA.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Service_ID { get; set; }
        public string Service_Desc { get; set; }
        [Column(TypeName = "money")]
        public decimal Fee { get; set; }
        public bool? Is_Outside { get; set; }
        public bool? Is_Web_Avail { get; set; }
        public bool? Is_Quick { get; set; }
        public int? CommitteeType_ID { get; set; }
        public bool? Is_Priest { get; set; }
        public bool? Is_IT_Exempt { get; set; }
        public bool? Is_Active { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Created { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Last_Modified { get; set; }
        public string Who_Modified { get; set; }
        public string Notes { get; set; }
        public bool? EmailReceipt { get; set; }
        public string ToEmailAddress { get; set; }
        public string EmailSubject { get; set; }

        public int? ServiceGroup_id { get; set; }
        [ForeignKey("ServiceGroup_id")]
        public ServiceGroup ServiceGroup { get; set; }

    }
}
