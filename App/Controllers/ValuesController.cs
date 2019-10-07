﻿using Microsoft.AspNetCore.Mvc;

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
            // ARGENTINA 
            string dolar = $"ARG $ -> Dolar: {ApiClients.GetArgentinaLastCotization("usd")}";
            string dolarOficial = $"ARG $ -> Dolar Oficial: {ApiClients.GetArgentinaLastCotization("usd_of")}";

            List<string> values = new List<string>() { dolar, dolarOficial };

            // URUGUAY

            // Get Peso Argentino quotation
            Task<ExecuteResponse> response = ApiClients.GetUruguayLastCotizationForCoin(500);
            ExecuteResponse result = response.Result;
            values.Add(result.ToString());

            // Get Dollar USA quotation
            Task<ExecuteResponse> response2 = ApiClients.GetUruguayLastCotizationForCoin(2222);
            ExecuteResponse result2 = response2.Result;
            values.Add(result2.ToString());


            return values;
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