using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intercop.Services.Cliente.Dto
{
    public class ClientePosibleMuerte : Domain.Cliente
    {
        private int edadPromedioVida = 71;
        public DateTime FechaProbableMuerte { get; private set; }

        public ClientePosibleMuerte(string nombre, string apellido, int edad, DateTime fechaNacimiento, Guid clienteId) : base(nombre, apellido, edad, fechaNacimiento, clienteId)
        {
            var aniosRestantesDeVida = edadPromedioVida - edad;

            FechaProbableMuerte = fechaNacimiento.AddYears(aniosRestantesDeVida);
        }
    }
}
