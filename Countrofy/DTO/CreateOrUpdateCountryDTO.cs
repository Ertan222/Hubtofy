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
}
