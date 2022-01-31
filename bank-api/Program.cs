var builder = WebApplication.CreateBuilder(args);
bank_api.Helper.Dependencies.Register(builder.Services, builder.Configuration);

builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
