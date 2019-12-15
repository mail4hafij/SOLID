using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using SRC.LIB;

namespace SRC.LoremIpsum
{
    public class LoremIpsumUnitOfWork : ILoremIpsumUnitOfWork
    {
        // public static ILog _sqlLogger = LogManager.GetLogger("EF.Sql");

        private bool _disposed;
        private bool _commitOrRollbackPerformed;
        private ILoremIpsumDatabaseService _databaseService { get; set; }
        private LoremIpsumContext _context;
        private readonly List<Action> _actionsToExecuteBeforeCommit = new List<Action>();
        private readonly List<Action> _actionsToExecuteAfterCommit = new List<Action>();


        public DbConnection Connection { get; set; }
        public DbTransaction Transaction { get; set; }
        public LoremIpsumContext Context
        {
            get
            {
                if (_context == null)
                {
                    throw new Exception("You must start a transaction, use UnitOfWork.Begin()");
                }
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        public LoremIpsumUnitOfWork(ILoremIpsumDatabaseService databaseService)
        {
            _disposed = false;
            _databaseService = databaseService;
        }


        public void Begin()
        {
            Connection = _databaseService.Create();
            _databaseService.Open(Connection);
            Transaction = _databaseService.Begin(Connection);
            Context = new LoremIpsumContext(Connection);
            Context.Database.UseTransaction(Transaction);
        }

        public void Rollback()
        {
            if (_commitOrRollbackPerformed)
            {
                return;
            }

            _databaseService.Rollback(Transaction);
            _databaseService.Close(Connection);
            _commitOrRollbackPerformed = true;
        }

        public void Commit(bool doNothing = false)
        {
            if (doNothing && !_commitOrRollbackPerformed)
            {
                _databaseService.Close(Connection);
                _commitOrRollbackPerformed = true;
            }

            if (_commitOrRollbackPerformed)
            {
                return;
            }

            Context.SaveChanges();

            // now that we shouted at Context.SaveChanges () has EF created rows in the database,
            // and we can run commands that have relationships with these rows
            ExecuteActionsBeforeCommit();

            _databaseService.Commit(Transaction);
            _databaseService.Close(Connection);

            ExecuteActionsAfterCommit();

            _commitOrRollbackPerformed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (!_commitOrRollbackPerformed)
                    {
                        Rollback();
                    }
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public DateTime Created { get; }

        public void EnableSqlDebug()
        {
            //Context.Database.Log = s => _sqlLogger.Debug(s);
        }

        public void DisableSqlDebug()
        {
            Context.Database.Log = null;
        }

        public void AddActionToExecuteBeforeCommit(Action action)
        {
            _actionsToExecuteBeforeCommit.Add(action);
        }

        public void AddActionToExecuteAfterCommit(Action action)
        {
            _actionsToExecuteAfterCommit.Add(action);
        }

        public SqlCommand CreateSqlCommand(string query)
        {
            return new SqlCommand(
                query,
                (SqlConnection)Connection,
                (SqlTransaction)Transaction);
        }

        public void AddParameter(SqlCommand cmd, string name, SqlDbType type, object value)
        {
            cmd.Parameters.Add(name, type).Value = value ?? DBNull.Value;
        }

        public void AddParameter(SqlCommand cmd, string name, SqlDbType type, int size, object value)
        {
            cmd.Parameters.Add(name, type, size).Value = value ?? DBNull.Value;
        }


        private void ExecuteActionsBeforeCommit()
        {
            foreach (var action in _actionsToExecuteBeforeCommit)
            {
                action();
            }
        }

        private void ExecuteActionsAfterCommit()
        {
            foreach (var action in _actionsToExecuteAfterCommit)
            {
                action();
            }
        }
    }
}
