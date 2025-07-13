using AutoMapper;
using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Enums;
using FinanceSportApi.Domain.Models;
using FinanceSportApi.Domain.Records;
using FinanceSportApi.Infra.Data.Repository.Interface;
using FinanceSportApi.Service.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinanceSportApi.Service.Service
{
    public class UsuarioService : BaseService<UsuarioVm, Usuario>, IUsuarioService
    {

        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsuarioService(
            IBaseRepository<Usuario> repository,
            IMapper mapper,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IConfiguration configuration) : base(repository, mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<TokenVm> RegisterAsync(UsuarioVm usuarioVm)
        {
            var usuario = _mapper.Map<Usuario>(usuarioVm);
            usuario.UserName = usuarioVm.Email;
            usuario.EmailConfirmed = true;

            var result = await _userManager.CreateAsync(usuario, usuarioVm.Senha);
            if (!result.Succeeded)
                throw new Exception("Erro ao criar usuário: " + string.Join(", ", result.Errors.Select(e => e.Description)));

            // Adicionar role padrão
            await _userManager.AddToRoleAsync(usuario, "Usuario");

            return await GenerateTokenAsync(usuario);
        }

        public async Task<TokenVm> LoginAsync(UsuarioLogin usuarioLogin)
        {
            var usuario = await _userManager.FindByEmailAsync(usuarioLogin.Email);
            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            var result = await _signInManager.CheckPasswordSignInAsync(usuario, usuarioLogin.Senha, false);
            if (!result.Succeeded)
                throw new Exception("Senha incorreta");

            await UpdateLastLoginAsync(usuarioLogin.Email);

            return await GenerateTokenAsync(usuario);
        }

        public async Task<TokenVm> LoginGoogleAsync(UsuarioLogin usuarioLogin)
        {
            var usuario = await _userManager.FindByEmailAsync(usuarioLogin.Email);

            if (usuario == null)
            {
                // Criar novo usuário
                usuario = new Usuario
                {
                    UserName = usuarioLogin.Email,
                    Email = usuarioLogin.Email,
                    Nome = usuarioLogin.Nome,
                    EmailConfirmed = true,
                    TipoUsuario = TipoUsuario.Usuario 
                };

                var result = await _userManager.CreateAsync(usuario);
                if (!result.Succeeded)
                    throw new Exception("Erro ao criar usuário: " + string.Join(", ", result.Errors.Select(e => e.Description)));

                // Adicionar role padrão
                await _userManager.AddToRoleAsync(usuario, "Usuario");
            }
            else
            {
                // Atualizar usuário existente com informações do Google
                usuario.Nome = usuarioLogin.Nome;
                usuario.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(usuario);
                if (!result.Succeeded)
                    throw new Exception("Erro ao atualizar usuário: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            await UpdateLastLoginAsync(usuarioLogin.Email);

            return await GenerateTokenAsync(usuario);
        }

        public async Task<bool> ValidateTokenAsync(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateLastLoginAsync(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            if (usuario == null)
                return false;

            usuario.UltimoLogin = DateTime.UtcNow;
            await _userManager.UpdateAsync(usuario);
            return true;
        }

        private async Task<TokenVm> GenerateTokenAsync(Usuario usuario)
        {
            // Usar métodos do Identity para obter claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nome ?? usuario.UserName),
                new Claim("UserId", usuario.Id),
                new Claim("TipoUsuario", usuario.TipoUsuario.ToString()) // Adicionar tipo de usuário
            };

            // Adicionar roles usando método nativo do Identity
            var roles = await _userManager.GetRolesAsync(usuario);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Adicionar role baseada no TipoUsuario
            var roleBasedOnType = usuario.TipoUsuario == TipoUsuario.Admin ? "Admin" : "Usuario";
            claims.Add(new Claim(ClaimTypes.Role, roleBasedOnType));

            // Gerar token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(12),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenVm
            {
                Token = tokenHandler.WriteToken(token),
                ExpiraEm = tokenDescriptor.Expires.Value,
                Email = usuario.Email,
                Nome = usuario.Nome ?? usuario.UserName
            };
        }
    }
}
