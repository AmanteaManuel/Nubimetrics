using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.DTOs;
using WebApi.Response;

namespace WebApi.Services
{
    public class CurrenciesService
    {
        /// <summary>
        /// Obtengo todas las monedas actuales desde la api de mercadolibre
        /// </summary>
        /// <returns></returns>
        internal static GerenicResposponse getAll()
        {
            return new GerenicResposponse(MercadoLibreService.getAllCurrencies(), System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// obtengo correncies (valor entre monedas)
        /// </summary>
        /// <param name="from">de que moneda</param>
        /// <param name="to">a cual moneda</param>
        /// <returns>GerenicResposponse con datos del request</returns>
        internal static GerenicResposponse getCurrencyConversions(string from, string to)
        {
            //hago la consulta al service y retorno
            return  new GerenicResposponse(MercadoLibreService.getCurrencyConversions(from, to), System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// metodo que obtiene los currencies y retorna con el todolar
        /// adicionalemente este metodo escribe el archivo csv en el disto
        /// </summary>       
        /// <returns></returns>
        internal static GerenicResposponse getAllCurrencies()
        {
            //obtengo los datos de la api
            List<dynamic> currencies = MercadoLibreService.getAllCurrencies();

            //genero el dto y escribo el csv
            List<CurrencieDTO> currenciesDTO = generateCurrenciesDTOs(currencies);

            //retorno
            return new GerenicResposponse(currenciesDTO, System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Metodo que genera el DTO de currencies con el item todolar
        /// </summary>
        /// <param name="currencies">lista de todos los currencies</param>
        /// <returns>lista en formato CurrencieDTO</returns>
        private static List<CurrencieDTO> generateCurrenciesDTOs(List<dynamic> currencies)
        {
            
            //instancio lista a retornar
            List<CurrencieDTO> returnCollection = new List<CurrencieDTO>();

            //recorro la lista de datos
            foreach (var item in currencies)
            {
                dynamic todolar;
                /*este if rechaza las peticiones de Bolivar fuerte y Bolivar soberano ya que en la peticion currencies da 403*/
                if (Convert.ToString(item.id) == "VEF" || Convert.ToString(item.id) == "VES")
                    todolar = new ToDolarDTO();
                else
                {//obtengo el currencie a dolar (todolar)
                    todolar = MercadoLibreService.getCurrencyConversions(Convert.ToString(item.id), "USD");
                    CSVFilesServices.WriteCSV(Convert.ToString(todolar.ratio));
                }
                //lo agrego a la lista de retorno
                returnCollection.Add(new CurrencieDTO(item, todolar));                
                
            }

            //retorno la lista
            return returnCollection;
            
        }
    }
}