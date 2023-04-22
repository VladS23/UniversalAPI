
namespace UniversalAPI
{
    public class Token
    {
        public long Id { get; set; }
        public string value { get; set; }
        public Token()
        {

        }
        public Token(string value)
        {
            this.value = value;
        }
    }
}
