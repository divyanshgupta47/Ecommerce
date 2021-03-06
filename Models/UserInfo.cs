using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Models
{
    [Keyless]
    public class UserInfo
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string EmailId { get; set; }
    }
}
