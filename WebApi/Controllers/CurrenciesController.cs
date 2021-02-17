using System;
using System.Net.Http;
using System.Web.Http;
using WebApi.Response;
using WebApi.Services;

namespace WebApi.Controllers
{
    //Desafío 4: Consumir datos de endpoints
    public class CurrenciesController : ApiController
    {
        /// <summary>
        /// Obtiene todos los datos de las monedas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Currencies")]
        public HttpResponseMessage GetAll()
        {
            //obtengo el tipo de moneda
            GerenicResposponse res = CurrenciesService.getAll();

            //retorno el request
            return Request.CreateResponse(res.statusCode, res.data);
        }

        /// <summary>
        /// obtiene los datos de cambio entre 2 monedas
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Currencies/from/{from}/to/{to}")]
        public HttpResponseMessage GetCurrencies(string from, string to)
        {
            //obtengo la conversion de la moneda
            GerenicResposponse res = CurrenciesService.getCurrencyConversions(from, to);

            //retorno el request
            return Request.CreateResponse(res.statusCode, res.data);
        }

        /// <summary>
        /// obtiene los datos de todas las monedas agregando el cambio actal a "USD"
        /// y genera un archivo csv con el ratio actual de las monedas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Currencies/all")]
        public HttpResponseMessage GetAllCurrencies()
        {
            //obtengo la lista de paises con el cambio a dolar y escribo el archivo
            GerenicResposponse res = CurrenciesService.getAllCurrencies();

            //retorno el request
            return Request.CreateResponse(res.statusCode, res.data);
        }
    }
}
