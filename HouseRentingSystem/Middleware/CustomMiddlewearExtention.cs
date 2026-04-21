using System.Runtime.CompilerServices;

namespace HouseRentingSystem.Middleware
{
    public static class CustomMiddlewearExtention
    {
        public static IApplicationBuilder UseCustom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
