using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    [Table("admin_tbl")]
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }
        [Required]
        public string admin_username { get; set; }
        [Required]
        public string admin_password { get; set; }
    }
}