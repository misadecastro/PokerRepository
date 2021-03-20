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
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaController : ControllerBase
    {
        private readonly IHistoriaFacade _facade;
        private readonly IMapper _mapper;
        public HistoriaController(IHistoriaFacade facade, IMapper mapper)
        {
            this._facade = facade;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HistoriaDTO[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Historias = await _facade.GetAllAsync();
                var result = _mapper.Map<HistoriaDTO[]>(Historias);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HistoriaDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Historia = await _facade.GetAsync(id);
                var result = _mapper.Map<HistoriaDTO>(Historia);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(HistoriaDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(HistoriaPostDTO model)
        {
            try
            {
                var Historia = _mapper.Map<Historia>(model);
                if (await _facade.CreateAsync(Historia))
                {
                    return Created($"/api/Historia/{Historia.ID}", _mapper.Map<HistoriaDTO>(Historia));
                }
                return BadRequest();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(HistoriaDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Put(HistoriaDTO model)
        {
            try
            {
                var Historia = _mapper.Map<Historia>(model);
                if (await _facade.UpdateAsync(Historia))
                {
                    return Created($"/api/Historia/{model.ID}", model);
                }
                return BadRequest();
            }
            catch (System.Exception ex)
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
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}
