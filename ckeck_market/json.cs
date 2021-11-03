using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ckeck_market
{
    class json
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Owner
        {
            [JsonProperty("userId")]
            public int UserId { get; set; }

            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("nickName")]
            public string NickName { get; set; }

            [JsonProperty("artist")]
            public bool Artist { get; set; }
        }

        public class Creator
        {
            [JsonProperty("userId")]
            public int UserId { get; set; }

            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("nickName")]
            public string NickName { get; set; }

            [JsonProperty("artist")]
            public bool Artist { get; set; }
        }

        public class Approve
        {
            [JsonProperty("count")]
            public int Count { get; set; }

            
        }

        public class Row
        {
            [JsonProperty("productId")]
            public string ProductId { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("coverUrl")]
            public string CoverUrl { get; set; }

            [JsonProperty("tradeType")]
            public int TradeType { get; set; }

            [JsonProperty("nftType")]
            public int NftType { get; set; }

            [JsonProperty("amount")]
            public string Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("setStartTime")]
            public object SetStartTime { get; set; }

            [JsonProperty("setEndTime")]
            public object SetEndTime { get; set; }

            [JsonProperty("timestamp")]
            public object Timestamp { get; set; }

            [JsonProperty("rarity")]
            public int Rarity { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }

            [JsonProperty("owner")]
            public Owner Owner { get; set; }

            [JsonProperty("creator")]
            public Creator Creator { get; set; }

            [JsonProperty("mediaType")]
            public string MediaType { get; set; }

            [JsonProperty("favorites")]
            public int Favorites { get; set; }

            [JsonProperty("network")]
            public string Network { get; set; }

            [JsonProperty("approve")]
            public Approve Approve { get; set; }
        }

        public class Data
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("rows")]
            public List<Row> Rows { get; set; }
        }

        public class Root
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("message")]
            public object Message { get; set; }

            [JsonProperty("messageDetail")]
            public object MessageDetail { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }

            [JsonProperty("success")]
            public bool Success { get; set; }
        }





    }
}
