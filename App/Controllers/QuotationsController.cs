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
                Core.GetLastQuotation(CoinCode.PesoArgUy)
            };
        }

        // GET: api/Quotations/{code}
        [HttpGet("{code}", Name = "Get")]
        public object Get(string code)
        // DolarUy, DolarArg, DolarBlue, PesoArgUy
        {
            if (Enum.TryParse(code, out CoinCode coinCode))
            {
                return Core.GetLastQuotation(coinCode);
            }
            return $"El código '{code}' enviado no es válido.";
        }

        [Route("[action]/{dateStr}")] // api/Quotations/Best/dd-MM-YYYY
        [HttpGet]
        public object Best(string dateStr)
        {
            DateTime date = DateTime.Parse(dateStr);
            return Core.GetMostConvenientCurrency(date);
        }

        [HttpPost]
        public object GetList(string[] codes, DateTime startTime, DateTime endTime)
        {
            return Core.GetCotizationsBetween(new List<string>(codes), startTime.Date, endTime.Date);
        }
    }
}
