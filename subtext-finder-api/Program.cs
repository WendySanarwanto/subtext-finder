var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Enable CORS
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.WithOrigins("http://localhost:3000", "https://subtext-finder-reactjs.herokuapp.com", "http://subtext-finder-reactjs.herokuapp.com/");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
}
else
{
    builder.Services.AddSwaggerGen(config =>
    {
        config.SwaggerDoc("SubtextFinderAPIv1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "SubtextFinderAPI",
            Version = "v1"
        });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
