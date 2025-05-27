var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:1453");
var app = builder.Build();

// HTTP pipeline yapılandırması
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// Statik dosyaların sunulması
app.UseStaticFiles();

app.MapControllers();

app.Run();