using Microsoft.EntityFrameworkCore;
using SportAcademy.BlazorApp.Shared.Models;

namespace SportAcademy.BlazorApp.Server.HostedServices.AppDb
{
    public class AppDbMigrationService
    {
        private readonly AppDbContext db;
        public AppDbMigrationService(AppDbContext db)  
        {
            this.db = db;
        }
        public async Task MigrationAsync() 
        {
            if ((await db.Database.GetPendingMigrationsAsync()).Any())
            {
                await db.Database.MigrateAsync();
            }
        }
    }
}
