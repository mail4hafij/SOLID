using log4net;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using SRC.LIB;

namespace SRC.HelloWorld
{
    public class HelloWorldDatabaseService : DatabaseService, IHelloWorldDatabaseService
    {
        private readonly IStaticConfig _staticConfig;
        private static readonly ILog Log = LogManager.GetLogger(typeof(HelloWorldDatabaseService));

        public HelloWorldDatabaseService(IStaticConfig staticConfig)
        {
            _staticConfig = staticConfig;
        }

        public override string Name()
        {
            return "helloworld";
        }

        public override DbConnection Create()
        {
            return new SqlConnection(_staticConfig.ConnectionStringHelloWorld);
        }

        public override void Open(DbConnection con)
        {
            con.Open();
        }

        public override void Close(DbConnection con)
        {
            try
            {
                con?.Close();
            }
            catch (Exception exc)
            {
                Log.Error("Error when closing connection", exc);
            }
        }
    }
}
