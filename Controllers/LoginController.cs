using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using WebApiLoja.DTOs;
using WebApiLoja.Models;
using WebApiLoja.Services;

namespace WebApiLoja.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        public String GeraToken(UserDTO userDTO, TokenService tokenService)
        {
            User user = new (0,userDTO.Email,userDTO.Password,["Admin"]);
            return tokenService.Generate(user);
        }
    }
}
