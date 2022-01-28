using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    [Table("fueloption_tbl")]
    public class FuelOption
    {
        [Key]
        public int fueloption_id { get; set; }
        public string fueloption_name { get; set; }
        public ICollection<Model> Model { get; set; }
    }
}