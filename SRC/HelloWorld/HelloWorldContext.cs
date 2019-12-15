using System.Data.Common;
using System.Data.Entity;

namespace SRC.HelloWorld
{
    // we can also create our custom DB initializer, by inheriting one of the initializers 
    public class ContextInitializer : CreateDatabaseIfNotExists<HelloWorldContext>
    {
        protected override void Seed(HelloWorldContext context)
        {
            base.Seed(context);
        }
    }

    public class HelloWorldContext : DbContext
    {
        public HelloWorldContext(DbConnection con) : base(con, false)
        {
            Configuration.LazyLoadingEnabled = false;
            // Disable initializer
            System.Data.Entity.Database.SetInitializer<HelloWorldContext>(null);

            // System.Data.Entity.Database.SetInitializer<HelloWorldContext>(new DropCreateDatabaseIfModelChanges<HelloWorldContext>());
            // System.Data.Entity.Database.SetInitializer<HelloWorldContext>(new DropCreateDatabaseAlways<HelloWorldContext>());
            // System.Data.Entity.Database.SetInitializer<HelloWorldContext>(new ContextInitializer());
        }

        public DbSet<Data.Model.Cat> Cats { get; set; }
        public DbSet<Data.Model.Dog> Dogs { get; set; }
    }
}