namespace UniversalAPI
{
    public interface ITokenManager
    {
        public void AddToken(string token);
        public void RemoveToken(string token);
        public bool CheckToken(string token);
    }
}
