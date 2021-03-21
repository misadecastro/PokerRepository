using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace Poker.Domain
{
    public class BaseEntity: Notifiable
    {
        [Key]
        public int ID { get; set; }
        public BaseEntity() { }
    }
}
