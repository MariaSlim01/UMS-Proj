using MediatR;

namespace UMS.WebAPI1;

public static class Dependencies
{
    public static IServiceCollection RegisterRequestHandlers(
        this IServiceCollection services)
    {
        return services
            .AddMediatR(typeof(Dependencies).Assembly);
    }
}