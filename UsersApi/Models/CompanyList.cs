using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class CompanyList
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("catchPhrase")]
        public string CatchPhrase { get; set; }
        [BsonElement("bs")]
        public string Bs { get; set; }
    }
}
