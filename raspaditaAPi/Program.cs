using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using raspaditaAPi.seguridad;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");
var secretkey = builder.Configuration.GetValue<string>("JWT:key");
ConfigurationManager configuration = builder.Configuration;
var variablesSection = configuration.GetSection("variables");
var puerto = variablesSection["puerto"];


builder.Services.AddCors(o => o.AddPolicy("cors", options =>
{
    options.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();

    //options.WithOrigins("http://localhost:4200", "http://165.232.151.209").AllowAnyHeader().AllowAnyMethod();

})
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey))
        };
    });

builder.Services.AddScoped<IJwtUtils, JwtUtils>();
// Add services to the container.
builder.Services.AddControllers(x=>x.Filters.Add<AuthorizeAttribute>()).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}); ;
builder.Services.AddPersistence();
builder.Services.AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("principal", new OpenApiInfo
    {
        Title = $"Raspadita v1",
        Version = "v1",
        Description = " API para Juego Raspadita ",
        Contact = new OpenApiContact
        {
            Name = "Sistemas",
            Email = "correo@gmail.com",
            Url = new Uri("https://foo.com/"),
        }
    });
    options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
    options.EnableAnnotations();
});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.WebHost.UseUrls(puerto);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "custom")),
    RequestPath = "/custom"
});

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.DocumentTitle = "Raspadita";
    c.SwaggerEndpoint("/swagger/principal/swagger.json", "Principal");
    c.DefaultModelsExpandDepth(-1);
    c.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
    c.InjectStylesheet("/custom/customSwagger.css");
    c.InjectJavascript("/custom/swagger-custom-script.js", "text/javascript");
});
app.UseRouting();
app.UseCors("cors");
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
