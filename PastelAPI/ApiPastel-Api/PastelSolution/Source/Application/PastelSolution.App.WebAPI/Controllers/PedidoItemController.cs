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
    [RoutePrefix("api/PedidoItem")]

    public class PedidoItemController : ApiController
    {
        private readonly IPedidoItemAppService _serviceBase;

        public PedidoItemController(IPedidoItemAppService serviceBase)
        {
            _serviceBase = serviceBase;
        }

        /// <summary>
        /// Método para buscar um pedidoItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(PedidoItem))]
        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _serviceBase.GetByIdAsync(id));
        }

        /// <summary>
        /// Método para buscar todos os pedidosItens
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(PedidoItem))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _serviceBase.GetListAsync());
        }

        /// <summary>
        /// Método para inserir um novo pedidoItem
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(PedidoItem))]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] PedidoItemInput input)
        {
            await _serviceBase.AddAsync(input);
            return Created(Request.RequestUri + "/", input);
        }

        /// <summary>
        /// Métodos para alterar um pedidoItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(PedidoItem))]
        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] PedidoItemViewModel input)
        {
            await _serviceBase.UpdateAsync(input, id);
            return Ok(input);
        }

        /// <summary>
        /// Método para deletar um pedidoItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <Response code="200">Ok</Response>
        /// <Response code="400">BadRequest</Response>
        /// <Response code="500">InternalServerError</Response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(PedidoItem))]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var cliente = await _serviceBase.GetByIdAsync(id);
            await _serviceBase.DeleteAsync(cliente, id);
            return Ok();
        }
    }
}
