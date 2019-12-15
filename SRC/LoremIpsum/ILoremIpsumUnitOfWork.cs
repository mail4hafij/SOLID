using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SRC.LoremIpsum
{
    public interface ILoremIpsumUnitOfWork : IDisposable
    {
        LoremIpsumContext Context { get; set; }
        DbConnection Connection { get; set; }
        DbTransaction Transaction { get; set; }

        void Begin();
        void Rollback();
        void Commit(bool doNothing = false);

        DateTime Created { get; }

        void EnableSqlDebug();
        void DisableSqlDebug();

        /// <summary>
        /// Mechanism for adding commands to run immediately before commit is made on the transaction.
        /// This makes it possible to save rows in the database via the EF's normal workflow, so that foreign key constraints are met for the commands that are inserted.
        /// </summary>
        void AddActionToExecuteBeforeCommit(Action action);

        /// <summary>
        /// Mechanism for adding commands to run immediately after commit is made on the transaction, outside of the transaction.
        /// This makes it possible, for example, to delete documents on disk after removing rows from the database.
        /// </summary>
        void AddActionToExecuteAfterCommit(Action action);

        SqlCommand CreateSqlCommand(string query);

        void AddParameter(SqlCommand cmd, string name, SqlDbType type, object value);

        void AddParameter(SqlCommand cmd, string name, SqlDbType type, int size, object value);
    }
}
