var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("AccountService", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/api/account/");
});

builder.Services.AddHttpClient("BookingService", client =>
{
    client.BaseAddress = new Uri("https://localhost:5002/api/booking/");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("ApiGatewayPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("ApiGatewayPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
