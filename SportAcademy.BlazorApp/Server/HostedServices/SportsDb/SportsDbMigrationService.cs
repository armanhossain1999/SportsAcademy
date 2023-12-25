using Microsoft.EntityFrameworkCore;
using SportAcademy.BlazorApp.Shared.Models;

namespace SportAcademy.BlazorApp.Server.HostedServices.SportsDb
{
    public class SportsDbMigrationService
    {
        private readonly SportsEdgeDbContext db;
        public SportsDbMigrationService(SportsEdgeDbContext db)
        {
            this.db = db;
        }
        public async Task ApplyMigrationAsync()
        {
            if ((await db.Database.GetPendingMigrationsAsync()).Any())
            {
                await db.Database.MigrateAsync();
            }
        }
    }
}