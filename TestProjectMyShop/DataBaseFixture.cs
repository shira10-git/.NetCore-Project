using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMyShop
{
    public class DatabaseFixture : IDisposable
    {
        public ShopDb325338135Context Context { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<ShopDb325338135Context>()
                .UseSqlServer("Server=srv2\\pupils;Database=Tests_326238102;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
            Context = new ShopDb325338135Context(options);
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
