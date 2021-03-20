using System.ComponentModel.DataAnnotations;

namespace Poker.DTOs
{
    public class CartaDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public int Valor { get; set; }
    }
}