using Poker.Domain.Identity;

namespace Poker.Domain
{
    public class Voto
    {
        public int ID { get; private set; }
        public User Usuario { get; private set; }
        public Carta Carta { get; private set; }
        public Historia Historia { get; private set; }
    }
}