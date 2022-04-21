using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class AddressList
    {
        
        [BsonElement("street")]
        public string Street { get; set; }
        [BsonElement("suite")]
        public string Suite { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("zipcode")]
        public string ZipCode { get; set; }
        [BsonElement("geo")]
        public List<GeoList> Geo { get; set; }


    }
}
