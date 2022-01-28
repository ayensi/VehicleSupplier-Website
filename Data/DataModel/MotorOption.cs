using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    
    [Table("motoroption_tbl")]
    public class MotorOption
    {
        [Key]
        public int motoroption_id { get; set; }
        public string motoroption_name { get; set; }
        public ICollection<Model> Model { get; set; }
    }
}