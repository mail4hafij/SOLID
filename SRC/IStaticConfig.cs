using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC
{
    public interface IStaticConfig
    {
        string ConnectionStringHelloWorld { get; }

        string ConnectionStringLoremIpsum { get; }
    }
}
