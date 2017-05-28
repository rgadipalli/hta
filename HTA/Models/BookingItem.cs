using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HTA.Models
{
    public class BookingItem
    {

        public int BookingItemId { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
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

    }
}
