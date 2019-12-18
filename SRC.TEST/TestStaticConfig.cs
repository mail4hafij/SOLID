using System.Configuration;

namespace SRC.TEST
{
    public class TestStaticConfig : IStaticConfig
    {
        public TestStaticConfig()
        {
            ConnectionStringHelloWorld = "Data Source=.;Initial Catalog=helloworld;Integrated Security=true;";
            ConnectionStringLoremIpsum = "Data Source=.;Initial Catalog=loremipsum;Integrated Security=true;";
        }

        public string ConnectionStringHelloWorld { get; protected set; }

        public string ConnectionStringLoremIpsum { get; protected set; }
    }
}
