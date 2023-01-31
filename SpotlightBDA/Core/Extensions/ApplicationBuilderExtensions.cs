using SpotlightBDA.Data;

namespace SpotlightBDA.Core.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        

        public static IApplicationBuilder Initialize(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var initializers = serviceScope.ServiceProvider.GetServices<DbInitializer>();

            foreach (var initializer in initializers)
            {
                initializer.Initialize();
            }

            return app;
        }
    }
}
