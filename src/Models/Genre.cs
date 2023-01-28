using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace src.Models;

public class Genre
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("name")]
    [Display(Name = "Genre"),Required(ErrorMessage = "{0} is can't be empty"), StringLength(14,MinimumLength = 4, ErrorMessage = "{0} needs to be between {2} - {1}")]
    public string Name { get; set; }
}
