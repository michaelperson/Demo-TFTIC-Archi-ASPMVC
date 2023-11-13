namespace ASPMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.MapControllerRoute(
                name: "privacy",
                pattern: "condition-reglement-confidentialite/",
                defaults: new { Controller = "Home", Action = "Privacy" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults : new { Controller = "Home", Action = "Index"});

            app.Run();
        }
    }
}