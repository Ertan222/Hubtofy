using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace src.Models;

public class Occupation {

	[BsonId]
	[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
	public string Id {get; set; } = "";

	[BsonElement("name")]
	[Display(Name = "Name"), Required(ErrorMessage = "{0} is required for occupation"),StringLength(14,MinimumLength = 6, ErrorMessage = "{0} needs to be between {2} - {1}")]
	public string Name {get; set; }
}

