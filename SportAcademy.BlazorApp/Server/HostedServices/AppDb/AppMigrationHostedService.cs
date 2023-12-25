namespace SportAcademy.BlazorApp.Server.HostedServices.AppDb
{
    public class AppMigrationHostedService : IHostedService 
    {
        private readonly IServiceProvider serviceProvider;
        public AppMigrationHostedService(IServiceProvider serviceProvider) 
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<AppDbMigrationService>();
            await svc.MigrationAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
