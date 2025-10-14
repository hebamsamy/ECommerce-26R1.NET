namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Work as API
            //builder.Services.AddControllers();
            var app = builder.Build();

            
            //make routes table
            app.UseRouting();


            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Privacy}/{id?}")
                .WithStaticAssets();


            app.Run();

        }
    }
}