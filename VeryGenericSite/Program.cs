using Microsoft.Extensions.FileProviders;

using System.Net;

using VeryGenericSite.Services.AddresServices.CountryCodes;
using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation;
using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces;
using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;
using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation;

var builder = WebApplication.CreateBuilder(args);
//add services to the controller 


builder.Services.AddControllersWithViews();

builder.Services.AddAntiforgery();


builder.Services.AddRazorPages()
   .AddRazorRuntimeCompilation();

builder.Services.AddMvcCore()
  .AddRazorRuntimeCompilation();

builder.Services.AddMvc();

//no config for now, this will need to be either transient
//or somehow cached for mulitlanguage support, config would throw out the correcto one
//depeding on lanugage. //Need to make a config for this to work, right now the CodeFactory is being resolved as a dependecy, which it shouldnt.
builder.Services.AddTransient<IAlphaCountryCode, IsoAlphaCodes>();
builder.Services.AddTransient<ICountryCodeValidator, ValidateCountryCode>();
builder.Services.AddTransient<IValidateCountryCodeFactory<ICountryCodeValidator>,
    EnglishValidateCountryCodeFactory<ICountryCodeValidator>>();
builder.Services.AddSingleton<IAlphaCodeFactory<IsoAlphaCodes>, AlphaCodeFactory>(); //this might still throw...
builder.Services.AddSingleton<IValidationCodeFactory, ValidationCodeFactory>();

builder.Metrics.Services.AddMetrics();

builder.WebHost.UseKestrel();

var app = builder.Build();
// Add services to the container.

if (!app.Environment.IsDevelopment())
{

// Configure the HTTP request pipeline.
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(System.IO.Path.Combine(app.Environment.WebRootPath, "Scheduler")),
    RequestPath = "/Scheduler",
    OnPrepareResponse = context =>
    {
        if (!context.Context.User.Identity.IsAuthenticated)
        {
            context.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}) ;

app.UseHostFiltering();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


