using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTOs
{
    public class CurrencieDTO
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public int decimal_places { get; set; }
        public ToDolarDTO todolar { get; set; }

        public CurrencieDTO(dynamic obj, dynamic todolar)
        {
            this.id = obj.id;
            this.symbol = obj.symbol;
            this.description = obj.description;
            this.decimal_places = obj.decimal_places;
            this.todolar = new ToDolarDTO(todolar);
        }
    }

    public class ToDolarDTO
    {        
        public string currency_base { get; set; }
        public string currency_quote { get; set; }
        public double ratio { get; set; }
        public double rate { get; set; }
        public double inv_rate { get; set; }
        public string creation_date { get; set; }
        public string valid_until { get; set; }

        public ToDolarDTO(dynamic obj)
        {
            this.currency_base = obj.currency_base;
            this.currency_quote = obj.currency_quote;
            this.ratio = obj.ratio;
            this.rate = obj.rate;
            this.inv_rate = obj.inv_rate;
            this.creation_date = obj.creation_date;
            this.valid_until = obj.valid_until;
        }
        public ToDolarDTO() { }
    }
}