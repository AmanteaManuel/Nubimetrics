using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WebApi.Response;


namespace WebApi.Services
{
    public class PaisService
    {

        /// <summary>
        /// este metodo se encarga de procesar el parametro y retornar el valor correspondiente
        /// </summary>
        /// <param name="pais">pais a procesa ej: AR, COL, BR</param>
        /// <returns>respuesta generica basado al parametro</returns>
        internal static GerenicResposponse getPais(string pais)
        {
            switch (pais)
            {
                case "AR":
                    return new GerenicResposponse( MercadoLibreService.getSpecificCountrie(pais), HttpStatusCode.OK);

                case "BR":
                    return new GerenicResposponse(null, HttpStatusCode.Unauthorized);

                case "CO":
                    return new GerenicResposponse(null, HttpStatusCode.Unauthorized);

                default:
                    return new GerenicResposponse(null, HttpStatusCode.OK);
            }
        }

        /// <summary>
        /// metodo que se comunica con el service para la obtencion de los datos de todos los paises
        /// </summary>
        /// <returns></returns>
        internal static GerenicResposponse getPaises()
        {
            //consulto la api de y retorno la respuesta generica
            return new GerenicResposponse(MercadoLibreService.GetCountries(), HttpStatusCode.OK);

        }


    }
}