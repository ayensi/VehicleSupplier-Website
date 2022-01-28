using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    [Table("category_tbl")]
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        [Required]
        public string category_name { get; set; }
        public ICollection<Brand> Brand { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Model> Model { get; set; }
    }
   
}