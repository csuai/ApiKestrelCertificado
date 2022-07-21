var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(so =>
{
    so.ListenAnyIP(7001, listenOpt =>
    {
        listenOpt.UseHttps(
          builder.Configuration["CertPath"],
          builder.Configuration["CertPassword"]);
    });
    so.ListenAnyIP(5000);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();