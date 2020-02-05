using Newtonsoft.Json;

namespace Intercop.Services.Cliente.Dto
{
    public class KpiClientes
    {
        [JsonProperty("promedioEdad")]
        public double PromedioEdad { get; set; }

        [JsonProperty("desvioEstandar")]
        public double DesvioEstandar { get; set; }
    }
}
