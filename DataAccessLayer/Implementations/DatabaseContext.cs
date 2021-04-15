using EcommerceAPI.DataAccessLayer.Interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DataAccessLayer.Implementations
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            this.DbConnection = this.Database.GetDbConnection();
        }

        public bool IsConnected { get { return this.Database.CanConnect(); } }
        public DbConnection DbConnection { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<UserInfo> userInfo { get; set; }
    }
}
