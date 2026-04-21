namespace HouseRentingSystem.Middleware
{
    public static class TimeMeasurementMiddlewareExtention
    {
        public static IApplicationBuilder UseCustomTime(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMeasurementMiddleware>();
        }
    }
}
