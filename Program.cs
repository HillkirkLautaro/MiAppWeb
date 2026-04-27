using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var ruta = "productos.json";

// GET → leer siempre del archivo
app.MapGet("/api/productos", () =>
{
    if (!File.Exists(ruta))
        return new List<Producto>();

    var json = File.ReadAllText(ruta);
    return JsonSerializer.Deserialize<List<Producto>>(json);
});

// POST → leer + agregar + guardar
app.MapPost("/api/productos", (Producto nuevo) =>
{
    List<Producto> productos;

    if (File.Exists(ruta))
    {
        var json = File.ReadAllText(ruta);
        productos = JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();
    }
    else
    {
        productos = new List<Producto>();
    }

    nuevo.Id = productos.Count > 0 ? productos.Max(p => p.Id) + 1 : 1;
    productos.Add(nuevo);

    File.WriteAllText(ruta, JsonSerializer.Serialize(productos));

    return Results.Created($"/api/productos/{nuevo.Id}", nuevo);
});

app.UseDefaultFiles();
app.UseStaticFiles();
app.Run();

record Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Precio { get; set; }
}