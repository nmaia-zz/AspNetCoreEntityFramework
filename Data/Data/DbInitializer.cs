using Data.Context;
using Domain.Entities;
using System;
using System.Linq;

namespace Data.Data
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            var context = new AppDbContext();
            context.Database.EnsureCreated();

            if (context.Clients.Any())
            {
                return; //data already exists in database!
            }

            var clients = new Client[]
            {
                new Client { Id = new Guid("5fb33c76-bd47-4ab3-abd6-2a677cd92ad0"), Name = "Hyuga Minnato" }
            };

            context.Clients.AddRange(clients);
            context.SaveChanges();
        }
    }
}
