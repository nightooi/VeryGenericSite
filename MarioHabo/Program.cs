var builder = WebApplication.CreateBuilder(args);
//add services to the controller 
builder.Services.AddControllersWithViews();



/*builder.Services.AddRazorPages()
   .AddRazorRuntimeCompilation();
builder.Services.AddMvcCore()
  .AddRazorRuntimeCompilation();*/

var app = builder.Build();
// Add services to the container.

if (!app.Environment.IsDevelopment())
{

// Configure the HTTP request pipeline.
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
