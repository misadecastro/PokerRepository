using Flunt.Validations;
using Poker.Domain.Identity;
using System.Linq;

namespace Poker.Domain
{
    public class Voto: BaseEntity
    {
        public User Usuario { get; set; }
        public Carta Carta { get; set; }
        public Historia Historia { get; set; }

        public Voto()
        {
                
        }

        public Voto(User usuario, Carta carta, Historia historia)
        {
            AddNotifications(new Contract()
                            .IsNotNull(usuario, nameof(usuario), "Para realizar um voto o usuário deve ser informado.")
                            .IsGreaterThan(usuario.Id, 0, nameof(usuario.Id), "Para realizar um voto o usuário deve ser informado.")
                            .IsNotNull(carta, nameof(carta), "Para realizar um voto a carta deve ser informado.")
                            .IsGreaterThan(carta.ID, 0, nameof(carta.ID), "Para realizar um voto a carta deve ser informado.")
                            .IsNotNull(historia, nameof(historia), "Para realizar um voto a historia deve ser informado.")
                            .IsGreaterThan(historia.ID, 0, nameof(historia.ID), "Para realizar um voto a historia deve ser informado.")
                            .IsFalse(VotoJaRealizado(historia, usuario.Id), nameof(usuario),"Usuário já realizou o voto nessa história")
                           );
            if (Invalid)
                return;
            CriarVoto(usuario, carta, historia);
        }

        private void CriarVoto(User usuario, Carta carta, Historia historia)
        {
            this.Historia = historia;
            this.Carta = carta;
            this.Usuario = usuario;
        }

        private bool VotoJaRealizado(Historia historia, int idUsuario)
        {
            if (historia != null && historia.Votos != null)
                return historia.Votos.Any(v => v.Usuario.Id.Equals(idUsuario));
            else
                return false;
        }
    }
}