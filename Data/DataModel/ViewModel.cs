using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoGaleri.Data.DataModel
{
    public class ViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Brand> Brands{ get; set; }
        public IPagedList<Model> PagedListModel { get; set; }
        public List<Model> Models{ get; set; }
        public List<FuelOption> FuelOptions { get; set; }
        public List<GearOption> GearOptions { get; set; }
        public List<MotorOption> MotorOptions { get; set; }
        public List<Support> Supports { get; set; }
        public List<Color> Colors { get; set; }
        public List<Client> Client { get; set; }
        public List<ClientAddress> ClientAddress{ get; set; }
        public List<Order> Order{ get; set; }

        public ViewModel()
        {
            Categories = new List<Category>();
            Models = new List<Model>();
            Brands = new List<Brand>();
            FuelOptions = new List<FuelOption>();
            GearOptions = new List<GearOption>();
            MotorOptions = new List<MotorOption>();
            Colors = new List<Color>();
            Client = new List<Client>();
            ClientAddress = new List<ClientAddress>();
        }
    }
    
}