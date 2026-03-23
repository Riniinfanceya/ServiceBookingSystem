using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Servicebookingsystem.infrastructure.Data;
using Servicebookingsystem.core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly AppDbContext _context;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IConfiguration config, AppDbContext context, ILogger<AuthController> logger)
    {
        _config = config;
        _context = context;
        _logger = logger;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest login)
    {
        try
        {
            _logger.LogInformation("Login attempt for {Email}", login.Email);

            var customer = _context.Customers
                .FirstOrDefault(u => u.Email.Trim().ToLower() == login.Email.Trim().ToLower()
                                  && u.Password.Trim() == login.Password.Trim());

            if (customer == null)
            {
                _logger.LogWarning("Invalid credentials for {Email}", login.Email);
                return Unauthorized(new { message = "Invalid credentials" });
            }

            _logger.LogInformation("Customer authenticated: {Email}", customer.Email);

            var token = GenerateJwtToken(customer.Email, "Customer");

            // ✅ Return both token and customerId
            return Ok(new { token, customerId = customer.CustomerId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during login");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    private string GenerateJwtToken(string email, string role)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, email),
            new Claim("role", role)
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
