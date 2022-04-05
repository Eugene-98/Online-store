#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        public DbSet<ItemModel> ItemModel { get; set; }

        
    }

    public class UserContext : IdentityDbContext
    {
	    public UserContext(DbContextOptions<UserContext> options)
		    : base(options)
	    {
        }
        public DbSet<UserModel> UserModel { get; set; }
    }
}
