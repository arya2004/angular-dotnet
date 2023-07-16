using Core.Models;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Identity
{
    //app user adds our new properties
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        //two db context, so specity the type
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }
        //use this else issue
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            base.OnModelCreating(builder);
           
        }
    
    }
}
