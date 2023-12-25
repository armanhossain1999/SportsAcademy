namespace SportAcademy.BlazorApp.Server.HostedServices.SportsDb;

public class SportsMigrationHostedService : IHostedService
{
    private readonly IServiceProvider serviceProvider;
    public SportsMigrationHostedService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var svc = scope.ServiceProvider.GetRequiredService<SportsDbMigrationService>();
        await svc.ApplyMigrationAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}
