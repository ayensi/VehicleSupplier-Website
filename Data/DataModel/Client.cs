using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.DataModel
{
    [Table("client_tbl")]
    public class Client
    {
        [Key]
        public int client_id { get; set; }

        public string client_name { get; set; }

        public string client_lastname { get; set; }

        public string client_phone { get; set; }
        [Required]
        public string client_email { get; set; }
        [Required]
        public string client_password { get; set; }

        public string client_identity_number { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<ClientAddress> ClientAdress{ get; set; }
    }
}