
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UsersApi.Models
{
   [BsonIgnoreExtraElements]
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("username")]
        public string UserName { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
       [BsonElement("address")]
       public List<AddressList> Address { get; set; }
       
        [BsonElement("phone")]
        public string Phone { get; set; }
        [BsonElement("website")]
        public string Website { get; set; }
        [BsonElement("company")]
       
        public List<CompanyList> Company { get; set; }
    }
}
