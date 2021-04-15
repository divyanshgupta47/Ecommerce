using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DataAccessLayer.Interfaces
{
    public interface IDatabaseContext
    {
        bool IsConnected { get; }
        DbSet<Users> users { get; set; }

        public DbConnection DbConnection { get; set; }

        DbSet<UserInfo> userInfo { get; set; }
    }
}
