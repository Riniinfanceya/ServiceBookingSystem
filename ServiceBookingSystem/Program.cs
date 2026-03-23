using Servicebookingsystem.infrastructure.Data;
using Servicebookingsystem.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Servicebookingsystem.services.Interfaces;
using Servicebookingsystem.services.Services;
using Servicebookingsystem.infrastructure;

var builder = WebApplication.CreateBuilder(args);

// 🔹 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Repository Pattern
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// 🔹 Register Services
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IAdminService, AdminService>();

// 🔹 Register AuthService
builder.Services.AddScoped<AuthService>();

// 🔹 JWT Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// 🔹 Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 CORS (for Angular frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// 🔹 Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Order matters: CORS → Auth → Controllers
app.UseCors("AllowAngular");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Health check endpoint
app.MapGet("/", () => "API Connected Successfully ✅");

app.Run();
