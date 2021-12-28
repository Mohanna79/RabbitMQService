using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NationalCopyService.Models
{
    public class NationalsService
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        [BsonElement("message")]
        public string Message { get; set; }
    }
}

