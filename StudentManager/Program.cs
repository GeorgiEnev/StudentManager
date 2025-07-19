using StudentManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// 1) EF Core + SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2) ASP.NET Core Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// 3) MVC Controllers & Razor Views
builder.Services.AddControllersWithViews();

// 4) (Optional) AI Tutor HttpClient—that stays as you had it
builder.Services.AddHttpClient("deepseek", client =>
{
    client.BaseAddress = new Uri("http://localhost:11434/");
});

var app = builder.Build();

// 5) Ensure database is created & seeded
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Teachers.Any())
    {
        var t1 = new Teacher { FullName = "Dr. Smith" };
        var t2 = new Teacher { FullName = "Prof. Johnson" };
        var t3 = new Teacher { FullName = "Ms. Lee" };
        db.Teachers.AddRange(t1, t2, t3);
        db.SaveChanges();

        db.Subjects.AddRange(
            new Subject { Name = "Math", TeacherId = t1.Id },
            new Subject { Name = "Physics", TeacherId = t2.Id },
            new Subject { Name = "Computer Science", TeacherId = t3.Id }
        );
        db.SaveChanges();
    }
}

// 6) HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 7) Enable Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
