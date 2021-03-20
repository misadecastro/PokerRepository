using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Poker.API.Models
{
    public class AuthenticatedUser
    {
		private readonly IHttpContextAccessor _accessor;

		public AuthenticatedUser(IHttpContextAccessor accessor)
		{
			_accessor = accessor;
			this.Nome = _accessor.HttpContext.User.Identity.Name;
            string idUsuario = _accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            int id = 0;
            if (int.TryParse(idUsuario, out id))
                this.Id = id;
        }

		public string Nome { get; private set; }
        public int Id { get; private set; }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
