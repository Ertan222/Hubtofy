using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Countrofy.Models;

public class Country
{
    public Country(
        string id,
        string name,
        long population,
        int landArea,
        int density)
    {
        Id = id;
        Name = name;
        Population = population;
        LandArea = landArea;
        Density = density;
    }
    
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("population")]
    public long Population { get; set; }
    [BsonElement("land_area")]
    public int LandArea { get; set; }
    [BsonElement("density")]
    public int Density{ get; set; }
}
