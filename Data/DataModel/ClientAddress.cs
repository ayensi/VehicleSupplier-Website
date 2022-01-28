using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    [Table("clientaddress_tbl")]
    public class ClientAddress
    {
        [Key]
        public int clientaddress_id { get; set; }
        [ForeignKey("Client")]
        public int? client_id { get; set; }
        [Required]
        public string clientaddress_cityname { get; set; }
        [Required]
        public string clientaddress_districtname { get; set; }
        [Required]
        public string clientaddress_neighborhoodname { get; set; }
        [Required]
        public string clientaddress_streetname { get; set; }
        [Required]
        public string clientaddress_apartmentnumber { get; set; }
        [Required]
        public string clientaddress_buildingnumber { get; set; }
        [Required]
        public string clientaddress_addressdescription { get; set; }
        public virtual Client Client{ get; set; }
    }
}