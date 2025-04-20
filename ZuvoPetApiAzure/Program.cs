using Microsoft.EntityFrameworkCore;
using ZuvoPetApiAzure.Repositories;
using ZuvoPetApiAzure.Data;
using System.Text.Json.Serialization;
using Scalar.AspNetCore;
using ZuvoPetApiAzure.Helpers;
using Azure.Storage.Blobs;
using ZuvoPetApiAzure.Services;

var builder = WebApplication.CreateBuilder(args);

HelperCriptography.Initialize(builder.Configuration);
builder.Services.AddHttpContextAccessor();
HelperActionServicesOAuth helper = new HelperActionServicesOAuth(builder.Configuration);
builder.Services.AddSingleton<HelperActionServicesOAuth>(helper);
builder.Services.AddSingleton<ServiceStorageBlobs>();
builder.Services.AddScoped<HelperUsuarioToken>();
builder.Services.AddAuthentication(helper.GetAuthenticateSchema())
    .AddJwtBearer(helper.GetJwtBearerOptions());
// Add services to the container.

string azureKeys = builder.Configuration.GetValue<string>("AzureKeys:StorageAccount");
BlobServiceClient blobServiceClient = new BlobServiceClient(azureKeys);
builder.Services.AddTransient<BlobServiceClient>(x => blobServiceClient);

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

app.MapScalarApiReference();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", context => {
    context.Response.Redirect("/scalar/v1");
    return Task.CompletedTask;
});

app.Run();