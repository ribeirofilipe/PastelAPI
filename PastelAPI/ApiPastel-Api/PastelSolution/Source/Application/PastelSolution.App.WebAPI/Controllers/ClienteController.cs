using PastelSolution.App.Services.Interfaces.AppService;
using PastelSolution.App.Services.ViewModels;
using PastelSolution.Domain.Models;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PastelSolution.App.Services.Inputs;

namespace PastelSolution.App.WebAPI.Controllers
{
    [RoutePrefix("api/Cliente")]

    public class ClienteController : ApiController
    {
        private readonly  IClienteAppService _serviceBase;

        public ClienteController(IClienteAppService serviceBase)
        {
            _serviceBase = serviceBase;
        }

        /// <summary>
        /// Método para buscar um cliente pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>Obtém um cliente pelo Id</remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(Cliente))]
        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            return Ok(await _serviceBase.GetByIdAsync(id));
            
        }

        /// <summary>
        /// Método para buscar todos os clientes
        /// </summary>
        /// <returns></returns>
        /// <remarks>Obtém todos os clientes</remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(Cliente))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _serviceBase.GetListAsync());
        }

        /// <summary>
        /// Método para inserir um novo cliente
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>Inserindo um novo cliente</remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(Cliente))]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ClienteInput input)
        {          
             await _serviceBase.AddAsync(input);
            return Created(Request.RequestUri + "/" + input.Nome, input);
        }

        /// <summary>
        /// Método para alterar um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>Alterando um cliente existente</remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(Cliente))]
        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] ClienteViewModel input)
        {
            await _serviceBase.UpdateAsync(input, id);
            return Ok(input);
        }

        /// <summary>
        /// Método para deletar um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>Deletando um cliente</remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(Cliente))]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            var cliente = await _serviceBase.GetByIdAsync(id);
            await _serviceBase.DeleteAsync(cliente, id);
            return Ok();
        }

    }
}
