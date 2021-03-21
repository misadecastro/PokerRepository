using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Poker.API.DTOs;
using Poker.API.Hubs;
using Poker.API.Models;
using Poker.API.RabbitMQ;
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
        private readonly IHubContext<VotoHub> _votoHub;
        private readonly PublishVotoMQ _publishVotoMQ;
        public VotoController(IVotoFacade facade, IMapper mapper, AuthenticatedUser usuarioLogado, IHubContext<VotoHub> votoHub, PublishVotoMQ publishVotoMQ)
        {
            this._facade = facade;
            this._mapper = mapper;
            this._usuarioLogado = usuarioLogado;
            this._votoHub = votoHub;
            this._publishVotoMQ = publishVotoMQ;
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
                
                var votoRegistrado = await _facade.Votar(carta, historia, _usuarioLogado.Usuario);
                
                if (votoRegistrado.Invalid)
                    return BadRequest(votoRegistrado.Notifications);

                await _votoHub.Clients.All.SendAsync("ReceiveMessage", string.Format("Usuario: {0} - Historia: {1} - Voto: {2}", _usuarioLogado.Usuario.UserName, votoRegistrado.HistoriaId, votoRegistrado.CartaId));
                _publishVotoMQ.Publish(votoRegistrado);

                return Ok(votoRegistrado);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }    
}
