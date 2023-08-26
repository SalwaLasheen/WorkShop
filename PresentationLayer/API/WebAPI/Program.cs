var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


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

builder.Services.AddServiceInjection(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            //Angular URL
            string frontUrl = builder.Configuration.GetSection("FrontBaseURL").Value.ToString();
            builder.WithOrigins(frontUrl)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();



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

