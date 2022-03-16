class Jugador {
    private int monto;
    private int balance;
    private int girosRealizados;
    private int resultadosRojos;
    private int resultadosNegros;
    private int numeroPares;
    private int numeroInpares;
    private List <int> numerosTirados;

    public Jugador(int monto) {
        this.monto = monto;
        this.balance = 0;
        this.girosRealizados = 0;
        this.numeroMasTirado = 0;
        this.numeroMenosTirado = 0;
        this.resultadosNegros = 0;
        this.resultadosRojos = 0;
        this.numeroPares = 0;
        this.numeroInpares = 0;

        for (int i = 0; i < 37; i++) {
            numerosTirados.Add(0);
        }
    }

    public int getMonto() {
        return this.monto;
    }
    public void setMonto(int monto) { 
        this.monto = monto;
    }
    public void sumarMonto(int monto) {
        this.monto += monto;
    }


    public int getBalance() {
        return this.balance;
    }
    public void setBalance(int balance) { 
        this.balance = balance;
    }

    public int getNumeroMasTirado() { 
        int indice = 0;
        int numeroRepeticiones = 0;
        
        for (int i = 0; i < 37; i++) {
            if (numeroRepeticiones > this.numerosTirados[i]) {
                indice = i;
                numeroRepeticiones = this.numerosTirados[i];
            }
        }

        return indice;
    }
    public int getNumeroMenosTirado() {
        int indice = 0;
        int numeroRepeticiones = 10000;
        
        for (int i = 0; i < 37; i++) {
            if (numeroRepeticiones < this.numerosTirados[i]) {
                indice = i;
                numeroRepeticiones = this.numerosTirados[i];
            }
        }

        return indice;
    }

    public int getResultadosRojos() { 
        return this.resultadosRojos;
    }
    public void setResultadosRojos(int resultadosRojos) { 
        this.resultadosRojos = resultadosRojos;
    }

    public int getResultadosNegros() {
        return this.getResultadosNegros;
    }
    public void setResultadosNegros(int resultadosNegros) {
        this.resultadosNegros = resultadosNegros;
    }

    public int getGirosRealizados() {
        return this.girosRealizados;
    }
    public void setGirosRealizados(int girosRealizados) { 
        this.girosRealizados = girosRealizados;
    }

    public int getNumerosInpares() { 
        return this.numeroInpares;
    }
    public void setNumerosImpares(int impares) {
        this.numeroInpares = impares;
    }

    public int getNumerosPares() {
        return this.numeroPares;
    }
    public void setNumerosPares(int par) {
        this.numeroPares = par;
    }

    public void addNumerosTirados(int numero) {
        this.numerosTirados[numero] += 1;
    }

    public string getEstadisticas() {
        return "Balance: " + this.balance + ", Numero mas tirado: " + this.getNumeroMasTirado + ", numero menos tirado: " + 
            this.getNumeroMenosTirado + ", numero de impares: " + this.setNumerosImpares + ", numeros pares: " + this.getNumerosPares + 
            ", Resultados rojos: " + this.resultadosRojos + ", Resultados de negros: " + this.resultadosNegros;
    }
}

class Casino {
    private Ruleta ruleta;

    public Casino() {
        this.ruleta = new Ruleta();
    }

    public int apostarRuleta(int monto, Jugador jugador) {
        List <int> resultado = this.ruleta.girar(monto);
        int number = resultado[1];
        int nuevoMonto = resultado[0];
        int colorSeleccionado = resultado[2];
        jugador.sumarMonto(nuevoMonto);

        if (number % 2 == 0) {
            jugador.setNumerosPares(jugador.getNumerosPares + 1);
        } else {
            jugador.setNumerosImpares(jugador.getNumerosInpares + 1);
        }
        
        if (colorSeleccionado == 1) {
            jugador.setResultadosNegros(jugador.getResultadosNegros() + 1);
        } else if (colorSeleccionado == 2) {
            jugador.setResultadosRojos(jugador.getResultadosRojos() + 1);
        }

        return this.ruleta.girar(monto);
    }
}

class Ruleta {
    private List<int> numerosNegros;
    private List<int> numerosRojos;

    public Ruleta() {
        this.numerosRojos = new List<int>()
        {
            1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36
        };
        this.numerosNegros = new List<int>()
        {
            2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35
        };
    }

    public List<int> girar(int apuesta) {
        Console.WriteLine("Ingrese el tipo de apuesta: ");
        Console.WriteLine("[1] Apostar a un numero espesifico");
        Console.WriteLine("[2] Apostar a un color");
        Console.WriteLine("[3] Apostar a numero par o inpar");

        int opcion = Int32.Parse(Console.ReadLine());
        int cantidad = 0;

        int colorSeleccionado = 0;

        Random myObject = new Random();
        int ranNum = myObject.Next(0, 36);

        if (opcion == 1) {
            Console.WriteLine("Ingrese el numero al que le quiere apostar: ");
            int numero = Int32.Parse(Console.ReadLine());

            if (numero == ranNum) {
                cantidad = apuesta * 10;
            }

        } else if (opcion == 2) {
            Console.WriteLine("Elija el color al apostar:");
            Console.WriteLine("[1] Rojo");
            Console.WriteLine("[2] Negro");

            int color = Int32.Parse(Console.ReadLine());
            int index = Array.IndexOf(this.numerosNegros, ranNum);

            if (index > -1 && color == 2) {
                cantidad = apuesta * 5;
                colorSeleccionado = 1;
            }

            index = Array.IndexOf(this.numerosRojos, ranNum);

            if (index > -1 && color ==1) {
                cantidad = apuesta * 5;
                colorSeleccionado = 2;
            }

        } else if (opcion == 3) {
            Console.WriteLine("Elija si desea apostar por impar o par: ");
            Console.WriteLine("[1] Por numero par");
            Console.WriteLine("[2] Por numero inpar");

            int opcionParInpar = Int32.Parse(Console.ReadLine());

            if (opcionParInpar == 1 && ranNum % 2 == 0) {
                cantidad =  apuesta * 2;
            } else if (opcionParInpar == 2 && ranNum % 2 != 0) {
                cantidad = apuesta * 2;
            }
        }
        
        if (cantidad != 0) {
            cantidad = -apuesta;
        }

        List resultado = new List<int>()
        {
            cantidad, ranNum, colorSeleccionado
        }

        return resultado;
    }
}

class Program {
    static void Main() {

        Jugador jugador= new Jugador(300);
        Casino casino = new Casino();

        while (jugador.getMonto() > 0) {
            Console.WriteLine("Ingrese la opcion: ");
            Console.WriteLine("[1] Apostar");
            Console.WriteLine("[2] Retirarse");
            Console.WriteLine("[3] Conocer estadisticas");
            
            int opcion = Int32.Parse(Console.ReadLine());

            if (opcion == 2) {
                break;
            } else if (opcion== 3) {
                Console.WriteLine(jugador.getEstadisticas());
            } else {
                int apuesta = Int32.Parse(Console.ReadLine());

                if (apuesta % 10 == 0) {
                    casino.apostarRuleta(apuesta, jugador);
                    jugador.setGirosRealizados(jugador.getGirosRealizados() + 1);    
                } else {
                    Console.WriteLine("Solo se puede apotar un numero multiplo de 10");
                }
            }
        }
    }
}

Program.Main();