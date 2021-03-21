using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Poker.Domain.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Poker.API.Models
{
    public class AuthenticatedUser
    {
		private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<User> _userManager;

        public AuthenticatedUser(IHttpContextAccessor accessor, UserManager<User> userManager)
		{
			_accessor = accessor;
            _userManager = userManager;			            
            this.Usuario = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
        }
        public User Usuario { get; private set; }
        
    }
}
