using Blog.Data;

var builder = WebApplication.CreateBuilder(args);
// Adicionado os controllers
builder.Services.AddControllers();
builder.Services.AddDbContext<BlogDataContext>();
//app.MapGet("/", () => "Hello World!"); Eliminaremos isso e colocaremos nosso controller

var app = builder.Build();
app.MapControllers(); //Mapenaodn osso controllers
app.Run();
