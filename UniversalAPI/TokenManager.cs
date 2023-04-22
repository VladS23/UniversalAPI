namespace UniversalAPI
{
    public class TokenManager: ITokenManager
    {
        static Database db = new Database();
        public void AddToken(string token)
        {
            Token t;
            if (Database.db.Tokens.Where(t => t.value == token).ToList().Count == 1)
            {
                Database.db.Add(token);
                Database.db.SaveChanges();
            }
        }
        public void RemoveToken(string token)
        {
            Token t;
            if (Database.db.Tokens.Where(t => t.value == token).ToList().Count == 1)
            {
                Database.db.Remove(token);
                Database.db.SaveChanges();
            }
        }
        public bool CheckToken(string token)
        {
            Token t;
            return Database.db.Tokens.Where(t => t.value == token).ToList().Count == 1;
        }
    }
}
