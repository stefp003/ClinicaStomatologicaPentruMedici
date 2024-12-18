using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClinicaStomatologicaPentruMedici.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});
// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Doctors");
    options.Conventions.AuthorizeFolder("/Patients");
    options.Conventions.AuthorizeFolder("/Treatments/Edit","AdminPolicy");
    options.Conventions.AuthorizeFolder("/Treatments/Create", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Treatments/Delete", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Prescriptions");
    options.Conventions.AuthorizeFolder("/Appointments");
});
builder.Services.AddDbContext<ClinicaStomatologicaPentruMediciContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicaStomatologicaPentruMediciContext") ?? throw new InvalidOperationException("Connection string 'ClinicaStomatologicaPentruMediciContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicaStomatologicaPentruMediciContext") ?? throw new InvalidOperationException("Connectionstring 'ClinicaStomatologicaPentruMediciContext' not found."))); 



builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
