using Intercop.Services.Cliente.Dto;
using System.Collections.Generic;

namespace Intercop.Services.Cliente.Domain.Business
{
    public interface IClienteBusiness : IBusiness
    {
        void AgregarCliente(Cliente cliente);
        KpiClientes ObtenerKpiDeClientes();
        IEnumerable<ClientePosibleMuerte> ObtenerListaClientePosibeMuerte();
    }
}
