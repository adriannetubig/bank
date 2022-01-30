var builder = WebApplication.CreateBuilder(args);
bank_api.Helper.Dependencies.Register(builder.Services, builder.Configuration);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
