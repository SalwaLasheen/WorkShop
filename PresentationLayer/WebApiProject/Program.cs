var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ignore null value
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
//CALL CLIENT
string baseUrl = builder.Configuration.GetSection("ClientBaseURl").Value.ToString();
builder.Services.AddHttpClient("WsdlService", httpClient =>
{
    httpClient.BaseAddress = new Uri(baseUrl);
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:44435", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger();
}


app.UseHttpsRedirection();
app.UseCors(builder =>
{
    builder
  .AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader();
});
app.UseAuthorization();
app.MapControllers();

app.Run();

