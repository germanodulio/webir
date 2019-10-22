using BL;

using Common;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using static Common.Enums;

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
                Core.GetLastQuotation(CoinCode.DolarArgBlue), 
                Core.GetLastQuotation(CoinCode.DolarUy), 
                Core.GetLastQuotation(CoinCode.PesoArgUy) };
        }

        // GET: api/Quotations/{code}
        [HttpGet("{code}", Name = "Get")]
        public object Get(string code)
            // DolarUy, DolarArg, DolarBlue, PesoArgUy, Best
        {
            if (code == "Best")
            {
                return Core.GetMostConvenientCurrency(DateTime.Today.Date);
            }
            CoinCode coinCode = Enum.Parse<CoinCode>(code);
            return Core.GetLastQuotation(coinCode);
        }
    }
}
