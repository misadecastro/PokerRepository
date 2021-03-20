using System.Collections.Generic;

namespace Poker.Domain
{
    public class Historia: BaseEntity
    {
        public string Descricao { get; set; }

        public IEnumerable<Voto> Votos { get; set; }

        public Historia(){
            
        }
    }
}