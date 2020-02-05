using System;

namespace Intercop.Services.Cliente.Domain
{
    public class Cliente
    {
        public Guid ClienteId { get; private set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Apellido del cliente
        /// </summary>
        public string Apellido { get; private set; }

        /// <summary>
        /// Edad del cliente
        /// </summary>
        public int Edad { get; private set; }

        /// <summary>
        /// Fecha de nacimiento del cliente
        /// </summary>
        public DateTime FechaNacimiento { get; private set; }

        public Cliente(string nombre, string apellido, int edad, DateTime fechaNacimiento)
        {
            IsClientValid(edad, fechaNacimiento);
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            FechaNacimiento = fechaNacimiento;
            ClienteId = new Guid();
        }

        private void IsClientValid(int edad, DateTime fechaNacimiento)
        {
            if ((DateTime.Today.Year - fechaNacimiento.Year) != edad)
            {
                throw new Exception("La edad no corresponde con la fecha de nacimiento");
            }
        }
    }
}
