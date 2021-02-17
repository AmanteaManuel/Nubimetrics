using System.Net.Http;
using System.Web.Http;
using WebApi.Response;
using WebApi.Services;
namespace WebApi.Controllers
{
    public class PaisesController : ApiController
    {

        /// <summary>
        /// Metodo que corresponde al Desafío 1: Crear endpoint “países”    
        /// </summary>
        /// <param name="pais"></param>
        /// <returns>pais a Buscar ej ARS, BR, CO...
        /// el id se puede obtener desde consultando el endpoint /Paises
        /// </returns>
        [HttpGet]
        [Route("Paises/{pais}")]
        public HttpResponseMessage getPais(string pais)
        {
            GerenicResposponse res = PaisService.getPais(pais);
            return Request.CreateResponse(res.statusCode, res.data);

        }

        /// <summary>
        /// Obtiene la lista de paises
        /// </summary>
        /// <returns>lista de paises</returns>
        [HttpGet]
        [Route("Paises")]
        public HttpResponseMessage getPaises()
        {
            GerenicResposponse res = PaisService.getPaises();
            return Request.CreateResponse(res.statusCode, res.data);

        }

    }
}
