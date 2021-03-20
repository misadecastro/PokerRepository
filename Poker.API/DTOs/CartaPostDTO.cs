using System.ComponentModel.DataAnnotations;

namespace Poker.API.DTOs
{
    public class CartaPostDTO
    {
        [Required(ErrorMessage="{0} obrigatório")]        
        public int Valor {get; set;}
    }
}