using Microsoft.EntityFrameworkCore;
using SocialNetData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetData
{
    /// <summary>
    /// База данных
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
        }
    }
}
