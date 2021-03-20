using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poker.API.DTOs;
using Poker.API.Models;
using Poker.Domain;
using Poker.Domain.Identity;
using Poker.Facade.Interfaces;

namespace Poker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private readonly IVotoFacade _facade;
        private readonly IMapper _mapper;
        private readonly AuthenticatedUser _usuarioLogado;
        public VotoController(IVotoFacade facade, IMapper mapper, AuthenticatedUser usuarioLogado)
        {
            this._facade = facade;
            this._mapper = mapper;
            this._usuarioLogado = usuarioLogado;
        }

        /// <summary>
        /// Registrar voto do usuário em uma historia
        /// </summary>
        /// <param name="voto"></param>
        /// <returns></returns>
        [HttpPost("Votar")]
        [ProducesResponseType(typeof(Voto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IList<Notification>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Votar(VotoPostDTO voto)
        {
            try
            {
                var carta = _mapper.Map<Carta>(voto.Carta);
                var historia = _mapper.Map<Historia>(voto.Historia);
                var usuario = new User(_usuarioLogado.Id);
                
                var votoRegistrado = await _facade.Votar(carta, historia, usuario);
                
                if (votoRegistrado.Invalid)
                    return BadRequest(votoRegistrado.Notifications);

                return Ok(votoRegistrado);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }    
}
