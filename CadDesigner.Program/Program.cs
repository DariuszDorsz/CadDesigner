using CadDesigner.Infrastructure.Extension;
using CadDesigner.Aplication.Extension;
using CadDesigner.Aplication.Middleware;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAplication(builder.Configuration);
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
