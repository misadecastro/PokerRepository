namespace Poker.Domain
{
    public class Carta: BaseEntity
    {
        public int Valor { get; set; }
        public Carta()
        {

        }

        public Carta(int valor)
        {
            this.Valor = valor;
        }
    }
}