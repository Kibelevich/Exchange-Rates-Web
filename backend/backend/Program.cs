using BL.API;
using BL.Implementation;
using DAL.API;
using DAL.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CurrenciesRepo>();
builder.Services.AddScoped<ExchangeRatesRepo>();

builder.Services.AddScoped<IExchangeRateService, ExchangeRateService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:5173");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSPolicy");

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();