using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    [Table("categorydetails")]
        public class Category
        {
            [Key]
            public int id { get; set; }
            public string section { get; set; }
            public string type { get; set; }
            public int categID { get;  set; }
            public bool check { get; set; }
        }
        [Table("cateringdetails")]
        public class Catering
        {
            [Key]
            public int id { get; set; }
            [ForeignKey("category")]
            public int categID { get; set; }
            public Category category { get; set; }
            public string name { get; set; }

            public int people { get; set; }

            public string items { get; set; }
            public string image { get; set; }
            public float cost { get; set; }
        

        }
        [Table("deliverydetails")]
        public class Delivery
        {
            [Key]
            public int id { get; set; }
            public string datetime { get; set; }
            public string paymenttye { get; set; }
        }
        public class CateringDatabaseContext : DbContext

        {
            public DbSet<Category> c { get; set; }
            public DbSet<Catering> ca { get; set; }
            public DbSet<Delivery> d { get; set; }


        }
    }

