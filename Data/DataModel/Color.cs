using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    [Table("color_tbl")]
    public class Color
    {
        [Key]
        public int color_id { get; set; }
        public string color_name { get; set; }
        public ICollection<Model> Model { get; set; }
    }
}