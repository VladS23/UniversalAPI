namespace UniversalAPI
{
    public class TokenManager: ITokenManager
    {
        static Database db;
        public TokenManager()
        {
            db = new Database();
        }
        public void AddToken(string token)
        {
            if (!TokenInDb(token))
            {
                Token t = new Token(token);
                Database.db.Add(t);
                Database.db.SaveChanges();
            }
        }
        public void RemoveToken(string token)
        {
            if (TokenInDb(token))
            {
                Token t = new Token(token);
                Database.db.Remove(t);
                Database.db.SaveChanges();
            }
        }
        public bool CheckToken(string token)
        {
            return TokenInDb(token);
        }
        private bool TokenInDb(string token)
        {
            return Database.db.Tokens.Where(t => t.value == token).ToList().Count==1;
        }
    }
}
