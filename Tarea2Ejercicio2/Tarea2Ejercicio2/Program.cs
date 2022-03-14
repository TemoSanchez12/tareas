public class Producto {
    private int id;
    private String nombre;
    private int ventas;

    public Producto(int id, String nombre, int ventas) {
        this.id = id;
        this.nombre = nombre;
        this.ventas = ventas;
    }

    public void agregarVenta() {
        this.ventas = ventas + 1;
    }

    public int getId() {
        return this.id;
    }

    public String toString() {
        return "Nombre producto: " + this.nombre + ", ventas: " + this.ventas;
    }
}

public class Inventario {
    private List<Producto> productos;

    public Inventario() {
        productos = new List<Producto> ();
    }

    public bool agregarProducto() {
        int id = Int32.Parse(Console.ReadLine());
        String nombre = Console.ReadLine();
        String categoria = Console.ReadLine();

        if (nombre == null || id == null || categoria == null) {
            return false;
        }

        this.productos.Add (new Producto(id, nombre, 0));

        return true;
    }

    public bool agregarVenta() {
        Console.WriteLine("Ingresa el id del producto que se vendio");
        int id = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < this.productos.Count(); i++) {
            Producto producto = this.productos[i];
            if (producto.getId() == id) {
                producto.agregarVenta();
            }
        }

        return true;
    }

    public void mostrarProductos() {
        for (int i = 0; i < this.productos.Count(); i++) {
            Console.Write(this.productos[i]);
        }
    }
}