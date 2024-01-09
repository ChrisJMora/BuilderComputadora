using BuilderAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConsStr"));
});

// Authenticator
builder.Services.AddScoped<IAuthenticator, AuthenticatorService>();
builder.Services.AddScoped<IComponenteAuthenticator, ComponenteAuthenticator>();
builder.Services.AddScoped<IComputadoraAuthenticator, ComputadoraAuthenticator>();
builder.Services.AddScoped<IComputadoraComponenteAuthenticator, ComputadoraComponenteAuthenticator>();
builder.Services.AddScoped<IMapperAuthenticator, MapperAuthenticator>();

// Componente
builder.Services.AddScoped<IComponenteRepository, ComponenteRepository>();
builder.Services.AddScoped<IComponenteService, ComponenteService>();
// Computadora
builder.Services.AddScoped<IComputadoraRepository, ComputadoraRepository>();
builder.Services.AddScoped<IComputadoraService, ComputadoraService>();
// ComputadoraComponente
builder.Services.AddScoped<IComputadoraComponenteRepository, ComputadoraComponenteRepository>();
builder.Services.AddScoped<IComputadoraComponenteService, ComputadoraComponenteService>();

// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(ModelToResourceProfile),typeof(ResourceToModelProfle));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
