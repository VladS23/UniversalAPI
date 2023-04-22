var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.Map("/{token}/vk/getOnlineStatus/{userId}", (string token, string userId) => $"TODO1");
app.Map("/{token}/vk/getVerification/{userId}", (string token, string userId) => $"TODO2");

app.Map("/{token}/moex/USDpurchaseRate", (string token) => $"TODO3");
app.Map("/{token}/moex/USDsellingRate", (string token) => $"TODO4");

app.Run();