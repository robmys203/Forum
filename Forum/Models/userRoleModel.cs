using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class userRoleModel
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public List<string> userRoles { get; set; }
        public string userRoleToAdd { get; set; }
        public string userRoleToDelete{ get; set; }

    }
}
