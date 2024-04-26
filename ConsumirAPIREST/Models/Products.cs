using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;


namespace ConsumirAPIREST.Modelo
{

    public class Product
    {
        [JsonPropertyName("product_id")]
        public String ProductId { get; set; }

        [JsonPropertyName("product_name")]
        public string ProductName { get; set; }

        [JsonPropertyName("product_price")]
        public String ProductPrice { get; set; }

        [JsonPropertyName("category_id")]
        public String CategoryId { get; set; }
    }

}