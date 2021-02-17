using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Response;

namespace WebApi.Services
{
    public class BusquedaService
    {
        /// <summary>
        /// Metodo que cosnulta la api de Mercado libre
        /// </summary>
        /// <param name="termino">termino con que realiza la busqueda</param>
        /// <returns></returns>
        internal static GerenicResposponse getBusqueda(string termino)
        {
            //consulto la api y retorno el resutado
            return new GerenicResposponse(MercadoLibreService.getBusqueda(termino), System.Net.HttpStatusCode.OK);

        }
    }
}