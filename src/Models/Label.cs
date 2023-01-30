using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace src.Models;

public class Label
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("parent")]
    public string Parent { get; set; }
    [BsonElement("founded")]
    public DateTime Founded { get; set; }
    [BsonElement("country_of_origin")]
    public string CountryOfOrigin { get; set; }
    [BsonElement("location")]
    public string Location { get; set; }
    [BsonElement("website")]
    public string Website { get; set; }
    [BsonElement("defunct")]
    public bool Defunct { get; set; }
}
