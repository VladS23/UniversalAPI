namespace UniversalAPI
{
    public class Endpoints
    {
        WebApplication app;
        TokenManager tokens = new TokenManager();


        public Endpoints(WebApplication app)
        {
            this.app = app;
        }

        public void Run()
        {
            tokens.AddToken("123");

            app.Map("/vk/getOnlineStatus", HandleGetOnlineStatusRequest);

            app.Map("/cb/USDpurchaseRate", HandleUSDpurchaseRateRequest);
            app.Map("/cb/USDsellingRate", HandleUSDsellingRateRequest);

            app.Map("/hello", HandleHelloRequest);

            app.Run();
        }

        void HandleHelloRequest(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("hello!");
            });
        }

        void HandleGetOnlineStatusRequest(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                if (ContainsTokenAndUserId(context.Request.Query))
                {
                    string? token = context.Request.Query["token"];
                    string? userId = context.Request.Query["userId"];

                    if
                    (token != null
                    &&
                    tokens.CheckToken(token)
                    &&
                    userId != null)
                    {
                        var vk = new VK();
                        await context.Response.WriteAsync(vk.GetOnlineStatus(userId));
                    }
                    else
                    {
                        await context.Response.WriteAsync("Invalid APIToken");
                    }
                }
                else
                {
                    await context.Response.WriteAsync($"Invalid query");
                }
            });
        }

        void HandleUSDpurchaseRateRequest(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                if (ContainsToken(context.Request.Query))
                {
                    string? token = context.Request.Query["token"];
                    if (token != null && tokens.CheckToken(token))
                    {
                        var cb = new CentralBank();
                        await context.Response.WriteAsync(cb.USDpurchaseRate());
                    }
                    else
                    {
                        await context.Response.WriteAsync("Invalid APIToken");
                    }
                }
                else
                {
                    await context.Response.WriteAsync($"Invalid query");
                }
            });
        }

        void HandleUSDsellingRateRequest(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                if (ContainsToken(context.Request.Query))
                {
                    string? token = context.Request.Query["token"];
                    if (token != null && tokens.CheckToken(token))
                    {
                        var cb = new CentralBank();
                        await context.Response.WriteAsync(cb.USDsellingRate());
                    }
                    else
                    {
                        await context.Response.WriteAsync("Invalid APIToken");
                    }
                }
                else
                {
                    await context.Response.WriteAsync($"Invalid query");
                }
            });
        }

        bool ContainsTokenAndUserId(IQueryCollection query)
        {
            return query.ContainsKey("token") && query.ContainsKey("userId");
        }

        bool ContainsToken(IQueryCollection query)
        {
            return query.ContainsKey("token");
        }
    }
}
