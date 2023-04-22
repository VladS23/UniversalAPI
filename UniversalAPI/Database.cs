using Microsoft.EntityFrameworkCore;

namespace UniversalAPI
{
        public class Database
        {
            public static DatabaseContext db = null;
            public Database()
            {
                if (db == null)
                {
                    db = new DatabaseContext();

                    db.Database.EnsureCreated();
                    db.Tokens.Load();
                }
            }
        }

        public class DatabaseContext : DbContext
        {
            public DatabaseContext() : base()
            {
                this.Database.EnsureCreated();
                this.SaveChangesFailed += SaveFailed;
            }

            public void SaveFailed(object obj, SaveChangesFailedEventArgs failedEventArgs)
            {
                Console.WriteLine(failedEventArgs);
            }

            public DbSet<Token> Tokens { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                var di = new DirectoryInfo(Directory.GetCurrentDirectory());
                var root = di.Parent;
                var dbPath = root != null ? root.ToString() : Directory.GetCurrentDirectory();
                options.UseSqlite($"Data Source={Path.Combine(dbPath, "api.db")}");
            }

        }
    }
