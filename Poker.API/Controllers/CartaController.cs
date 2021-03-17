using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poker.Domain;
using Poker.Repository;

namespace Poker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaController: ControllerBase
    {
        public readonly IPokerRepository _repositorio;
        public CartaController(IPokerRepository repositorio)
        {
            this._repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Carta model = new Carta(1, 3);
            return this.StatusCode(StatusCodes.Status200OK,model);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Carta model)
        {
            try    
            {
                _repositorio.Add(model);
                if(await _repositorio.SaveChangesAsync())                
                    return this.StatusCode(StatusCodes.Status201Created, "Carta Cadastrada com Sucesso");
                else
                    return BadRequest();
                
            }
            catch(System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}