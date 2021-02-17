using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Response;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class BusquedaController : ApiController
    {
        /// <summary>
        /// End Point que resuelve el Desafío 2: Crear endpoint “búsqueda”:
        /// </summary>
        /// <param name="termino">termino a buscar</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Busqueda/{termino}")]
        public HttpResponseMessage getPaises(string termino)
        {
            //realizo la busqueda sobre la api
            GerenicResposponse res = BusquedaService.getBusqueda(termino);

            //retorno
            return Request.CreateResponse(res.statusCode, res.data);
        }
    }
}
