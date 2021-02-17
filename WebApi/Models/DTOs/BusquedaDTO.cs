using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTOs
{
    public class BusquedaDTO
    {

        public string site_id { get; set; }
        public string query { get; set; }
        public dynamic paging { get; set; }

        public List<ResultDTO> results { get; set; }

        public BusquedaDTO(dynamic obj)
        {
            this.site_id = obj.site_id;
            this.query = obj.query;
            this.paging = obj.paging;
            this.results = createNewResultList(obj.results);

        }

        private List<ResultDTO> createNewResultList(dynamic results)
        {
            List<ResultDTO> returnCollection = new List<ResultDTO>();
            foreach (var item in results)
            {
                returnCollection.Add( new ResultDTO(item));
            }
            return returnCollection;
        }
    }

    public class ResultDTO
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public int seller_id { get; set; }
        public string permalink { get; set; }

        public ResultDTO(dynamic obj)
        {
            this.id = obj.id;
            this.site_id = obj.site_id;
            this.title = obj.title;
            this.price = obj.price;
            this.seller_id = obj.seller.id;
            this.permalink = obj.permalink;

        }
    }
}