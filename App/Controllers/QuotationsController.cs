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
        public object Get()
        {
            try
            {
                return new List<Quotation>() {
                Core.GetLastQuotation(CoinCode.DolarArg),
                Core.GetLastQuotation(CoinCode.DolarArgBlue),
                Core.GetLastQuotation(CoinCode.DolarUy),
                Core.GetLastQuotation(CoinCode.PesoArgUy)
                };
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // GET: api/Quotations/{code}
        [HttpGet("{code}", Name = "Get")]
        public object Get(string code)
        // DolarUy, DolarArg, DolarArgBlue, PesoArgUy
        {
            if (Enum.TryParse(code, out CoinCode coinCode))
            {
                return Core.GetLastQuotation(coinCode);
            }
            return $"El código '{code}' enviado no es válido.";
        }

        [Route("[action]/{dateStr}")]
        // api/Quotations/Best/dd-MM-YYYY
        [HttpGet]
        public object Best(string dateStr)
        {
            try
            {
                DateTime date = DateTime.Parse(dateStr);
                return Core.GetMostConvenientCurrency(date);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet("range")]
        // https://localhost:44317/api/Quotations/range?codes=DolarUy&codes=DolarArg&startTime=1-11-2019&endTime=10-11-2019
        public object GetList([FromQuery(Name = "codes")]string[] codes, string startTime, string endTime)
        {
            try
            {
                DateTime inicio = DateTime.Parse(startTime);
                DateTime fin = DateTime.Parse(endTime);
                return Core.GetCotizationsBetween(new List<string>(codes), inicio, fin);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
