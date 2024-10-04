using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
//    .AddJsonFile("Ocelot.json", optional: false,reloadOnChange:true)
//    .AddEnvironmentVariables();
builder.Configuration.AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

//builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
await app.UseOcelot();
app.MapGet("/", () => "Hello World!");

app.Run();
