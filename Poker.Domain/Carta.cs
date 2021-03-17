namespace Poker.Domain
{
    public class Carta
    {
        public int ID { get; private set; }
        public int Valor { get; private set; }
        public Carta(){}

        public Carta(int id, int valor)
        {
            this.ID = id;
            this.Valor = valor;
        }
    }
}