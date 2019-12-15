using log4net;
using System;
using System.Data.Common;

namespace SRC.LIB
{
    public abstract class DatabaseService : IDatabaseService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DatabaseService));

        public abstract DbConnection Create();
        public abstract string Name();
        public abstract void Open(DbConnection con);
        public abstract void Close(DbConnection con);

        public DbTransaction Begin(DbConnection con)
        {
            return con.BeginTransaction();
        }

        public void Commit(DbTransaction tx)
        {
            if (tx != null)
            {
                try
                {
                    tx.Commit();
                }
                catch (Exception exc)
                {
                    Log.Error("Error when commit", exc);
                }
            }
        }

        public void Rollback(DbTransaction transaction)
        {
            if (transaction != null)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exc)
                {
                    Log.Error("Error when rollback", exc);
                }
            }
        }
    }
}
