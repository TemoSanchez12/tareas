public class Pelicula {
    private String nombre;
    private String categoria;
    private int numeroEstante;

    public Pelicula(String nombre, String categoria, int numeroEstante) {
        this.categoria = categoria;
        this.nombre = nombre;  
        this.numeroEstante = numeroEstante;
    }

    public String toString() {
        return "La pelicula " + this.nombre + " se encuentra en la estanteria " + this.numeroEstante;
    }

    public String getNombre() {
        return this.nombre;
    }

    public String getCategoria() {
        return this.categoria;
    }

    public int getEstante() {
        return this.numeroEstante;
    }

}

public class Libreria {
    private List<Pelicula> peliculas;

    public Libreria() {
        this.peliculas = new List<Pelicula>();
    }

    public bool agregarPelicula() {
        String nombre = Console.ReadLine();
        String categoria = Console.ReadLine();
        String numeroEstante = Console.ReadLine();

        if (nombre == null || categoria == null || numeroEstante == null) {
            return false;
        }

        int numeroEstanteEntero = Int32.Parse(numeroEstante);

        Pelicula pelicula = new Pelicula(nombre, categoria, numeroEstanteEntero);
        this.peliculas.Add(pelicula);

        return true;
    }

    public void obtenerPeliculaPorEstanteria() {
        Console.WriteLine("Ingrese el numero de la estanteria que te interesa: ");
        int numeroEstanteria = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < this.peliculas.Count; i++) {
            Pelicula pelicula = this.peliculas[i];
            if (pelicula.getEstante() == numeroEstanteria) {
                Console.WriteLine(pelicula);
            }
        }
    }

    public void obtenerPeliculasPorCategoria() {
        Console.WriteLine("Ingrese nombre de la categoria que te interesa: ");
        String categoria = Console.ReadLine();

        for (int i = 0; i < this.peliculas.Count; i++) {
            Pelicula pelicula = this.peliculas[i];
            if (pelicula.getCategoria() == categoria) {
                Console.WriteLine(pelicula);
            }
        }
    }

    public void obtenerPeliculaPorNombre() {
        Console.WriteLine("Ingrese el nombre de la pelicula que te interesa: ");
        String nombre= Console.ReadLine();

        for (int i = 0; i < this.peliculas.Count; i++) {
            Pelicula pelicula = this.peliculas[i];
            if (pelicula.getNombre() == nombre) {
                Console.WriteLine(pelicula);
            }
        }
    }
}