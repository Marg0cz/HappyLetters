using HappyLetters.Entities;

using Microsoft.EntityFrameworkCore;

namespace HappyLetters.DbContexts;

public class RiddlesContext : DbContext
{
    //public DbSet<ImageRiddle> ImageRiddles { get; set; }
    public DbSet<LetterRiddle> LetterRiddles { get; set; }

    public RiddlesContext(DbContextOptions<RiddlesContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {



        //modelBuilder.Entity<ImageRiddle>()
        //    .HasData(
        //    new ImageRiddle
        //    {
        //        Id = 1,
        //        Solution = "Auto",
        //        ImagePath = "C:\\workspace\\HappyLetters\\HappyLetters\\Media\\car.png"
        //    },
        //    new ImageRiddle
        //    {
        //        Id = 2,
        //        Solution = "Woda",
        //        ImagePath = "C:\\workspace\\HappyLetters\\HappyLetters\\Media\\water.jpg"
        //    });

        IEnumerable<LetterRiddle> data = new LetterRiddle[]
        {
            new()
            {
                Guid = Guid.NewGuid(),
                Content = "A",
                Solution = "A"
            },
        };



        modelBuilder.Entity<LetterRiddle>()
            .HasData(data);
    }
}
