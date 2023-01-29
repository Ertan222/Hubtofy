using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Countrofy.Models;

public class Country
{
    public Country()
    {
    }

    public Country(
        string id,
        string name)
    {
        Id = id;
        Name = name;
    }
    
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
}
