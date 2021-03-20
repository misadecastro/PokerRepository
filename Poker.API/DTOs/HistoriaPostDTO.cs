using System.ComponentModel.DataAnnotations;

namespace Poker.API.DTOs
{
    public class HistoriaPostDTO
    {
        [Required(ErrorMessage="{0} obrigatório")]
        [StringLength(100,MinimumLength=3,ErrorMessage="{0} deve ter entre 10 e 250 caracteres")]
        public string Descricao { get; set; }
    }
}