
namespace EmployeeCrudTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.
                    AddControllersWithViews().
                    AddRazorRuntimeCompilation();
            var app = builder.Build();

            
            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Admin}/{action=Employee}");
            app.Run();
        }
    }
}