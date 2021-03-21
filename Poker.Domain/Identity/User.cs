using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Poker.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
        public List<UserRole> UserRoles {get; set;}
        public virtual List<Voto> Votos {get; set;}
        public User()
        {

        }
        public User(int id)
        {
            this.Id = id;
        }
    }
}