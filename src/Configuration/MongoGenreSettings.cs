using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Configuration;

public class MongoGenreSettings
{
    public string ConnectionString { get; set; } = null!;
    public string Database { get; set; } = null!;
    public string Collection { get; set; } = null!;
}
