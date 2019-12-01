using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZooStore.Entities;

namespace ZooStore.Models
{
    public class ZooContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<PetHome> PetHomes { get; set; }

        public ZooContext()
            : base(@"Server=SISSY-BLOODYRED;Database=ZooStoreDB; Trusted_Connection=true")
        {
            Users = this.Set<User>();
            Pets = this.Set<Pet>();
            Foods = this.Set<Food>();
            PetHomes = this.Set<PetHome>();
        }
    }
}