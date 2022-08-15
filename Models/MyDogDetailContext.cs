using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MyDogDetail.Models;

namespace MyDogDetail.Models
{
    public class MyDogDetailContext : DbContext
    {

        public MyDogDetailContext (DbContextOptions<MyDogDetailContext> options): base(options)
        { }

        public DbSet<DogData> DogsData { get; set; } = null!;
    }
}
