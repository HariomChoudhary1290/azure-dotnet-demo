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

// Backend API - JSON Endpoint
app.MapGet("/api/hello", () =>
{
    return Results.Json(new
    {
        message = "Hello from .NET Backend API"
    });
});

// AI Style Backend Dashboard
app.MapGet("/backend", async context =>
{
    context.Response.ContentType = "text/html";

    await context.Response.WriteAsync(@"
    <!DOCTYPE html>
    <html>
    <head>
        <title>AI Backend Dashboard</title>

        <style>
            body {
                margin: 0;
                padding: 0;
                font-family: Arial, sans-serif;
                background: linear-gradient(135deg, #0f172a, #1e293b, #2563eb);
                color: white;
                display: flex;
                justify-content: center;
                align-items: center;
                min-height: 100vh;
            }

            .container {
                text-align: center;
                background: rgba(255,255,255,0.1);
                padding: 50px;
                border-radius: 20px;
                backdrop-filter: blur(10px);
                box-shadow: 0 8px 32px rgba(0,0,0,0.3);
                width: 80%;
                max-width: 700px;
            }

            h1 {
                font-size: 60px;
                margin-bottom: 20px;
            }

            p {
                font-size: 22px;
                color: #dbeafe;
            }

            .card-container {
                display: flex;
                gap: 20px;
                justify-content: center;
                flex-wrap: wrap;
                margin-top: 40px;
            }

            .card {
                background: rgba(255,255,255,0.1);
                padding: 25px;
                border-radius: 15px;
                width: 180px;
                transition: 0.3s;
            }

            .card:hover {
                transform: translateY(-10px);
                background: rgba(255,255,255,0.2);
            }

            .status {
                color: #4ade80;
                font-weight: bold;
            }

        </style>
    </head>

    <body>

        <div class='container'>

            <h1>AI Backend Dashboard </h1>

            <p>
                ASP.NET Core Backend Running Successfully on Azure Cloud
            </p>

            <div class='card-container'>

                <div class='card'>
                    <h2>Frontend</h2>
                    <p class='status'>Connected</p>
                </div>

                <div class='card'>
                    <h2>Backend API</h2>
                    <p class='status'>Active</p>
                </div>

                <div class='card'>
                    <h2>CI/CD</h2>
                    <p class='status'>Working</p>
                </div>

            </div>

        </div>

    </body>
    </html>
    ");
});

app.Run();