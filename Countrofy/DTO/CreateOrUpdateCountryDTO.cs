using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Countrofy.DTO;

public class CreateOrUpdateCountryDTO
{
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("population")]
    public long Population { get; set; }
    [BsonElement("land_area")]
    public int LandArea { get; set; }
    [BsonElement("density")]
    public int Density{ get; set; }
}
