using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoGaleri.Data.DataModel
{
    [Table("brand_tbl")]
    public class Brand
    {
        [Key]
        public int brand_id { get; set; }
        [ForeignKey("Category")]
        public int? category_id { get; set; }
        [Required]
        public string brand_name { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Model> Model { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}