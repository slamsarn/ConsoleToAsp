using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Web.Models
{
    /// <summary>
    /// This class is used to initialize the database with test values.
    /// If there is any data in the database it wont run. (See row 22)
    /// </summary>
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }

            if (context.Message.Any())
            {
                return;   // DB has been seeded
            }

            context.Message.AddRange(
                 new Message
                 {
                     TimeStamp = DateTime.UtcNow,
                     MsgText = "Hello World"
                 },
                 new Message
                 {
                     TimeStamp = DateTime.UtcNow,
                     MsgText = "Test"
                 }
            );
            context.SaveChanges();
        }
    }
}