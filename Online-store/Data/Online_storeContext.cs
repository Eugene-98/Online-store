#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_store.Models;

namespace Online_store.Data
{
    public class Online_storeContext : DbContext
    {
        public Online_storeContext (DbContextOptions<Online_storeContext> options)
            : base(options)
        {
        }

        public DbSet<Online_store.Models.ItemModel> ItemModel { get; set; }

        public DbSet<Online_store.Models.UserModel> UserModel { get; set; }
    }
}
