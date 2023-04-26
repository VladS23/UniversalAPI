using System.Text;

namespace UniversalAPI
{
    public class VK : Site
    {
        public override string BuildURL(string[] data)
        {
            return $"https://www.vk.com/" + new StringBuilder().Append(string.Join("/",data));
        }

        public string GetOnlineStatus(string userId)
        {
            string htmlCode = GetHtmlCode(userId);
            if (htmlCode.Contains("Online"))
            {
                return "Online";
            }
            else if (htmlCode.Length == 0)
            {
                return "Error";
            }
            else 
            {
                return "Ofline";
            }
        }

        private string GetHtmlCode(string userId)
        {
            string url = BuildURL(new String[] {userId});
            string result = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            result = content.ReadAsStringAsync().Result;
                        }
                    }
                }
                return result;
           }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
