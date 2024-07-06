using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataContext
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            var connectionString = $"Filename={GetDatabasePath()}"; // Adjust if necessary
            optionsBuilder.UseSqlite(connectionString);

            return new Context(optionsBuilder.Options);
        }

        private static string GetDatabasePath()
        {
            var databaseName = "db.db3";
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), databaseName);
        }
    }
}
