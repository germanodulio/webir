using Microsoft.AspNetCore.Mvc;

using Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using Uruguay;

namespace webirBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        { 
            // Get Peso Argentino cotization
            Task<ExecuteResponse> response = ApiClients.getValueAsync(500);

            ExecuteResponse result = response.Result;
            return new string[] { result.Salida.datoscotizaciones[0].Nombre,
                result.Salida.datoscotizaciones[0].Fecha.ToString(),
                "Compra: " + result.Salida.datoscotizaciones[0].TCC.ToString(),
                "Venta: " + result.Salida.datoscotizaciones[0].TCV.ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
