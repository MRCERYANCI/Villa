﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.EntityLayer.Entities;

namespace Villa.DataAccessLayer.Context
{
    public class VillaContext : IdentityDbContext<AppUser,AppRole, ObjectId>
    {
        public VillaContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Counter> Counters { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Banner>().ToCollection("Banners");
            modelBuilder.Entity<Contact>().ToCollection("Contacts");
            modelBuilder.Entity<Counter>().ToCollection("Counters");
            modelBuilder.Entity<Deal>().ToCollection("Deals");
            modelBuilder.Entity<Message>().ToCollection("Messages");
            modelBuilder.Entity<Product>().ToCollection("Products");
            modelBuilder.Entity<Quest>().ToCollection("Quests");
            modelBuilder.Entity<Video>().ToCollection("Videos");
            modelBuilder.Entity<SocialMedia>().ToCollection("SocialMedias");
        }
    }
}
