using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //TODO: MysteryBooks

            //TODO: MysteryGenre
        }
    }
}
