using System.Configuration;

namespace SRC.TEST
{
    public class TestStaticConfig : IStaticConfig
    {
        public TestStaticConfig()
        {
            var helloWorld = ConfigurationManager.ConnectionStrings["HelloWorld"];
            ConnectionStringHelloWorld = helloWorld?.ConnectionString;

            var loremIpsum = ConfigurationManager.ConnectionStrings["LoremIpsum"];
            ConnectionStringLoremIpsum = loremIpsum?.ConnectionString;
        }

        public string ConnectionStringHelloWorld { get; protected set; }

        public string ConnectionStringLoremIpsum { get; protected set; }
    }
}
