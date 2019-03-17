using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Saints and Soldiers",
                        ReleaseDate = DateTime.Parse("2004-08-06"),
                        Genre = "Drama",
                        Rating = "PG-13",
                        Price = 1.30M
                    },

                    new Movie
                    {
                        Title = "The Best two Years",
                        ReleaseDate = DateTime.Parse("2001-01-01"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 0.40M
                    },

                    new Movie
                    {
                        Title = "Johny Lingo",
                        ReleaseDate = DateTime.Parse("1969-01-01"),
                        Genre = "Short Film",
                        Rating = "G",
                        Price = 8.00M
                    },

                    new Movie
                    {
                        Title = "Ephraim's Rescue",
                        ReleaseDate = DateTime.Parse("2013-5-31"),
                        Genre = "Drama",
                        Rating = "G",
                        Price = 1.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
