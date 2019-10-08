using BL;

using Common;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using static Common.Utils;

namespace webirBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationsController : ControllerBase
    {
        // GET: api/Quotations
        [HttpGet]
        public IEnumerable<Quotation> Get()
        {
            return new List<Quotation>() { 
                Core.GetLastQuotation(CoinCode.DolarArg), 
                Core.GetLastQuotation(CoinCode.DolarBlue), 
                Core.GetLastQuotation(CoinCode.DolarUy), 
                Core.GetLastQuotation(CoinCode.PesoArgUy) };
        }

        // GET: api/Quotations/5
        [HttpGet("{currencyCode}", Name = "Get")]
        public object Get(string currencyCode)
            // DolarUy, DolarArg, DolarBlue, PesoArgUy, Best
        {
            if (currencyCode == "Best")
            {
                return Core.GetMostConvenientCurrency(DateTime.Today);
            }
            CoinCode code = Enum.Parse<CoinCode>(currencyCode);
            return Core.GetLastQuotation(code);
        }
    }
}
