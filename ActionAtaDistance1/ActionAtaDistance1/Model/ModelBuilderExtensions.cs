using System;
using Microsoft.EntityFrameworkCore;

namespace ActionAtaDistance1.Model
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this  ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { ID = 1, FirstName = "Ellis", LastName = "Peters", DateOfBirth = new DateTime(1913, 9, 28)},
                new Author { ID = 2, FirstName = "Agatha", LastName = "Christie", DateOfBirth = new DateTime(1890, 9, 15)},
                new Author { ID = 3, FirstName = "Arthur", LastName = "Conan", DateOfBirth = new DateTime(1859, 5, 22)}
                );

            modelBuilder.Entity<MysteryBook>().HasData(
                new MysteryBook { ID = 1, AuthorID = 3, BookTitle = "A Study in Scarlet", PublishDate = new DateTime(1887, 1, 1) }, 
                new MysteryBook { ID = 2, AuthorID = 2, BookTitle = "The Mysterious Affair at Styles", PublishDate = new DateTime(1920, 10, 1) }, 
                new MysteryBook { ID = 3, AuthorID = 1, BookTitle = "A Morbid Taste for Bones", PublishDate = new DateTime(1977, 8, 25) }, 
                new MysteryBook { ID = 4, AuthorID = 1, BookTitle = "One Corpse Too Many", PublishDate = new DateTime(1979, 7, 19) }, 
                new MysteryBook { ID = 5, AuthorID = 1, BookTitle = "The Leper of Saint Giles", PublishDate = new DateTime(1981, 8, 1) }, 
                new MysteryBook { ID = 6, AuthorID = 2, BookTitle = "The Murder of Roger Ackroyd", PublishDate = new DateTime(1926, 6, 1) }, 
                new MysteryBook { ID = 7, AuthorID = 2, BookTitle = "Murder on the Orient Express", PublishDate = new DateTime(1934, 1, 1) },
                new MysteryBook { ID = 8, AuthorID = 3, BookTitle = "The Hound of the Baskervilles", PublishDate = new DateTime(1914, 1, 1) }
                );

            modelBuilder.Entity<MysteryGenre>().HasData(
                new MysteryGenre { ID = 1, Description = "Mysteries - Golden Age" },
                new MysteryGenre { ID = 2, Description = "Mysteries - Historial" }
                );
        }
    }
}
