using FinanceSportApi.Domain.Models;
using FinanceSportApi.Domain.Records;
using FinanceSportApi.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceSportApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IUsuarioService usuarioService, RoleManager<IdentityRole> roleManager)
        {
            _usuarioService = usuarioService;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Cria as roles padrão do sistema
        /// </summary>
        /// <returns>Status da criação</returns>
        [HttpPost("create-roles")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRoles()
        {
            try
            {
                var roles = new[] { "Admin", "Usuario" };
                var createdRoles = new List<string>();

                foreach (var role in roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                        createdRoles.Add(role);
                    }
                }

                return Ok(new { message = $"Roles criadas: {string.Join(", ", createdRoles)}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param name="usuarioVm">Dados do usuário para registro</param>
        /// <returns>Token de autenticação</returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(TokenVm), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] UsuarioVm usuarioVm)
        {
            try
            {
                var token = await _usuarioService.RegisterAsync(usuarioVm);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Realiza login do usuário com email e senha
        /// </summary>
        /// <param name="login">Dados de login</param>
        /// <returns>Token de autenticação</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(TokenVm), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginVm login)
        {
            try
            {
                var usuarioLogin = new UsuarioLogin(login.Email, login.Senha, login.Email);
                var token = await _usuarioService.LoginAsync(usuarioLogin);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Realiza login do usuário com Google
        /// </summary>
        /// <param name="loginGoogle">Dados de login do Google</param>
        /// <returns>Token de autenticação</returns>
        [HttpPost("login-google")]
        [ProducesResponseType(typeof(TokenVm), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> LoginGoogle([FromBody] LoginGoogleVm loginGoogle)
        {
            try
            {
                var usuarioLogin = new UsuarioLogin(loginGoogle.Email, "", loginGoogle.Nome);
                var token = await _usuarioService.LoginGoogleAsync(usuarioLogin);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Valida um token de autenticação
        /// </summary>
        /// <param name="token">Token a ser validado</param>
        /// <returns>Status da validação</returns>
        [HttpPost("validate-token")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> ValidateToken([FromBody] string token)
        {
            try
            {
                var isValid = await _usuarioService.ValidateTokenAsync(token);
                if (isValid)
                    return Ok(new { valid = true });
                else
                    return Unauthorized(new { valid = false, message = "Token inválido" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza o último login do usuário
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Status da atualização</returns>
        [HttpPut("update-last-login")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateLastLogin([FromBody] string email)
        {
            try
            {
                var result = await _usuarioService.UpdateLastLoginAsync(email);
                if (result)
                    return Ok(new { message = "Último login atualizado com sucesso" });
                else
                    return BadRequest(new { message = "Usuário não encontrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 