using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using secondapp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace secondapp.Data
{
    public class BookAppDbContext : IdentityDbContext<User>
    {

        public DbSet<Story> Stories { get; init; }

        public DbSet<Genre> Genres { get; init; }

        public DbSet<Book> Books { get; init; }

        public DbSet<Event> Events { get; init; }

        public DbSet<EventUser> EventUsers { get; init; }

        public DbSet<FinishedStory> FinishedStories { get; init; }

        public DbSet<FavouriteItem> FavouriteItems { get; init; }

        public DbSet<FinshedBook> FinshedBooksUs { get; init; }

        public DbSet<Post> Posts { get; init; }


        public BookAppDbContext(DbContextOptions<BookAppDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Story>()
                .HasOne(s => s.Genre)
                .WithMany(s => s.Stories)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<EventUser>()
                .HasKey(x => new { x.UserId, x.EventId });

            builder.Entity<FinshedBook>()
                .HasKey(x => new { x.UserId ,x.StoryId});




            base.OnModelCreating(builder);
        }

    }
}
