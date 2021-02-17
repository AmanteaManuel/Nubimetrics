using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Request;
using WebApi.Response;
using WebApi.Services;

namespace WebApi.Controllers
{
    //Desafío 3: Crear endpoint “usuarios”:
    public class UsuarioController : ApiController
    {

        /// <summary>
        /// Obtengo un usuario de la base de datos segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Usuario/{id}")]
        public HttpResponseMessage getUsuario(int id)
        {
            Usuario res = UsuarioService.GetUserById(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        /// <summary>
        /// Obtiene todos los usuario de la bd
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Usuario/getAll")]
        public HttpResponseMessage getUsuario()
        {
            List<Usuario> res = UsuarioService.GetAllUsers();
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        /// <summary>
        /// Inserta el usuario pasado por el body en la bd
        /// </summary>
        /// <param name="usuario">usuairo a insertar</param>
        /// <returns>id del usuairo insertado</returns>
        [HttpPost]
        [Route("Usuario/create")]
        public HttpResponseMessage CreateUsuario([FromBody] ReqCreateUsuario usuario)
        {
            int res = UsuarioService.CreateUser(usuario);
            return Request.CreateResponse(HttpStatusCode.Created, res);
        }

        /// <summary>
        /// metodo que modifica el usuario de la bd
        /// </summary>
        /// <param name="usuario">usuario modificado</param>
        /// <returns>true en caso de que se haya actualizado false en caso contrario</returns>
        [HttpPut]
        [Route("Usuario/update")]
        public HttpResponseMessage UpdateUsuario([FromBody] ReqUpdateUsuario usuario)
        {
            bool res = UsuarioService.UpdateUser(usuario);
            return Request.CreateResponse(HttpStatusCode.Created, res);
        }

        /// <summary>
        /// Metodo que elimina permanentemente un usuario de la bd
        /// </summary>
        /// <param name="id">id del usuario a eliminar</param>
        /// <returns>true en caso que se haya modificado false en caso contrario</returns>
        [HttpDelete]
        [Route("Usuario/delete/{id}")]
        public HttpResponseMessage DeleteUsuario(int id)
        {
            bool res = UsuarioService.DeleteUsuario(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
