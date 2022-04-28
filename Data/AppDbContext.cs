﻿

using ComputerStoreWebApi.Data.Model;
using ComputerStoreWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerStoreWebApi.Data
{
    public class AppDbContext:DbContext
    {
       public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DBSet<Category> Category { get; set; }
    }
}
