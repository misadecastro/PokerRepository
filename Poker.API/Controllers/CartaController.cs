using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poker.API.DTOs;
using Poker.Domain;
using Poker.Facade.Interfaces;

namespace Poker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaController: ControllerBase
    {
        private readonly ICartaFacade _facade;
        private readonly IMapper _mapper;
        public CartaController(ICartaFacade facade, IMapper mapper)
        {
            this._facade = facade;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CartaDTO[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            try    
            {
                var cartas = await _facade.GetAllAsync();
                var result = _mapper.Map<CartaDTO[]>(cartas);

                return Ok(result);
            }
            catch(System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CartaDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            try    
            {
                var carta = await _facade.GetAsync(id);
                var result = _mapper.Map<CartaDTO>(carta);
                return Ok(result);
            }
            catch(System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }            
        }        

        [HttpPost]
        [ProducesResponseType(typeof(CartaDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(CartaPostDTO model)
        {
            try    
            {
                var carta = _mapper.Map<Carta>(model);
                if(await _facade.CreateAsync(carta))
                {
                    return Created($"/api/carta/{carta.ID}",_mapper.Map<CartaDTO>(carta));
                }
                return BadRequest();
            }
            catch(System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(CartaDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Put(CartaDTO model)
        {
            try    
            {
                var carta = _mapper.Map<Carta>(model);
                if (await _facade.UpdateAsync(carta))
                {
                    return Created($"/api/carta/{model.ID}",model);
                }
                return BadRequest();
            }
            catch(System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try    
            {
                _facade.Delete(id);
                return Ok();
            }
            catch(System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}