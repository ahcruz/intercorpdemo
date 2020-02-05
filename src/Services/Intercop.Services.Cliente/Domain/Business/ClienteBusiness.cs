using Intercop.Services.Cliente.Domain.Repositories;
using Intercop.Services.Cliente.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intercop.Services.Cliente.Domain.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClientesRepository _clientesRepository;

        public ClienteBusiness(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public void AgregarCliente(Cliente cliente)
        {
            _clientesRepository.Add(cliente);
            _clientesRepository.Commit();
        }

        public KpiClientes ObtenerKpiDeClientes()
        {
            var edades = _clientesRepository.GetAll().ToList().Select(x => x.Edad);

            var media = GetMedia(edades);

            var cuadradoDistancia = GetSumaCuadradoDeDistacia(edades, media);

            var division = cuadradoDistancia / edades.Count();

            var desvioEstandar = Math.Sqrt(division);

            return new KpiClientes() { PromedioEdad = media, DesvioEstandar = desvioEstandar };
        }

        /// <summary>
        /// Obtiene la suma de el cuadrado de cada elemento menos la media
        /// </summary>
        /// <param name="edades"></param>
        /// <param name="media"></param>
        /// <returns></returns>
        private double GetSumaCuadradoDeDistacia(IEnumerable<int> edades, double media)
        {
            var cuadrados = new List<double>();

            foreach (var edad in edades)
            {
                var delta = edad - media;

                cuadrados.Add(delta * delta);
            }

            return cuadrados.Sum();
        }

        /// <summary>
        /// Obtiene la media de las edades
        /// </summary>
        /// <param name="edades"></param>
        /// <returns></returns>
        private double GetMedia(IEnumerable<int> edades)
        {
            double suma = 0;

            foreach (var edad in edades)
            {
                suma += edad;
            }

            return (suma / edades.Count());
        }

        public IEnumerable<ClientePosibleMuerte> ObtenerListaClientePosibeMuerte()
        {
            return _clientesRepository.GetAll().Select(x => new ClientePosibleMuerte(x.Nombre, x.Apellido, x.Edad, x.FechaNacimiento));
        }
    }
}
