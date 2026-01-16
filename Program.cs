var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();  // ✅ Razor Pages support
builder.Services.AddControllersWithViews(); // optional if you also use MVC

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map Razor Pages
app.MapRazorPages();  // ✅ important!

// Optional: Map MVC controller routes if needed
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
