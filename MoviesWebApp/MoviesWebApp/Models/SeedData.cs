using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesWebApp.Data;
using MoviesWebApp.Models;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesWebAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<MoviesWebAppContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                #region snippet1
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Movie1",
                        ReleaseDate = DateTime.Parse("2023-02-09"),
                        Genre = "Action",
                        Price = 19.50M,
                        Rating = "A"
                    },
                #endregion

                    new Movie
                    {
                        Title = "Movie2",
                        ReleaseDate = DateTime.Parse("2023-01-03"),
                        Genre = "Drama",
                        Price = 20.30M,
                        Rating = "B"
                    },

                    new Movie
                    {
                        Title = "TitleMov",
                        ReleaseDate = DateTime.Parse("2023-12-07"),
                        Genre = "Thriller",
                        Price = 13.23M,
                        Rating = "C"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}