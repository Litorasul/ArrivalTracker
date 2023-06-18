namespace ArrivalTracker.Data.Seeding;

public interface ISeeder
{
    void Seed(ArrivalsDbContext dbContext, IServiceProvider serviceProvider);
}
