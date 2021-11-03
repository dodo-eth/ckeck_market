using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json; 
using System.Timers;
using System.Web;
using System.Net;
using System.Text;
using System.Threading;
using Telegram.Bot;

namespace ckeck_market
{
    class Program
    {
        static Int64 chanall_id = 401036948;
        static TelegramBotClient Bot_ntf;
        static void Main(string[] args)
        {
            string Bot_ntf_api = "1866819612:AAHKMvSXhcD3tuwub6L07Esp2rn1ExcSbYU";
            Bot_ntf = new TelegramBotClient(Bot_ntf_api);

              txt_horse();
        }


        static void kaka_nft()
        {
            while (true)
            {
                try
                {
                    var url = "https://www.binance.com/bapi/nft/v1/friendly/nft/artist-product-list";

                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                    httpRequest.Method = "POST";
                    httpRequest.Accept = "application/json";
                    httpRequest.Headers["clienttype"] = "web";
                    httpRequest.ContentType = "application/json";

                    var data = "{\"reSale\":\"\",\"tradeType\":0,\"currency\":\"\",\"amountFrom\":\"\",\"amountTo\":\"\",\"keyword\":\"\",\"orderBy\":\"list_time\",\"orderType\":-1,\"page\":1,\"rows\":100,\"creatorId\":\"49230611\"}";

                    using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        streamWriter.Write(data);
                    }

                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    string result = null;
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }

                    Console.WriteLine(httpResponse.StatusCode);
                    var tar_price = JsonConvert.DeserializeObject<json.Root>(result);


                    for (int i = 0; i < tar_price.Data.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(tar_price.Data.Rows[i].Amount) < 500)
                        {
                            string url_out = "https://www.binance.com/ru/nft/goods/detail?productId=" + tar_price.Data.Rows[i].ProductId + "&isOpen=false&isProduct=1";

                            Console.WriteLine(url_out);
                            Bot_ntf.SendTextMessageAsync(chanall_id, url_out);

                        }
                    }

                    Thread.Sleep(5000);
                }
                catch
                {

                }
               
            }
        }
        static void txt_horse()
        {
            List<string> product = new List<string>();
            for (int page = 1; page < 10; page++)
            {
                var url = "https://www.binance.com/bapi/nft/v1/friendly/nft/layer-product-list";

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                httpRequest.Method = "POST";
                httpRequest.Accept = "application/json";
                httpRequest.Headers["clienttype"] = "web";
                httpRequest.ContentType = "application/json";

                var data = "{\"reSale\":\"\",\"tradeType\":0,\"currency\":\"BNB\",\"amountFrom\":\"\",\"amountTo\":\"\",\"keyword\":\"\",\"orderBy\":\"list_time\",\"orderType\":-1,\"page\":"+page+",\"rows\":100,\"collectionId\":\"507186726677291009\"}";

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                string result = null;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                Console.WriteLine(httpResponse.StatusCode);
                var tar_price = JsonConvert.DeserializeObject<json.Root>(result);


                for (int i = 0; i < tar_price.Data.Rows.Count; i++)
                {
                    if (tar_price.Data.Rows[i].Amount.ToString() == "0.5")
                    {

                        product.Add(tar_price.Data.Rows[i].ProductId.ToString());

                    }
                }


            }
            File.WriteAllLines("test.txt", product);
            var list = File.ReadLines("test.txt").ToList();
        }
    }
}
