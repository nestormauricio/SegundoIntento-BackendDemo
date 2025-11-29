namespace BackendDemo.Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}


















// namespace BackendDemo.Domain;

// public class Product
// {
//     public int Id { get; set; }

//     // Solución: required obliga a asignarlo al crear el objeto
//     public required string Name { get; set; }

//     public decimal Price { get; set; }
// }




















// namespace BackendDemo.Domain;

// public class Product
// {
//     public int Id { get; set; }          // Identificador único
//     public string Name { get; set; } = string.Empty;    // Nombre del producto
//     public decimal Price { get; set; }   // Precio del producto
// }






















// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public decimal Price { get; set; }
// }