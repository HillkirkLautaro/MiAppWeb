using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var ruta = "productos.json";

List<Producto> LeerProductos()
{
    if (!File.Exists(ruta))
        return new List<Producto>();

    var json = File.ReadAllText(ruta);
    return JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();
}

void GuardarProductos(List<Producto> productos)
{
    File.WriteAllText(ruta, JsonSerializer.Serialize(productos));
}

app.MapGet("/api/productos", () => LeerProductos());

app.MapGet("/api/productos/{id}", (int id) =>
{
    var productos = LeerProductos();
    var producto = productos.FirstOrDefault(p => p.Id == id);
    return producto is not null ? Results.Ok(producto) : Results.NotFound();
});

app.MapPost("/api/productos", (Producto nuevo) =>
{
    var productos = LeerProductos();
    nuevo.Id = productos.Count > 0 ? productos.Max(p => p.Id) + 1 : 1;
    productos.Add(nuevo);
    GuardarProductos(productos);
    return Results.Created($"/api/productos/{nuevo.Id}", nuevo);
});

app.MapPut("/api/productos/{id}", (int id, Producto productoActualizado) =>
{
    var productos = LeerProductos();
    var producto = productos.FirstOrDefault(p => p.Id == id);

    if (producto is null)
        return Results.NotFound();

    producto.Nombre = productoActualizado.Nombre;
    producto.Precio = productoActualizado.Precio;
    GuardarProductos(productos);

    return Results.NoContent();
});

app.MapDelete("/api/productos/{id}", (int id) =>
{
    var productos = LeerProductos();
    var producto = productos.FirstOrDefault(p => p.Id == id);

    if (producto is null)
        return Results.NotFound();

    productos.Remove(producto);
    GuardarProductos(productos);

    return Results.NoContent();
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