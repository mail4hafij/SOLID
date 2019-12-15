using System.Data.Common;
using System.Data.Entity;

namespace SRC.LoremIpsum
{
    // we can also create our custom DB initializer, by inheriting one of the initializers 
    public class ContextInitializer : CreateDatabaseIfNotExists<LoremIpsumContext>
    {
        protected override void Seed(LoremIpsumContext context)
        {
            base.Seed(context);
        }
    }

    public class LoremIpsumContext : DbContext
    {
        public LoremIpsumContext(DbConnection con) : base(con, false)
        {
            Configuration.LazyLoadingEnabled = false;
            // Disable initializer
            System.Data.Entity.Database.SetInitializer<LoremIpsumContext>(null);
        }

        public DbSet<Data.Model.Tiger> Tigers { get; set; }
    }
}