using Flunt.Validations;
using Poker.Domain.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Poker.Domain
{
    public class Voto: BaseEntity
    {
        [ForeignKey("Usuario")]
        public int UsuarioId {get; set;}
        public virtual User Usuario { get; set; }

        [ForeignKey("Carta")]
        public int CartaId {get; set;}
        public Carta Carta { get; set; }

        
        [ForeignKey("Historia")]
        public int HistoriaId {get; set;}
        public virtual  Historia Historia { get; set; }

        public Voto()
        {
                
        }

        public Voto(User usuario, Carta carta, Historia historia)
        {
            AddNotifications(new Contract()
                            .IsNotNull(usuario, nameof(usuario), "Para realizar um voto o usu�rio deve ser informado.")
                            .IsGreaterThan(usuario.Id, 0, nameof(usuario.Id), "Para realizar um voto o usu�rio deve ser informado.")
                            .IsNotNull(carta, nameof(carta), "Para realizar um voto a carta deve ser informado.")
                            .IsGreaterThan(carta.ID, 0, nameof(carta.ID), "Para realizar um voto a carta deve ser informado.")
                            .IsNotNull(historia, nameof(historia), "Para realizar um voto a historia deve ser informado.")
                            .IsGreaterThan(historia.ID, 0, nameof(historia.ID), "Para realizar um voto a historia deve ser informado.")
                            .IsFalse(VotoJaRealizado(historia, usuario.Id), nameof(usuario),"Usu�rio j� realizou o voto nessa hist�ria")
                           );
            if (Invalid)
                return;
            CriarVoto(usuario, carta, historia);
        }

        private void CriarVoto(User usuario, Carta carta, Historia historia)
        {
            this.HistoriaId = historia.ID;
            this.CartaId = carta.ID;
            this.UsuarioId = usuario.Id;
        }

        private bool VotoJaRealizado(Historia historia, int idUsuario)
        {
            if (historia != null && historia.Votos != null)
                return historia.Votos.Any(v => v.UsuarioId.Equals(idUsuario));
            else
                return false;
        }
    }
}