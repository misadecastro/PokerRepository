namespace Poker.Domain
{
    public class Carta
    {
        public int ID { get; set; }
        public int Valor { get; set; }
        public Carta()
        {

        }

        public Carta(int id, int valor)
        {
            this.ID = id;
            this.Valor = valor;
        }
    }
}