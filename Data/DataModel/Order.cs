using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    [Table("order_tbl")]
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        [Required]
        public int order_number { get; set; }
        [Required]
        public bool order_isRental { get; set; }
        public int order_daycount { get; set; }
        public DateTime? order_pickupDate { get; set; }
        public DateTime? order_returnDate { get; set; }
        [Required]
        public decimal order_price { get; set; }
        [ForeignKey("Client")]
        public int? client_id { get; set; }
        [ForeignKey("Model")]
        public int? model_id { get; set; }

        [Required]
        public DateTime order_date { get; set; }
        public virtual Client Client { get; set; }
        public virtual Model Model { get; set; }


    }
}