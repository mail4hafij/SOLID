using log4net;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using SRC.LIB;

namespace SRC.LoremIpsum
{
    public class LoremIpsumDatabaseService : DatabaseService, ILoremIpsumDatabaseService
    {
        private readonly IStaticConfig _staticConfig;
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoremIpsumDatabaseService));

        public LoremIpsumDatabaseService(IStaticConfig staticConfig)
        {
            _staticConfig = staticConfig;
        }

        public override string Name()
        {
            return "loremipsum";
        }

        public override DbConnection Create()
        {
            return new SqlConnection(_staticConfig.ConnectionStringLoremIpsum);
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
