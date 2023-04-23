using HtmlAgilityPack;

namespace UniversalAPI
{
    public class CentralBank : Site
    {
        public override string BuildURL(string data)
        {
            return "https://cbr.ru/" + data;
        }

        public string USDpurchaseRate()
        {
            string url = BuildURL("key-indicators/");
            string html = GetHTML(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var result = htmlDoc.DocumentNode.SelectNodes("/html/body/main/div/div/div/div[2]/div[2]/div[4]/div/div/table/tbody/tr[2]/td[2]")[0].InnerText;
            return result;
        }

        public string USDsellingRate()
        {
            string url = BuildURL("key-indicators/");
            string html = GetHTML(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var result = htmlDoc.DocumentNode.SelectNodes("/html/body/main/div/div/div/div[2]/div[2]/div[4]/div/div/table/tbody/tr[2]/td[3]/text()")[0].InnerText;
            return result;
        }

        private string GetHTML(string url)
        {
            string html;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        html = content.ReadAsStringAsync().Result;
                    }
                }
            }
            return html;
        }
    }
}
