var builder = WebApplication.CreateBuilder(args);
bank_api.Helper.Dependencies.Register(builder.Services, builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(a =>
{
    a.CustomSchemaIds(bank_api.Helper.SwaggerConfiguration.SchemaIdStrategy);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();