using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Migrations;
using WareHose.Common;
using WareHose.DTO;

namespace WareHose.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IEmployeeRepository _employeeRepository;
    private JwtService _jwtService;
    
    public AuthController(JwtService jwtService, IEmployeeRepository employeeRepository)
    {
        _jwtService = jwtService;
        _employeeRepository = employeeRepository;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        Employee? employee = await _employeeRepository.GetByEmailAsync(request.Email);
        if (
            employee == null ||
            !PasswordService.VerifyPassword(employee.Password, request.Password)
        ) return Unauthorized(new { error = "Invalid username or password" });

        return Ok(new
        {
            token = _jwtService.GenerateToken(employee.Id, request.Email)
        });
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterDto request)
    {
        Employee? existingEmployee = await _employeeRepository.GetByEmailAsync(request.Email);
        if (existingEmployee != null)
        {
            return BadRequest(new { error = "Email is already in use" });
        }
        string hashedPassword = PasswordService.HashPassword(request.Password);
        Employee employee = new Employee
        {
            Email = request.Email,
            Password = hashedPassword,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        await _employeeRepository.AddItemAsync(employee);

        return Ok(new
        {
            message = "User registered successfully",
            token = _jwtService.GenerateToken(employee.Id, request.Email)
        });
    }
}
