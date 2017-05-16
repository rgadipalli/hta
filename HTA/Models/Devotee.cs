using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HTA.Models
{
    [Table("tbl_devotee", Schema="dbo")]
    public class Devotee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Devotee_ID { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public bool? TemporaryPassord { get; set; }
        public string Home_Phone { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public bool? Is_Company { get; set; }
        public string Company_Name { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public int? StateID { get; set; }
        public string Zip { get; set; }
        public string Work_Phone { get; set; }
        public string Work_Phone_Ext { get; set; }
        public string Cell_Phone { get; set; }
        public string Fax { get; set; }
        public string Sex { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? Wedding_Date { get; set; }
        public int? MemberType_ID { get; set; }
        public int? Gothram_ID { get; set; }
        public int? Star_ID { get; set; }
        public bool? Is_Active { get; set; }
        public bool? Is_Mailing { get; set; }
        public bool? Is_Emailing { get; set; }
        public bool? Is_ProfileComplete { get; set; }
        public DateTime? Last_Modified { get; set; }
        public string Who_Modified { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Last_LoggedIn { get; set; }

    }
}
