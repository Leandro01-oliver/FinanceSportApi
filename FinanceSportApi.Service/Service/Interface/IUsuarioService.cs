using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;
using FinanceSportApi.Domain.Records;

namespace FinanceSportApi.Service.Service.Interface
{
    public interface IUsuarioService : IBaseService<UsuarioVm, Usuario>
    {
        Task<TokenVm> RegisterAsync(UsuarioVm usuarioVm);
        Task<TokenVm> LoginAsync(UsuarioLogin usuarioLogin);
        Task<TokenVm> LoginGoogleAsync(UsuarioLogin usuarioLogin);
        Task<bool> ValidateTokenAsync(string token);
        Task<bool> UpdateLastLoginAsync(string email);
    }
}
