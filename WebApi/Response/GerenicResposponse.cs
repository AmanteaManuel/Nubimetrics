using System.Net;

namespace WebApi.Response
{
    //clase que modela la respuesta de los request de manera generica
    public class GerenicResposponse
    {

        //propiedad que modela el dato a retornar
        public object data { get; set; }

        //status code que retorna el request
        public HttpStatusCode statusCode { get; set; }


        //constructor con sobrecarga
        public GerenicResposponse (object _data, HttpStatusCode _statusCode)
        {
            this.data = _data;
            this.statusCode = _statusCode;
        }

        private GerenicResposponse() { }

    }
}