namespace FinanceSportApi.Domain.Records
{
    public record UsuarioLogin(string Email, string? Senha = null, string? Nome = null);
}
