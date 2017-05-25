using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTA.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        public int DevoteeId { get; set; }
        [Column("DevoteeMemID")]
        public int ServiceForDevoteeId { get; set; }
        public Devotee Devotee { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsPaid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? ReceiptId { get; set; }
        

        public ICollection<BookingItem> BookingItems { get; set; }

    }
}
