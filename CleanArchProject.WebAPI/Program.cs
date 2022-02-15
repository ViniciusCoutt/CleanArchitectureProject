using CleanArchProject.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/** M�todo de extens�o para a resolu��o das depend�ncias e defini��es do banco de dados  **/
builder.Services.AddInfraestructure(builder.Configuration);
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
