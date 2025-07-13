using System.ComponentModel.DataAnnotations;

namespace FinanceSportApi.Domain.Models
{
    public class LoginVm
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }

    public class LoginGoogleVm
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
    }

    public class TokenVm
    {
        public string Token { get; set; }
        public DateTime ExpiraEm { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
