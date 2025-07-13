using FinanceSportApi.Domain.Models;
using FinanceSportApi.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceSportApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Obtém todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioVm>), 200)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _usuarioService.GetObjectsAsync(u => true);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtém um usuário por ID
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Usuário encontrado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioVm), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid userId))
                    return BadRequest(new { message = "ID inválido" });

                var usuario = await _usuarioService.GetObjectAsync(u => u.Id == userId);
                if (usuario == null)
                    return NotFound(new { message = "Usuário não encontrado" });

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="usuarioVm">Dados do usuário</param>
        /// <returns>Status da criação</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Create([FromBody] UsuarioVm usuarioVm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _usuarioService.AddAsync(usuarioVm);
                return CreatedAtAction(nameof(GetById), new { id = usuarioVm.Id }, usuarioVm);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="usuarioVm">Dados atualizados do usuário</param>
        /// <returns>Status da atualização</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Update([FromBody] UsuarioVm usuarioVm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (Guid.Empty == usuarioVm.Id)
                    return BadRequest(new { message = "ID inválido" });

                var usuarioExistente = await _usuarioService.GetObjectAsync(u => u.Id == usuarioVm.Id);
                if (usuarioExistente == null)
                    return NotFound(new { message = "Usuário não encontrado" });

                await _usuarioService.Update(usuarioExistente, null);
                return Ok(new { message = "Usuário atualizado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Exclui um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Status da exclusão</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (Guid.Empty == id)
                    return BadRequest(new { message = "ID inválido" });

                var usuarioExistente = await _usuarioService.GetObjectAsync(u => u.Id == id);
                if (usuarioExistente == null)
                    return NotFound(new { message = "Usuário não encontrado" });

                await _usuarioService.Remove(u => u.Id == id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Busca usuários por nome
        /// </summary>
        /// <param name="nome">Nome para busca</param>
        /// <returns>Lista de usuários encontrados</returns>
        [HttpGet("buscar/{nome}")]
        [ProducesResponseType(typeof(IEnumerable<UsuarioVm>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> SearchByName(string nome)
        {
            try
            {
                var usuarios = await _usuarioService.GetObjectsAsync(u => 
                    u.Nome != null && u.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 