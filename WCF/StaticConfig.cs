using System.Configuration;

namespace WCF
{
    public class StaticConfig : IStaticConfig
    {
        public StaticConfig()
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings["HelloWorld"];
            ConnectionString = connectionString?.ConnectionString;
        }

        public string ConnectionString { get; protected set; }
    }
}
