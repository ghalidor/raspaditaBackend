using Application;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var variablesSection = configuration.GetSection("variables");
var puerto = variablesSection["puerto"];


builder.Services.AddCors(o => o.AddPolicy("cors", options =>
{
    options.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();

    //options.WithOrigins("http://localhost:4200", "http://165.232.151.209").AllowAnyHeader().AllowAnyMethod();

})
);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddPersistence();
builder.Services.AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.WebHost.UseUrls(puerto);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("cors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
