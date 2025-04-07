using QueryAssignment.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<HomeService>();
var app = builder.Build();

app.MapControllers();
app.UseRouting();
app.UseStaticFiles();

app.Run();
