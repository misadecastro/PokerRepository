using Flunt.Notifications;

namespace Poker.Domain
{
    public class BaseEntity: Notifiable
    {
        public int ID { get; set; }
        public BaseEntity() { }
    }
}
