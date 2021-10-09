var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

app.UseSwagger();
app.MapGet("/", () => "Hello World!");
app.MapGet("/api/values", () => new string[] { "value1", "value2" });
app.MapGet("/api/values/{id:int}", (int id) => $"value for id = {id}" );
app.UseSwaggerUI();
//app.Run();
await app.RunAsync();
