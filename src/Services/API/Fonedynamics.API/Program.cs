using AutoMapper;
using Fonedynamics.API.Models;
using Fonedynamics.API.Models.Mapping;
using Fonedynamics.API.Repositories.SMSRepository;
using Fonedynamics.API.Services.SMSService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PhonedynamicsContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISMSService, SMSService>();
builder.Services.AddScoped<ISMSRepository, SMSRepository>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<PhonedynamicsContext>();
        context.Database.Migrate();
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();
