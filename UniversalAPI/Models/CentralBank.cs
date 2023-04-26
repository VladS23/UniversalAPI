using HtmlAgilityPack;
using System.Text;

namespace UniversalAPI
{
    public class CentralBank : Site
    {
        public override string BuildURL(string[] data)
        {
            return "https://cbr.ru/" + new StringBuilder().Append(string.Join("/", data));
        }

        public string USDpurchaseRate()
        {
            string url = BuildURL(new string[]{ "key-indicators"});
            string html = GetHTML(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var result = htmlDoc.DocumentNode.SelectSingleNode("//div[text()=\"Доллар США\"]/../../../td[2]").InnerText;
            return result;
        }

        public string USDsellingRate()
        {
            string url = BuildURL(new String[] { "key-indicators" });
            string html = GetHTML(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var result = htmlDoc.DocumentNode.SelectSingleNode("//div[text()=\"Доллар США\"]/../../../td[3]").InnerText;
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
