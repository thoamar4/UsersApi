using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class GeoList
    {
        [BsonElement("lat")]
        public string Lat { get; set; }
        [BsonElement("lng")]
        public string Lng { get; set; }
       
    }
}
