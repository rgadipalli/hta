using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTA.Models
{
    [Table("tbl_servicegroup", Schema ="dbo")]
    public class ServiceGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceGroup_ID { get; set; }
        public string ServiceGroup_Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_Created { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Last_Modified { get; set; }
        public string Who_Modified { get; set; }
        public bool? Is_Active { get; set; }

        public ICollection<Service> Services { get; set; }

    }
}
