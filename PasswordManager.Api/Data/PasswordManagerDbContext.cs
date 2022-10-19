using System;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Api.Entities;

namespace PasswordManager.Api.Data
{
    public class PasswordManagerDbContext:DbContext
    {
        /// <summary>
        /// On Configure override method to configure the data in memory functionality for the DBContext
        /// </summary>
        /// <param name="optionsBuilder">Receive the optionBuilder by dependency injection</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PasswordManagerDb");
        }

        /// <summary>
        /// The Users DbSet for model the corresponding table 
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// The Passwords DbSet for model the corresponding table 
        /// </summary>
        public DbSet<Password> Passwords { get; set; }

        /// <summary>
        /// The Folders DbSet for model the corresponding table 
        /// </summary>
        public DbSet<Folder> Folders { get; set; }
    }
}

