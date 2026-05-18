var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Frontend Razor Pages
app.MapRazorPages();

// Backend API - Hello Endpoint
app.MapGet("/api/hello", () =>
{
    return Results.Json(new
    {
        message = "Hello from .NET Backend API"
    });
});

// Backend API - User Endpoint
app.MapGet("/api/user", () =>
{
    return Results.Json(new
    {
        name = "Harry",
        role = "DevOps Engineer",
        cloud = "Azure"
    });
});

app.Run();