using Intercop.Services.Cliente.Domain.Business;
using Intercop.Services.Cliente.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Intercop.Services.Cliente.Controller
{
    [Route("")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClientesController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        /// <summary>
        /// Crea un cliente
        /// </summary>
        /// <param name="cliente">Objeto que recibe como parametros</param>
        /// <returns>Cliente creado</returns>
        /// <response code="200">Resultado correcto</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [Route("creacliente")]
        [HttpPost]
        public IActionResult Post(AddCliente cliente)
        {
            var clienteDomain = new Domain.Cliente(cliente.Nombre, cliente.Apellido, cliente.Edad, cliente.FechaNacimiento);

            _clienteBusiness.AgregarCliente(clienteDomain);

            return Ok(clienteDomain);
        }

        /// <summary>
        /// Obtiene KPI de Clientes
        /// </summary>
        /// <returns>Cliente creado</returns>
        /// <response code="200">Resultado correcto</response>
        /// <response code="500">Error interno del servidor</response>
        [Route("kpideclientes")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetKpiDeClientes()
        {
            return Ok(_clienteBusiness.ObtenerKpiDeClientes());
        }

        /// <summary>
        /// Obtiene lista de clientes con posible fecha de muerte
        /// </summary>
        /// <returns>Cliente creado</returns>
        /// <response code="200">Se agrego correctamente</response>
        /// <response code="500">Error interno del servidor</response>
        [Route("listclientes")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetList()
        {
            return Ok(_clienteBusiness.ObtenerListaClientePosibeMuerte());
        }
    }
}