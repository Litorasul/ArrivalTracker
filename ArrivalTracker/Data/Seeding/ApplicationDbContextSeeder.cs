﻿using ArrivalTracker.Data.Seeding.Seeders;

namespace ArrivalTracker.Data.Seeding;

public class ApplicationDbContextSeeder
{
     public static void Seed(ArrivalsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
        }

            var seeders = new List<ISeeder>
            {
                new RolesSeeder(),
                new TeamsSeeder()
            };

            foreach (var seeder in seeders)
            {
                seeder.Seed(dbContext, serviceProvider);
                dbContext.SaveChanges();
            }
        }
}
