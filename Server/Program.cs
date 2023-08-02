var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var application = builder.Build();
if (application.Environment.IsDevelopment())
{
    application.UseWebAssemblyDebugging();
}
else
{
    application.UseExceptionHandler("/Error");
    application.UseHsts();
}
application.UseHttpsRedirection();
application.UseBlazorFrameworkFiles();
application.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
        context.Context.Response.Headers.Append("Cache-Control", "public, max-age=0, must-revalidate")
});
application.UseRouting();
application.MapRazorPages();
application.MapControllers();
application.MapFallbackToFile("index.html");
application.Run();