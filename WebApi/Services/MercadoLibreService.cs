using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using WebApi.Models.DTOs;

namespace WebApi.Services
{
    public static class MercadoLibreService
    {
        
        /// <summary>
        /// metodo que consulta la api de mercadolibre para obtener todos los paises
        /// </summary>
        /// <returns>lista de paises</returns>
        public static dynamic GetCountries()
        {
            try
            {
                //creo la url del request
                var url = ConfigurationManager.AppSettings["URL_MERCADOLIBRE"] + "classified_locations/countries";

                //obtengo el resultado del request
                var json = new WebClient().DownloadString(url);

                //convierto el json a un objeto comprensible de c# y lo retorno
                return JsonConvert.DeserializeObject(json);                 
            }
            catch (WebException ex)
            {
                throw new Exception("Error en el servicio de mercado libre: " + ex.Message);
            }
        }

        /// <summary>
        /// metodo que consulta la api de mercadolibre
        /// con una busqueda especifica
        /// </summary>
        /// <param name="termino">termino a buscar</param>
        /// <returns></returns>
        internal static BusquedaDTO getBusqueda(string termino)
        {
            try
            {
                //creo la url del request
                var url = ConfigurationManager.AppSettings["URL_MERCADOLIBRE"] + "sites/MLA/search?q=" + termino;

                //obtengo el resultado del request
                var json = new WebClient().DownloadString(url);

                //convierto el json a un objeto comprensible de c#
                dynamic obj = JsonConvert.DeserializeObject(json);

                //creo el objeto DTO con los datos que se necesitan
                dynamic result = new BusquedaDTO(obj);

                //retorno el DTO
                return result;

            }
            catch (WebException ex)
            {
                throw new Exception("Error en el servicio de mercado libre: " + ex.Message);
            }
        }        

        /// <summary>
        /// Metodo que consulta la api de mercadolibre para obtener un pais especifico
        /// </summary>
        /// <param name="pais"></param>
        /// <returns></returns>
        internal static dynamic getSpecificCountrie(string pais)
        {

            try
            {
                //creo la url del request
                var url = ConfigurationManager.AppSettings["URL_MERCADOLIBRE"] + "classified_locations/countries/" + pais;

                //obtengo el resultado del request
                var json = new WebClient().DownloadString(url);

                //convierto el json a un objeto comprensible de c# y lo retorno
                return JsonConvert.DeserializeObject(json);
            }
            catch (WebException ex)
            {
                throw new Exception("Error en el servicio de mercado libre: " + ex.Message);
            }
        }

        /// <summary>
        /// obtiene los datos del cambio de moneda actual 
        /// </summary>
        /// <param name="from">moneda desde</param>
        /// <param name="to">moneda a la cual se realiza el cambio</param>
        /// <returns></returns>
        internal static dynamic getCurrencyConversions(string from, string to)
        {

            try
            {
                //creo la url del request
                var url = ConfigurationManager.AppSettings["URL_MERCADOLIBRE"] + "currency_conversions/search?from=" + from +"&to=" + to;

                //obtengo el resultado del request
                var json = new WebClient().DownloadString(url);

                //convierto el json a un objeto comprensible de c# y lo retorno
                return JsonConvert.DeserializeObject(json);
            }
            catch (WebException ex)
            {
                throw new Exception("Error en el servicio de mercado libre: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los tipos de moneda de la api de mercadolibre
        /// </summary>
        /// <returns>lista con todos los tipos de moneda</returns>
        internal static List<dynamic> getAllCurrencies()
        {

            try
            {
                //creo la url del request
                var url = ConfigurationManager.AppSettings["URL_MERCADOLIBRE"] + "currencies/";

                //obtengo el resultado del request
                var json = new WebClient().DownloadString(url);

                //convierto el json a un objeto comprensible de c# y lo retorno
                return JsonConvert.DeserializeObject<List<dynamic>>(json);
                //return JsonConvert.DeserializeObject(json);
            }
            catch (WebException ex)
            {
                throw new Exception("Error en el servicio de mercado libre: " + ex.Message);
            }
        }
    }
}