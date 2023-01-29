using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countrofy.Configuration;

public class CountrofyMongoDbSettings
{
    public string ConnectionString { get; set; }
    public string Database { get; set; }
}
