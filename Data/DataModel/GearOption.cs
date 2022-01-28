using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    [Table("gearoption_tbl")]
    public class GearOption
    {
        [Key]
        public int gearoption_id { get; set; }
        public string gearoption_name { get; set; }
        public ICollection<Model> Model{ get; set; }
    }
}