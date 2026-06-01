using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Text.Json;

namespace ClanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = GetConnectionString();

            optionsBuilder.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        private static string GetConnectionString()
        {
            var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (currentDirectory is not null)
            {
                var appSettingsPath = Path.Combine(
                    currentDirectory.FullName,
                    "CleanArchMvc.WebUI",
                    "appsettings.json");

                if (File.Exists(appSettingsPath))
                {
                    using var appSettings = JsonDocument.Parse(File.ReadAllText(appSettingsPath));

                    return appSettings.RootElement
                        .GetProperty("ConnectionStrings")
                        .GetProperty("DefautConnection")
                        .GetString()
                        ?? throw new InvalidOperationException("Connection string 'DefautConnection' was not found.");
                }

                currentDirectory = currentDirectory.Parent;
            }

            throw new FileNotFoundException("Could not find CleanArchMvc.WebUI/appsettings.json.");
        }
    }
}
