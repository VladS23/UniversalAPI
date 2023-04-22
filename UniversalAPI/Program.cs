using UniversalAPI;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

TokenManager tokens = new TokenManager();
//tokens.AddToken("123456789");

app.Map("/{token}/vk/getOnlineStatus/{userId}", HandleGetOnlineStatusRequest);

app.Map("/{token}/cb/USDpurchaseRate", HandleUSDpurchaseRateRequest);
app.Map("/{token}/cb/USDsellingRate", HandleUSDsellingRateRequest);

app.Run();



string HandleGetOnlineStatusRequest(string token, string userId)
{
    if (tokens.CheckToken(token))
    {
        var vk = new VK();
        return vk.GetOnlineStatus(userId);
    }
    return "Invalid APIToken";
}

string HandleUSDpurchaseRateRequest(string token)
{
    if (tokens.CheckToken(token))
    {
        var cb = new CentralBank();
        return cb.USDpurchaseRate();
    }
    return "Invalid APIToken";
}

string HandleUSDsellingRateRequest(string token)
{
    if (tokens.CheckToken(token))
    {
        var cb = new CentralBank();
        return cb.USDsellingRate();
    }
    return "Invalid APIToken";
}