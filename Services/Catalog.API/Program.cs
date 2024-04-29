using Catalog.API.HostingService;
using Catalog.API.Interfaces.Manager;
using Catalog.API.Manager;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<AppHostedService>();
builder.Services.AddSingleton<IProductManager, ProductManager>();
builder.Services.AddLogging();
builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
