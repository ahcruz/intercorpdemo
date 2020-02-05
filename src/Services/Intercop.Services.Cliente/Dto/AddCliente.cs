using Newtonsoft.Json;
using System;

namespace Intercop.Services.Cliente.Dto
{
    public class AddCliente
    {
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        [JsonProperty("nombre")]
        public string Nombre { get; private set; }

        /// <summary>
        /// Apellido del cliente
        /// </summary>
        [JsonProperty("apellido")]
        public string Apellido { get; private set; }

        /// <summary>
        /// Edad del cliente
        /// </summary>
        [JsonProperty("edad")]
        public int Edad { get; private set; }

        /// <summary>
        /// Fecha de nacimiento del cliente
        /// </summary>
        [JsonProperty("fechaNacimiento")]
        public DateTime FechaNacimiento { get; private set; }

        [JsonConstructor]
        public AddCliente(string nombre, string apellido, int edad, DateTime fechaNacimiento)
        {
            Nombre = NullOrEmpty(nombre);
            Apellido = NullOrEmpty(apellido);
            Edad = edad;
            FechaNacimiento = fechaNacimiento;
        }

        /// <summary>
        /// Deberia usar algun framework de validacion
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string NullOrEmpty(string word)
        {
            if (string.IsNullOrEmpty(word)) throw new Exception("No debe ser vacio");

            return word;
        }
    }
}
