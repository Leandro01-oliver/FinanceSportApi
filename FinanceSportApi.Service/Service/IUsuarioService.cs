using AutoMapper;
using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;
using FinanceSportApi.Infra.Data.Repository.Interface;
using FinanceSportApi.Service.Service.Interface;
using System.Linq.Expressions;

namespace FinanceSportApi.Service.Service
{
    public class UsuarioService : BaseService<UsuarioVm, Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) : base(usuarioRepository, mapper)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}
