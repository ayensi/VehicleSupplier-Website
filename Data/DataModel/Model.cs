using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoGaleri.Data.DataModel
{
    [Table("model_tbl")]
    public class Model
    {
        [Key]
        public int model_id { get; set; }
        [ForeignKey("Category")]
        public int? category_id { get; set; }
        [ForeignKey("Brand")]
        public int? brand_id { get; set; }
        [ForeignKey("FuelOption")]
        public int? fueloption_id { get; set; }
        [ForeignKey("MotorOption")]
        public int? motoroption_id { get; set; }
        [ForeignKey("GearOption")]
        public int? gearoption_id { get; set; }
        [ForeignKey("Color")]
        public int? color_id { get; set; }
        [Required]
        public string model_name { get; set; }
        [Required]
        public string model_description { get; set; }
        [Required]
        public decimal model_price { get; set; }
        public int model_quantity { get; set; }
        [Required]
        public string model_image { get; set; }
       
        [Required]
        public bool model_isUsed { get; set; }
        [Required]
        public bool model_isRentable { get; set; }
        public int model_age { get; set; }
        public double model_km { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual GearOption GearOption { get; set; }
        public virtual MotorOption MotorOption { get; set; }
        public virtual FuelOption FuelOption { get; set; }
        public virtual Color Color { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Order> Order { get; set; }
        public IEnumerable<SelectListItem> BrandList { get; set; }
        public IEnumerable<SelectListItem> FuelOptionList { get; set; }
        public IEnumerable<SelectListItem> GearOptionList { get; set; }
        public IEnumerable<SelectListItem> MotorOptionList { get; set; }
        public IEnumerable<SelectListItem> ColorList { get; set; }
    }
}