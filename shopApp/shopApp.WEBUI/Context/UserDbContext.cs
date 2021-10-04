
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shopApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.Context
{
    public class UserDbContext:IdentityDbContext<User>
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options){}
        
    }
}
