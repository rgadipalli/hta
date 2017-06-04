using HTA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HTA.ViewModels
{
    [NotMapped]
    public class BookingVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int DevoteeId { get; set; }
        [Column("DevoteeMemID")]
        public int ServiceForDevoteeId { get; set; }
        public int ServiceID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ServiceDate { get; set; }
        public int? ServiceTimeID { get; set; }
        public int? PriestI { get; set; }
        public int? PriestII { get; set; }
        public int? PriestIII { get; set; }
        public int? PriestAlloted { get; set; }
        public int? NoUnits { get; set; }
        [Column(TypeName = "money")]
        public decimal Service_Fee { get; set; }

        public virtual Devotee Devotee { get; set; }
        public virtual int ServiceGroupID { get; set; }
        public virtual ServiceGroup ServiceGroup { get; set; }
        public virtual Service Service { get; set; }
    }
}
