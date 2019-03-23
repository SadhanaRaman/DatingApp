using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext: DbContext
    {
        //Create a constructor and chain to base constructor using base keyword
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        //Value is the name of the model, Values is the table name in DB
        public DbSet<Value> Values {get;set;}
        
    }
}