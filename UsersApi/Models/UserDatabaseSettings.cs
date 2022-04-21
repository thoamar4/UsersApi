using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class UserDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
        public string UsersCollectionName { get; set; } 
    }
}
