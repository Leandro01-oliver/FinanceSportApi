using System.ComponentModel.DataAnnotations;

namespace FinanceSportApi.Domain.Entityes
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
}
