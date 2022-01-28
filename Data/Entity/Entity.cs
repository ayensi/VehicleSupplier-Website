using OtoGaleri.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OtoGaleri.Data.Entity
{
    public class Entity : DbContext
    {
        public Entity() : base("DataBaseGaleri")
        {


        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<FuelOption> FuelOption { get; set; }
        public DbSet<GearOption> GearOption { get; set; }
        public DbSet<MotorOption> MotorOption { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Support> Support { get; set; }
        public DbSet<ClientAddress> ClientAddress{ get; set; }
    }
}