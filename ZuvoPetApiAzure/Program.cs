using Microsoft.EntityFrameworkCore;
using ZuvoPetApiAzure.Repositories;
using ZuvoPetApiAzure.Data;
using System.Text.Json.Serialization;
using Scalar.AspNetCore;
using ZuvoPetApiAzure.Helpers;

var builder = WebApplication.CreateBuilder(args);

HelperCriptography.Initialize(builder.Configuration);
builder.Services.AddHttpContextAccessor();
HelperActionServicesOAuth helper = new HelperActionServicesOAuth(builder.Configuration);
builder.Services.AddSingleton<HelperActionServicesOAuth>(helper);
builder.Services.AddScoped<HelperUsuarioToken>();
builder.Services.AddAuthentication(helper.GetAuthenticateSchema())
    .AddJwtBearer(helper.GetJwtBearerOptions());
// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("ZuvoPet");
builder.Services.AddTransient<IRepositoryZuvoPet, RepositoryZuvoPet>();
builder.Services.AddDbContext<ZuvoPetContext>
    (options => options.UseSqlServer(connectionString));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.MapOpenApi();
app.UseHttpsRedirection();

//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/openapi/v1.json", "Api Seguridad Empleados");
//    options.RoutePrefix = "";
//});
app.MapScalarApiReference();
app.UseAuthorization();

app.MapControllers();

app.Run();