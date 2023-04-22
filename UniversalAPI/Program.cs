using UniversalAPI;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

TokenManager tokens = new TokenManager();
//tokens.AddToken("123456789");

app.Map("/{token}/vk/getOnlineStatus/{userId}", HandleGetOnlineStatusRequest);
app.Map("/{token}/vk/getVerification/{userId}", HandleGetVerificationRequest);

app.Map("/{token}/cb/USDpurchaseRate", HandleUSDpurchaseRateRequest);
app.Map("/{token}/cb/USDsellingRate", HandleUSDsellingRateRequest);

app.Run();



string HandleGetOnlineStatusRequest(string token, string userId)
{
    if (tokens.CheckToken(token))
    {
        return "TODO1";
    }
    return "Invalid APIToken";
}

string HandleGetVerificationRequest(string token, string userId)
{
    if (tokens.CheckToken(token))
    {
        return "TODO2";
    }
    return "Invalid APIToken";
}

string HandleUSDpurchaseRateRequest(string token)
{
    if (tokens.CheckToken(token))
    {
        return "TODO3";
    }
    return "Invalid APIToken";
}

string HandleUSDsellingRateRequest(string token)
{
    if (tokens.CheckToken(token))
    {
        return "TODO4";
    }
    return "Invalid APIToken";
}