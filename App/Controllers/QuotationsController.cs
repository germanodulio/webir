using BL;

using Common;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;

namespace webirBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationsController : ControllerBase
    {
        // GET: api/Quotations
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Quotations/5
        [HttpGet("{id}", Name = "Get")]
        public Quotation Get(int currencyId)
        {
            return Core.GetLastQuotation(currencyId);
        }

        //// POST: api/Quotations
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Quotations/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
