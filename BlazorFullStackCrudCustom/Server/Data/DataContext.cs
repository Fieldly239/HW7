namespace BlazorFullStackCrudCustom.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>().HasData(
                new Vote { Id = 1, Name = "1" },
                new Vote { Id = 2, Name = "2" },
                new Vote { Id = 3, Name = "3" },
                new Vote { Id = 4, Name = "4" },
                new Vote { Id = 5, Name = "5" }

            );

            modelBuilder.Entity<Appilcation>().HasData(
                new Appilcation { Id = 1, Name = "Smart Care", Description = "" },
                new Appilcation { Id = 2, Name = "IT Asset Manager", Description = "" }
            );

            modelBuilder.Entity<FeedBack>().HasData(
                new FeedBack
                {
                    Id = 1,
                    AppilcationName = "Smart Care",
                    Description = "Error 404",
                    
                    VoteId = 1,
                    AppilcationId = 1
                },
                new FeedBack
                {
                    Id = 2,
                    AppilcationName = "Chat Bot",
                    Description = "Error 405",
                
                    VoteId = 2,
                    AppilcationId = 2
                }
           );
        }

        public DbSet<FeedBack> FeedBackes { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Appilcation> Appilcations { get; set; }
    }
}
