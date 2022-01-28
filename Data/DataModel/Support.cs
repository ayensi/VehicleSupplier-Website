using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    [Table("support_tbl")]
    public class Support
    {
        [Key]
        public int support_id { get; set; }
        [Required]
        public string support_name { get; set; }
        [Required]
        public string support_email { get; set; }
        [Required]
        public string support_message { get; set; }
        [Required]
        public DateTime support_date { get; set; }
    }
}