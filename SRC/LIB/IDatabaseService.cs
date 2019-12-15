using System.Data.Common;

namespace SRC.LIB
{
    public interface IDatabaseService
    {
        string Name();
        DbConnection Create();
        void Open(DbConnection con);
        void Close(DbConnection con);
        DbTransaction Begin(DbConnection con);
        void Commit(DbTransaction tx);
        void Rollback(DbTransaction tx);
    }
}
